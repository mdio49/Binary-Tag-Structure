using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.IO.BinaryTagStructure
{
    /// <summary>
    /// Represents a binary tag in a binary tag structure.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the data type of the tag.
        /// </summary>
        public TagType Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the tag.
        /// </summary>
        public virtual object Value { get; set; }

        /// <summary>
        /// Gets or sets the parent compound tag.
        /// </summary>
        public TagCompound Parent { get; set; }

        /// <summary>
        /// Gets the length of the tag in bytes.
        /// </summary>
        public virtual int Length
        {
            get
            {
                return this.Data.Length;
            }
        }

        /// <summary>
        /// Gets the binary data of the tag's value.
        /// </summary>
        public virtual byte[] Data
        {
            get
            {
                return this.Type.ConvertToBytes(this.Value);
            }
        }

        /// <summary>
        /// Gets the full binary data of the tag.
        /// </summary>
        public virtual byte[] Buffer
        {
            get
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryWriter writer = new BinaryWriter(ms);

                    writer.Write(this.Type.Identifier);
                    writer.Write(this.Name.Shift(32));

                    if (this.Type.Length < 0)
                    {
                        writer.Write(this.Length);
                    }

                    writer.Write(this.Data);

                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="type">The data type of the tag.</param>
        /// <param name="value">The value of the tag.</param>
        public Tag(string name, TagType type, object value)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
        }

        /// <summary>
        /// Determines if the specified tag is a list tag.
        /// </summary>
        /// <param name="tag">The tag to test.</param>
        /// <returns>Returns a value indicating if the specified tag is a list tag.</returns>
        public static bool IsListTag(Tag tag)
        {
            return tag.GetType().IsGenericType && tag.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(TagList<>));
        }

        /// <summary>
        /// Returns a new tag from the given data buffer.
        /// </summary>
        /// <param name="buffer">An array of unsigned bytes containing the tag data.</param>
        /// <returns>Returns a new tag from the given data buffer.</returns>
        public static Tag FromBuffer(byte[] buffer)
        {
            return Tag.FromBuffer(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Returns a new tag from the given data buffer.
        /// </summary>
        /// <param name="buffer">An array of unsigned bytes containing the tag data.</param>
        /// <param name="index">The index of the starting position in buffer that contains the tag data.</param>
        /// <param name="count">The number of bytes to use from the buffer that are allocated to the tag data.</param>
        /// <returns>Returns a new tag from the given data buffer.</returns>
        public static Tag FromBuffer(byte[] buffer, int index, int count)
        {
            using (MemoryStream ms = new MemoryStream(buffer, index, count))
            {
                BinaryReader reader = new BinaryReader(ms);

                byte id = reader.ReadByte();
                TagType type = TagType.GetTagTypeById(id);
                string name = reader.ReadString().Shift(-32);

                int length;

                if (type.Length < 0)
                {
                    length = reader.ReadInt32();
                }
                else
                {
                    length = type.Length;
                }

                byte[] value = reader.ReadBytes(length);

                return new Tag(name, type, type.ConvertToValue(value));
            }
        }
    }
}
