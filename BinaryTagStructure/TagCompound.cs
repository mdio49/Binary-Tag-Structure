using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.IO.BinaryTagStructure
{
    /// <summary>
    /// Represents a special binary tag that stores other binary tags.
    /// </summary>
    public class TagCompound : Tag
    {
        /// <summary>
        /// Gets the value of the specified tag in the compound.
        /// </summary>
        /// <param name="index">The name of the tag.</param>
        /// <returns>Returns the value of the specified tag.</returns>
        public object this[string index]
        {
            get
            {
                Tag tag = this.GetTag(index);
                return tag.Value;
            }
        }

        /// <summary>
        /// Gets a list of compounds tags within the current compound structure.
        /// </summary>
        protected List<TagCompound> Compounds { get; private set; }

        /// <summary>
        /// Gets a list of tags with the current compound structure.
        /// </summary>
        protected List<Tag> Tags { get; private set; }

        [Obsolete("This property is not used for compound tags.")]
        public override object Value { get; set; }

        /// <summary>
        /// Gets the binary data of the tag's value.
        /// </summary>
        public override byte[] Data
        {
            get
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Format: {tags...[id][name][length][value]}[end]
                    BinaryWriter writer = new BinaryWriter(ms);

                    // Writes the data of other compound tags.
                    foreach (TagCompound tag in this.EnumerateCompounds())
                    {
                        writer.Write(TagType.TagCompound.Identifier);

                        string name = tag.Name == null ? "" : tag.Name;
                        writer.Write(name.Shift(32));

                        writer.Write(tag.Data);
                    }
                    
                    // Writes the data of each tag.
                    foreach (Tag tag in this.EnumerateTags())
                    {
                        writer.Write(tag.Buffer);
                    }

                    // Writes an end tag to signify the end of the compound tag.
                    writer.Write(TagType.TagEnd.Identifier);

                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Gets the full binary data of the tag.
        /// </summary>
        public override byte[] Buffer
        {
            get
            {
                return this.Data;
            }
        }

        /// <summary>
        /// Gets the total number of tags contained within the compound.
        /// </summary>
        public int Count
        {
            get
            {
                return this.Compounds.Count + this.Tags.Count;
            }
        }

        public TagCompound(string name) : base(name, TagType.TagCompound, null)
        {
            this.Compounds = new List<TagCompound>();
            this.Tags = new List<Tag>();
        }

        /// <summary>
        /// Adds a compound tag to the structure.
        /// </summary>
        /// <param name="name">The name of the compound tag.</param>
        public void AddCompound(string name)
        {
            string[] paths = name.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            comp.AddCompound(new TagCompound(paths[paths.Length - 1]));
        }

        /// <summary>
        /// Adds a compound tag to the structure.
        /// </summary>
        /// <param name="tag">The compound tag.</param>
        public void AddCompound(TagCompound tag)
        {
            if (!this.ContainsTag(tag.Name))
            {
                tag.Parent = this;
                this.Compounds.Add(tag);
            }
            else
            {
                throw new ArgumentException("The given tag name already exists in the structure.");
            }
        }

        /// <summary>
        /// Adds a list tag to the structure.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="type">The data type of the list.</param>
        /// <param name="items">The items in the list.</param>
        public void AddList(string name, TagType type, params object[] items)
        {
            string[] paths = name.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            TagList<object> list = new TagList<object>(paths[paths.Length - 1]);
            list.ListType = type;
            list.AddRange(items);
            comp.AddTag(list);
        }

        /// <summary>
        /// Adds a list tag to the structure.
        /// </summary>
        /// <typeparam name="T">The data type of the list.</typeparam>
        /// <param name="name">The name of the tag.</param>
        /// <param name="items">The items in the list.</param>
        public void AddList<T>(string name, params T[] items)
        {
            string[] paths = name.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            TagList<T> list = new TagList<T>(paths[paths.Length - 1]);
            list.AddRange(items);
            comp.AddTag(list);
        }

        /// <summary>
        /// Gets if a tag with the given name exists in the structure.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <returns>Returns a value indicating if a tag with the given name exists.</returns>
        public bool ContainsTag(string name)
        {
            string[] paths = name.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            return comp.Compounds.FindAll(x => x.Name == paths[paths.Length - 1]).Count > 0 || comp.Tags.FindAll(x => x.Name == paths[paths.Length - 1]).Count > 0;
        }

        /// <summary>
        /// Adds a tag to the structure.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="type">The data type of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        public void AddTag(string name, TagType type, object value)
        {
            string[] paths = name.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            comp.AddTag(new Tag(paths[paths.Length - 1], type, value));
        }

        /// <summary>
        /// Adds a tag to the structure.
        /// </summary>
        /// <typeparam name="T">The data type of the tag.</typeparam>
        /// <param name="name">The name of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        public void AddTag<T>(string name, T value)
        {
            this.AddTag(name, TagType.GetTagTypeByDataType(typeof(T)), value);
        }
        
        /// <summary>
        /// Adds a tag to the structure.
        /// </summary>
        /// <param name="tag">The binary tag.</param>
        public void AddTag(Tag tag)
        {
            if (tag.Type == TagType.TagCompound)
            {
                this.AddCompound((TagCompound)tag);
            }
            else if (!this.ContainsTag(tag.Name))
            {
                tag.Parent = this;
                this.Tags.Add(tag);
            }
            else
            {
                throw new ArgumentException("The given tag name already exists in the structure.");
            }
        }

        /// <summary>
        /// Removes the specified tag from the structure.
        /// </summary>
        /// <param name="name">The name of the binary tag.</param>
        public void RemoveTag(string name)
        {
            string[] paths = name.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            string tagName = paths[paths.Length - 1];

            if (comp.ContainsTag(tagName))
            {
                comp.Compounds.RemoveAll(x => x.Name == tagName);
                comp.Tags.RemoveAll(x => x.Name == tagName);
            }
            else
            {
                throw new NullReferenceException("The given tag name does not exist in the structure.");
            }
        }

        /// <summary>
        /// Gets the tag at the specified path.
        /// </summary>
        /// <param name="path">The path of the binary tag.</param>
        /// <returns>Returns the tag at the specified path.</returns>
        public Tag GetTag(string path)
        {
            string[] paths = path.Split('/');

            Tag cTag = null;
            Tag bTag = null;

            TagCompound comp = this;
            dynamic listItem = null;

            for (int i = 0; i < paths.Length; i++)
            {
                if (listItem != null)
                {
                    dynamic t = listItem.Tags[int.Parse(paths[i])];

                    if (t is TagCompound)
                    {
                        comp = t;
                    }
                    else
                    {
                        bTag = t;
                    }

                    listItem = null;
                }
                else
                {
                    if (i == paths.Length - 1)
                    {
                        break;
                    }

                    dynamic t = comp.GetTag(paths[i]);

                    if (t is TagCompound)
                    {
                        comp = t;
                    }
                    else if (t.GetType().IsGenericType && t.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(TagList<>)))
                    {
                        listItem = t;
                    }
                }
            }

            if (cTag == null)
            {
                cTag = comp.Compounds.Find(x => x.Name == paths[paths.Length - 1]);
            }

            if (bTag == null)
            {
                bTag = comp.Tags.Find(x => x.Name == paths[paths.Length - 1]);
            }

            if (cTag != null && bTag != null)
            {
                throw new Exception("A compound and non-compound tag of the given tag name exists.");
            }
            else if (cTag != null)
            {
                return cTag;
            }
            else if (bTag != null)
            {
                return bTag;
            }
            else
            {
                throw new ArgumentException("The given tag name does not exist in the structure.");
            }
        }

        /// <summary>
        /// Gets the tag at the specified path.
        /// </summary>
        /// <typeparam name="T">Used to denote a tag that uses a different class that inherits the 'Tag' class (e.g. TagCompound).</typeparam>
        /// <param name="path">The path of the binary tag.</param>
        /// <returns>Returns the tag at the specified path.</returns>
        public T GetTag<T>(string path) where T : Tag
        {
            return (T)this.GetTag(path);
        }

        /// <summary>
        /// Gets the tag at the specified path, where the tag type is a list.
        /// </summary>
        /// <typeparam name="T">The data type of the tags in the list.</typeparam>
        /// <param name="path">The path of the binary tag.</param>
        /// <returns>Returns the tag at the specified path.</returns>
        public TagList<T> GetListTag<T>(string path)
        {
            return (TagList<T>)this.GetTag(path);
        }

        /// <summary>
        /// Gets the value of the tag at the specified path. If the tag does not exist, then the default value of the type specified is returned.
        /// </summary>
        /// <typeparam name="T">The tag's type.</typeparam>
        /// <param name="path">The path of the binary tag.</param>
        /// <returns>Returns the value of the specified tag.</returns>
        public T GetValue<T>(string path)
        {
            return this.GetValue(path, default(T));
        }

        /// <summary>
        /// Gets the value of the tag at the specified path. If the tag does not exist, then the default value of the type specified is returned.
        /// </summary>
        /// <typeparam name="T">The tag's type.</typeparam>
        /// <param name="path">The path of the binary tag.</param>
        /// <param name="defaultValue">The default value to return if the tag does not exist.</param>
        /// <returns>Returns the value of the specified tag.</returns>
        public T GetValue<T>(string path, T defaultValue)
        {
            if (this.ContainsTag(path))
            {
                Tag tag = this.GetTag(path);
                return (T)tag.Value;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Sets the values of the specified list tag.
        /// </summary>
        /// <typeparam name="T">The data type of the tags in the list.</typeparam>
        /// <param name="path">The path of the binary tag.</param>
        /// <param name="values">The items in the list.</param>
        public void SetList<T>(string path, T[] values)
        {
            string[] paths = path.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            TagList<T> lTag = this.GetListTag<T>(path);

            if (comp.Tags.Contains(lTag))
            {
                lTag.Tags.Clear();
                lTag.AddRange(values);
            }
            else
            {
                throw new ArgumentException("The given tag name does not exist in the structure.");
            }
        }

        /// <summary>
        /// Sets the value of the specified tag.
        /// </summary>
        /// <param name="path">The path to the binary tag.</param>
        /// <param name="value">The new value of the binary tag.</param>
        public void SetTag(string path, object value)
        {
            this.SetTag(path, value, null, false);
        }

        /// <summary>
        /// Sets the value of the specified tag.
        /// </summary>
        /// <param name="path">The path to the binary tag.</param>
        /// <param name="value">The new value of the binary tag.</param>
        /// <param name="type">The data type of the tag.</param>
        /// <param name="create">Set to true if the tag should be created if it doesn't exist.</param>
        public void SetTag(string path, object value, TagType type, bool create)
        {
            string[] paths = path.Split('/');

            TagCompound comp = this;

            for (int i = 0; i < paths.Length - 1; i++)
            {
                TagCompound tag = (TagCompound)comp.GetTag(paths[i]);
                comp = tag;
            }

            Tag bTag = null;

            try
            {
                bTag = this.GetTag(path);
            }
            catch (Exception ex)
            {
                if (create == false)
                {
                    throw ex;
                }
            }

            if (bTag != null && comp.Tags.Contains(bTag))
            {
                bTag.Value = value;
            }
            else
            {
                if (create == true)
                {
                    this.AddTag(paths[paths.Length - 1], type, value);
                }
                else
                {
                    throw new ArgumentException("The given tag name does not exist in the structure.");
                }
            }
        }

        /// <summary>
        /// Sets the value of the specified tag.
        /// </summary>
        /// <typeparam name="T">The data type of the tag.</typeparam>
        /// <param name="path">The path to the binary tag.</param>
        /// <param name="value">The new value of the binary tag.</param>
        /// <param name="create">Set to true if the tag should be created if it doesn't exist.</param>
        public void SetTag<T>(string path, T value, bool create)
        {
            this.SetTag(path, value, TagType.GetTagTypeByDataType(typeof(T)), create);
        }

        /// <summary>
        /// Renames the given tag name to the new given name.
        /// </summary>
        /// <param name="originalName">The name of the tag.</param>
        /// <param name="targetName">The value to rename the tag's name to.</param>
        public void RenameTag(string originalName, string targetName)
        {
            if (this.ContainsTag(originalName))
            {
                // Checks if the target name does not already exist in the structure.
                if (this.ContainsTag(targetName))
                {
                    throw new ArgumentException("The given tag name already exists in the structure.");
                }

                Tag tag = this.GetTag(originalName);
                tag.Name = targetName;
            }
            else
            {
                throw new NullReferenceException("The given tag name does not exist in the structure.");
            }
        }

        /// <summary>
        /// Removes all tags in the current compound structure.
        /// </summary>
        public void Clear()
        {
            this.Compounds.Clear();
            this.Tags.Clear();
        }

        /// <summary>
        /// Enumerates through all compound tags within the current compound structure.
        /// </summary>
        /// <returns>Returns an array of all compound tags.</returns>
        public TagCompound[] EnumerateCompounds()
        {
            return this.Compounds.ToArray();
        }

        /// <summary>
        /// Enumerates through all non-compound tags within the current compound structure.
        /// </summary>
        /// <returns>Returns an array of all tags.</returns>
        public Tag[] EnumerateTags()
        {
            return this.Tags.ToArray();
        }
    }
}
