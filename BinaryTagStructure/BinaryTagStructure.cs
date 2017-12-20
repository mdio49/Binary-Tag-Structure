using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.IO.BinaryTagStructure
{
    /// <summary>
    /// Represents an enumeration containing various merging methods.
    /// </summary>
    public enum MergeMethod
    {
        /// <summary>
        /// All tags in the structure are copied over to the source structure.
        /// </summary>
        Overwrite,

        /// <summary>
        /// Tags that only exist in the source structure are copied over. Tags will hence only copy if the tags in both structures are of the same type or a suitable conversion is available.
        /// </summary>
        SourceOnly,

        /// <summary>
        /// All tags in the structure are copied, but source tags are not overriden.
        /// </summary>
        KeepSource
    }

    /// <summary>
    /// Represents a binary tag structure that stores named definitions with values set to them.
    /// </summary>
    public class BinaryTagStructure : TagCompound, IDisposable
    {
        /// <summary>
        /// Gets or sets the file path associated with the binary tag structure.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets the binary data of the structure.
        /// </summary>
        public override byte[] Data
        {
            get
            {
                return base.Data;
            }
        }

        /// <summary>
        /// Gets the length of the binary tag structure in bytes.
        /// </summary>
        public override int Length
        {
            get
            {
                return base.Length;
            }
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public BinaryTagStructure() : base(null) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="path">The file path associated with the binary tag structure.</param>
        public BinaryTagStructure(string path) : base(null)
        {
            this.Path = path;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="data">An array of unsigned bytes containing the binary data for the binary tag structure.</param>
        public BinaryTagStructure(byte[] data) : this(data, 0, data.Length) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="data">An array of unsigned bytes containing the binary data for the binary tag structure.</param>
        /// <param name="index">The index of the starting position in buffer that contains the binary data.</param>
        /// <param name="count">The number of bytes to use from the buffer that are allocated to the binary tag structure.</param>
        public BinaryTagStructure(byte[] data, int index, int count) : base(null)
        {
            using (MemoryStream ms = new MemoryStream(data, index, count))
            {
                this.LoadFrom(ms);
            }
        }

        /// <summary>
        /// Disposes the binary tag structure and any resources associated with it.
        /// </summary>
        public void Dispose()
        {
            this.Clear();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Merges the given structure with the current structure using the specified merging method.
        /// </summary>
        /// <param name="structure">The structure to merge.</param>
        /// <param name="method">The method of merging.</param>
        public void Merge(BinaryTagStructure structure, MergeMethod method)
        {
            MergeCompound(this, structure, method);
        }

        private void MergeCompound(TagCompound original, TagCompound compound, MergeMethod method)
        {
            if (method == MergeMethod.KeepSource)
            {
                foreach (TagCompound tag in compound.EnumerateCompounds())
                {
                    if (!original.ContainsTag(tag.Name))
                    {
                        // If the compound does not exist in the source structure, then simply add it.
                        original.AddCompound(tag);
                    }
                    else
                    {
                        // Otherwise, continue normal merging with that compound.
                        MergeCompound(compound, tag, method);
                    }
                }

                foreach (Tag tag in compound.EnumerateTags())
                {
                    // Adds the tag only if it does not exist in the source structure.
                    if (!original.ContainsTag(tag.Name))
                    {
                        original.AddTag(tag);
                    }
                }
            }
            else if (method == MergeMethod.Overwrite)
            {
                foreach (TagCompound tag in compound.EnumerateCompounds())
                {
                    if (!original.ContainsTag(tag.Name))
                    {
                        // If the compound does not exist in the source structure, then simply add it.
                        original.AddCompound(tag);
                    }
                    else
                    {
                        // Otherwise, continue normal merging with that compound.
                        MergeCompound(compound, tag, method);
                    }
                }

                foreach (Tag tag in compound.EnumerateTags())
                {
                    // If the tag already exists in the source structure, then remove it.
                    if (original.ContainsTag(tag.Name))
                    {
                        original.RemoveTag(tag.Name);
                    }

                    // Add the merged tag.
                    original.AddTag(tag);
                }
            }
            else if (method == MergeMethod.SourceOnly)
            {
                foreach (TagCompound tag in compound.EnumerateCompounds())
                {
                    if (original.ContainsTag(tag.Name))
                    {
                        MergeCompound(compound, tag, method);
                    }
                }

                foreach (Tag tag in compound.EnumerateTags())
                {
                    // Checks if the tag exists in the source structure.
                    if (original.ContainsTag(tag.Name))
                    {
                        Tag t = original.GetTag(tag.Name);

                        // Checks if there is a suitable conversion between the two tag types.
                        if (TagType.CanConvert(tag.Value, t.Type))
                        {
                            // Sets the value of the source tag to the converted value of the tag.
                            t.Value = TagType.ConvertTo(tag.Value, t.Type);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads the specified binary tag structure and merges its tags with the current property file using the specified merging method.
        /// </summary>
        /// <param name="path">The file path of the binary tag structure.</param>
        /// <param name="method">The method of merging.</param>
        public void MergeFrom(string path, MergeMethod method)
        {
            BinaryTagStructure structure = new BinaryTagStructure(path);
            structure.Load();
            this.Merge(structure, method);
        }

        /// <summary>
        /// Saves the binary tag structure to its file path.
        /// </summary>
        public void Save()
        {
            // First writes the data to a memory stream.
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);

            try
            {
                writer.Write(this.Buffer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Closes the stream if writing fails.
                writer.Close();
            }

            // Then rewrites the memory stream to the file stream.
            FileStream fs = new FileStream(this.Path, FileMode.Create);
            writer = new BinaryWriter(fs);

            try
            {
                writer.Write(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Closes the stream if writing fails.
                writer.Close();
            }
        }

        /// <summary>
        /// Saves a copy of the binary tag structure to the specified file path.
        /// </summary>
        /// <param name="path">The file path of the binary tag structure.</param>
        public void SaveTo(string path)
        {
            BinaryTagStructure structure = new BinaryTagStructure();
            structure.Merge(this, MergeMethod.Overwrite);
            structure.Save();
        }

        private void LoadCompound(BinaryReader reader, TagCompound compound)
        {
            while (true)
            {
                byte id = reader.ReadByte();

                if (id == TagType.TagEnd.Identifier)
                {
                    break;
                }
                else
                {
                    string name = reader.ReadString();
                    name = name.Shift(-32);

                    if (id == TagType.TagCompound.Identifier)
                    {
                        TagCompound tag = new TagCompound(name);
                        compound.AddCompound(tag);
                        LoadCompound(reader, tag);
                    }
                    else if (id == TagType.TagList.Identifier)
                    {
                        int count = reader.ReadInt32();
                        byte listId = reader.ReadByte();

                        TagType listType = TagType.GetTagTypeById(listId);

                        Type genericClass = typeof(TagList<>);
                        Type constructedClass = genericClass.MakeGenericType(listType.DataType);

                        dynamic tag = Activator.CreateInstance(constructedClass, name);
                        tag.ListType = TagType.GetTagTypeById(listId);

                        for (int i = 0; i < count; i++)
                        {
                            if (tag.ListType == TagType.TagCompound)
                            {
                                TagCompound c = new TagCompound(null);
                                LoadCompound(reader, c);
                                tag.Add(c);
                            }
                            else
                            {
                                int length = tag.ListType.Length >= 0 ? tag.ListType.Length : reader.ReadInt32();
                                byte[] data = reader.ReadBytes(length);
                                tag.Add(tag.ListType.ConvertToValue(data));
                            }
                        }

                        compound.AddTag(tag);
                    }
                    else
                    {
                        TagType type = TagType.GetTagTypeById(id);

                        int length = type.Length >= 0 ? type.Length : reader.ReadInt32();
                        byte[] data = reader.ReadBytes(length);

                        compound.AddTag(name, type, type.ConvertToValue(data));
                    }
                }
            }
        }

        private void LoadStructure(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);

            try
            {
                LoadCompound(reader, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Closes the stream if reading fails.
                reader.Close();
            }
        }

        /// <summary>
        /// Loads the binary tag structure from its file path.
        /// </summary>
        public void Load()
        {
            // Will only attempt to load the structure if the file exists.
            if (File.Exists(this.Path))
            {
                BinaryTagStructure structure = new BinaryTagStructure();
                structure.LoadStructure(new FileStream(this.Path, FileMode.Open, FileAccess.Read));
                this.Merge(structure, MergeMethod.Overwrite);
            }
        }

        /// <summary>
        /// Loads the specified binary tag structure and merges its tags with the current structure. The current structure is cleared in the process.
        /// </summary>
        /// <param name="path">The file path of the binary tag structure.</param>
        public void LoadFrom(string path)
        {
            this.LoadFrom(new FileStream(this.Path, FileMode.Open, FileAccess.Read));
        }

        /// <summary>
        /// Loads the specified binary tag structure and merges its tags with the current structure. The current structure is cleared in the process.
        /// </summary>
        /// <param name="stream">The stream that contains data about the binary tag structure.</param>
        public void LoadFrom(Stream stream)
        {
            BinaryTagStructure structure = new BinaryTagStructure();
            structure.LoadStructure(stream);

            this.Clear();
            this.Merge(structure, MergeMethod.Overwrite);
        }


        /// <summary>
        /// Loads a binary tag structure from a file path.
        /// </summary>
        /// <param name="path">The file path of the binary tag structure.</param>
        /// <returns>Returns a new binary tag structure loaded from an external file path.</returns>
        public static BinaryTagStructure FromFile(string path)
        {
            BinaryTagStructure structure = new BinaryTagStructure(path);
            structure.Load();
            return structure;
        }

        /// <summary>
        /// Loads a binary tag structure from a stream.
        /// </summary>
        /// <param name="stream">The stream that contains data about the binary tag structure.</param>
        /// <returns>Returns a new binary tag structure loaded from a stream.</returns>
        public static BinaryTagStructure FromStream(Stream stream)
        {
            BinaryTagStructure structure = new BinaryTagStructure();
            structure.LoadFrom(stream);
            return structure;
        }
    }
}
