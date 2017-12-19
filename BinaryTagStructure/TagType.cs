using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace System.IO.BinaryTagStructure
{
    /// <summary>
    /// Represents the method that will handle a conversion event for a tag from its original type to a byte array.
    /// </summary>
    /// <param name="value">The inputted value to convert.</param>
    /// <param name="e">The event's arguments.</param>
    /// <returns>Returns the value of the tag as a byte array.</returns>
    public delegate byte[] TagByteEventHandler(object value, EventArgs e);

    /// <summary>
    /// Represents the method that will handle a conversion event for a tag from a byte array to its original type.
    /// </summary>
    /// <param name="value">The inputted bytes to convert.</param>
    /// <param name="e">The event's arguments.</param>
    /// <returns>Returns the value of the tag as the tag's type.</returns>
    public delegate object TagTypeEventHandler(byte[] value, EventArgs e);

    /// <summary>
    /// Represents a data type for a binary tag.
    /// </summary>
    public class TagType
    {
        private static readonly List<TagType> TagTypes = new List<TagType>();

        /// <summary>
        /// Occurs when the tag is required to convert  to a byte array (i.e. written to a file).
        /// </summary>
        public event TagByteEventHandler BytesConverter;

        /// <summary>
        /// Occurs when the tag is required to convert to the value type (i.e. read from a file).
        /// </summary>
        public event TagTypeEventHandler TypeConverter;

        public byte Identifier { get; private set; }

        public string Name { get; private set; }

        /// <summary>
        /// Gets the data type associated with the tag type.
        /// </summary>
        public Type DataType { get; private set; }

        /// <summary>
        /// Gets a fixed number of bytes that the tag's value holds. A value of -1 denotes a variable length.
        /// </summary>
        /// <remarks> If this value is defined, then the length prefix is not used when writing the tag to a file.</remarks>
        public int Length { get; set; }

        public TagType(byte id, string name, Type type, TagByteEventHandler bytesConverter, TagTypeEventHandler typeConverter) : this(id, name, type, bytesConverter, typeConverter, -1) { }

        public TagType(byte id, string name, Type type, TagByteEventHandler bytesConverter, TagTypeEventHandler typeConverter, int length)
        {
            this.Identifier = id;
            this.Name = name;
            this.DataType = type;
            this.BytesConverter = bytesConverter;
            this.TypeConverter = typeConverter;
            this.Length = length;

            TagTypes.Add(this);
        }
        
        /// <summary>
        /// Converts the value inputted as a byte array using the conversion events in the tag type.
        /// </summary>
        /// <param name="value">The value of the tag.</param>
        /// <returns>Returns a byte array representing the tag's value.</returns>
        public byte[] ConvertToBytes(object value)
        {
            if (this.BytesConverter != null)
            {
                return this.BytesConverter(value, EventArgs.Empty);
            }
            else
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// Converts the byte array inputted back to the original value using the conversion events in the tag type.
        /// </summary>
        /// <param name="value">The byte array representation of the tag's value.</param>
        /// <return>Returns the tag's value from the given byte array.</return>
        public object ConvertToValue(byte[] value)
        {
            if (this.TypeConverter != null)
            {
                return this.TypeConverter(value, EventArgs.Empty);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the tag type with the given unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tag type.</param>
        /// <returns>Returns the tag type with the given unique identifier.</returns>
        public static TagType GetTagTypeById(byte id)
        {
            TagType tagType = TagTypes.Find(x => x.Identifier == id);

            if (tagType != null)
            {
                return tagType;
            }
            else
            {
                throw new ArgumentException("There is no tag type that exists with the given identifier.");
            }
        }

        /// <summary>
        /// Gets the tag type based from the given data type.
        /// </summary>
        /// <param name="type">The data type.</param>
        /// <returns>Returns the tag type based from the given data type.</returns>
        public static TagType GetTagTypeByDataType(Type type)
        {
            TagType tagType = TagTypes.Find(x => x.DataType == type);

            if (tagType != null)
            {
                return tagType;
            }
            else
            {
                throw new ArgumentException("There is no tag type based off the given data type that exists.");
            }
        }

        public static TagType[] EnumerateTypes()
        {
            return TagTypes.ToArray();
        }

        /// <summary>
        /// Converts a value to the data type of the specified tag type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The target tag type.</param>
        /// <returns>Returns a value in the form of the target tag type.</returns>
        public static object ConvertTo(object value, TagType type)
        {
            return Convert.ChangeType(value, type.DataType, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets a value indicating if conversion of a value to the specified tag type is possible.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="type">The target tag type.</param>
        /// <returns>Returns a value indicating if conversion is possible.</returns>
        public static bool CanConvert(object value, TagType type)
        {
            try
            {
                object test = TagType.ConvertTo(value, type);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Represents a tag type that indicates the end of a compound tag.
        /// </summary>
        public static readonly TagType TagEnd = new TagType(0x00, "TagEnd", typeof(object), null, null, 0);

        /// <summary>
        /// Represents a tag type for a compound tag.
        /// </summary>
        public static readonly TagType TagCompound = new TagType(0x01, "TagCompound", typeof(TagCompound), null, null);

        /// <summary>
        /// Represents a tag type for a list tag.
        /// </summary>
        public static readonly TagType TagList = new TagType(0x02, "TagList", typeof(TagList<>), null, null);

        /// <summary>
        /// Represents a tag type for a byte tag.
        /// </summary>
        public static readonly TagType TagBoolean = new TagType(0x03, "TagBoolean", typeof(bool), TagBoolean_ToBytes, TagBoolean_ToType, 1);

        /// <summary>
        /// Represents a tag type for a byte tag.
        /// </summary>
        public static readonly TagType TagByte = new TagType(0x04, "TagByte", typeof(byte), TagByte_ToBytes, TagByte_ToType, 1);

        /// <summary>
        /// Represents a tag type for a byte array tag.
        /// </summary>
        public static readonly TagType TagByteArray = new TagType(0x05, "TagByteArray", typeof(byte[]), TagByteArray_ToBytes, TagByteArray_ToType);

        /// <summary>
        /// Represents a tag type for a character tag.
        /// </summary>
        public static readonly TagType TagChar = new TagType(0x06, "TagChar", typeof(char), TagChar_ToBytes, TagChar_ToType, 1);

        /// <summary>
        /// Represents a tag type for a string tag.
        /// </summary>
        public static readonly TagType TagString = new TagType(0x07, "TagString", typeof(string), TagString_ToBytes, TagString_ToType);

        /// <summary>
        /// Represents a tag type for a short tag.
        /// </summary>
        public static readonly TagType TagShort = new TagType(0x08, "TagShort", typeof(short), TagInt16_ToBytes, TagInt16_ToType, 2);

        /// <summary>
        /// Represents a tag type for an integer tag.
        /// </summary>
        public static readonly TagType TagInteger = new TagType(0x09, "TagInteger", typeof(int), TagInt32_ToBytes, TagInt32_ToType, 4);

        /// <summary>
        /// Represents a tag type for a long tag.
        /// </summary>
        public static readonly TagType TagLong = new TagType(0x0A, "TagLong", typeof(long), TagInt64_ToBytes, TagInt64_ToType, 8);

        /// <summary>
        /// Represents a tag type for a float tag.
        /// </summary>
        public static readonly TagType TagFloat = new TagType(0x0B, "TagFloat", typeof(float), TagSingle_ToBytes, TagSingle_ToType, 4);

        /// <summary>
        /// Represents a tag type for a double tag.
        /// </summary>
        public static readonly TagType TagDouble = new TagType(0x0C, "TagDouble", typeof(double), TagDouble_ToBytes, TagDouble_ToType, 8);

        /// <summary>
        /// Represents a tag type for a decimal tag.
        /// </summary>
        //public static readonly TagType TagDecimal = new TagType(TagDecimal_ToBytes, TagDecimal_ToType, 16);

        #region Tag Events

        private static byte[] TagBoolean_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes((bool)value);
        }

        private static object TagBoolean_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToBoolean(value, 0);
        }

        private static byte[] TagByte_ToBytes(object value, EventArgs e)
        {
            byte[] array = new byte[1];
            array[0] = Convert.ToByte(value);
            return array;
        }

        private static object TagByte_ToType(byte[] value, EventArgs e)
        {
            return value[0];
        }

        private static byte[] TagByteArray_ToBytes(object value, EventArgs e)
        {
            return (byte[])value;
        }

        private static object TagByteArray_ToType(byte[] value, EventArgs e)
        {
            return (byte[])value;
        }

        private static byte[] TagChar_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes(Convert.ToChar(value));
        }

        private static object TagChar_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToChar(value, 0);
        }

        private static byte[] TagString_ToBytes(object value, EventArgs e)
        {
            string s = "";

            if (value != null)
            {
                s = value.ToString();
            }

            return Encoding.UTF8.GetBytes(s.Shift(32));
        }

        private static object TagString_ToType(byte[] value, EventArgs e)
        {
            return Encoding.UTF8.GetString(value).Shift(-32);
        }

        private static byte[] TagInt16_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes(Convert.ToInt16(value));
        }

        private static object TagInt16_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToInt16(value, 0);
        }

        private static byte[] TagInt32_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes(Convert.ToInt32(value));
        }

        private static object TagInt32_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToInt32(value, 0);
        }

        private static byte[] TagInt64_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes(Convert.ToInt64(value));
        }

        private static object TagInt64_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToInt64(value, 0);
        }

        private static byte[] TagSingle_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes(Convert.ToSingle(value));
        }

        private static object TagSingle_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToSingle(value, 0);
        }

        private static byte[] TagDouble_ToBytes(object value, EventArgs e)
        {
            return BitConverter.GetBytes(Convert.ToDouble(value));
        }

        private static object TagDouble_ToType(byte[] value, EventArgs e)
        {
            return BitConverter.ToDouble(value, 0);
        }

        #endregion
    }
}
