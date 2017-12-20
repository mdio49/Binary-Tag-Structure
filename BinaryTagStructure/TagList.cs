using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO.BinaryTagStructure
{
    /// <summary>
    /// Represents a special binary tag that stores a list of unnamed tags of the same type.
    /// </summary>
    /// <typeparam name="T">The data type of the tags in the list.</typeparam>
    public class TagList<T> : Tag
    {
        /// <summary>
        /// Get the value of the tag at the specified index in the list tag.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Returns the value of the tag at the specified index in the list tag.</returns>
        public T this[int index]
        {
            get
            {
                return (T)this._tags[index].Value;
            }
            set
            {
                _tags[index] = new Tag(null, this.ListType, (T)value);
            }
        }

        /// <summary>
        /// Gets or sets the data type of the tags in the list.
        /// </summary>
        public TagType ListType { get; set; }

        /// <summary>
        /// Gets the collection of tags contained within the list.
        /// </summary>
        public Tag[] Tags
        {
            get
            {
                return _tags.ToArray();
            }
        }

        private List<Tag> _tags;

        /// <summary>
        /// Gets the length of the tag; for a list tag, this represents the number of items in the list.
        /// </summary>
        public override int Length
        {
            get
            {
                return _tags.Count;
            }
        }

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

                    writer.Write(this.ListType.Identifier);

                    // Writes the data of each tag.
                    foreach (Tag tag in _tags)
                    {
                        if (tag.Type.Length < 0 && this.ListType != TagType.TagCompound)
                        {
                            writer.Write(tag.Length);
                        }

                        writer.Write(tag.Data);
                    }

                    return ms.ToArray();
                }
            }
        } 

        [Obsolete("This property is not used for list tags.")]
        public override object Value { get; set; }

        public TagList(string name) : base(name, TagType.TagList, null)
        {
            this.ListType = TagType.GetTagTypeByDataType(typeof(T));
            _tags = new List<Tag>();
        }

        /// <summary>
        /// Adds a tag to the end of the list tag.
        /// </summary>
        /// <param name="value">The tag to add.</param>
        public void Add(T value)
        {
            if (this.ListType == TagType.TagCompound && typeof(T) == typeof(TagCompound))
            {
                TagCompound t = value as TagCompound;
                t.Parent = this.Parent;
                _tags.Add(t);
            }
            else
            {
                Tag t = new Tag(null, this.ListType, value);
                t.Parent = this.Parent;
                _tags.Add(t);
            }
        }
        
        /// <summary>
        /// Adds a collection of tags to the end of the list tag.
        /// </summary>
        /// <param name="values">The tags to add.</param>
        public void AddRange(params T[] values)
        {
            foreach (T value in values)
            {
                this.Add(value);
            }
        }

        /// <summary>
        /// Removes all tags from the list tag.
        /// </summary>
        public void Clear()
        {
            _tags.Clear();
        }

        /// <summary>
        /// Removes the tag at the specified index.
        /// </summary>
        /// <param name="index">The index of the tag to remove.</param>
        public void RemoveAt(int index)
        {
            _tags.RemoveAt(index);
        }
    }
}
