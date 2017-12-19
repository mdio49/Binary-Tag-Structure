using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.BinaryTagStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTagEditor
{
    public static class Functions
    {
        public static Dictionary<TagType, int> TagIcons { get; set; }
        public static Dictionary<TagType, Type> TagForms { get; set; }

        public static BinaryTagStructure Structure { get; set; }

        public static ImageList Icons { get; private set; }

        public static void Initialize()
        {
            Functions.TagIcons = new Dictionary<TagType, int>();
            Functions.TagForms = new Dictionary<TagType, Type>();

            Functions.Icons = new ImageList();
            Functions.Icons.Images.Add(Image.FromFile("icons/tag.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_end.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_compound.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_list.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_byte.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_byte_array.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_short.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_integer.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_long.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_float.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_double.png"));
            Functions.Icons.Images.Add(Image.FromFile("icons/tag_string.png"));
        }

        public static void Load(string path)
        {
            //try
            {
                BinaryTagStructure structure = new BinaryTagStructure(path);
                structure.Load();
                Functions.Structure = structure;
            }
            /*catch
            {
                MessageBox.Show("An error occured while opening this file.", "Cannot Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public static void Save()
        {
            Functions.Save(Functions.Structure.Path);
        }

        public static void Save(string path)
        {
            Functions.Structure.Path = path;
            Functions.Structure.Save();
        }
    }
}
