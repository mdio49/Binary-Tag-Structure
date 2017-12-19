using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.BinaryTagStructure;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinaryTagEditor
{
    public partial class frmAddTag : Form
    {
        public TagCompound Compound { get; set; }

        public frmAddTag(TagCompound compound)
        {
            InitializeComponent();

            this.Compound = compound;

            lvwTypes.SmallImageList = Functions.Icons;
            lvwTypes.View = View.List;
            lvwTypes.MultiSelect = false;

            foreach (TagType type in TagType.EnumerateTypes())
            {
                lvwTypes.Items.Add(type.Name, Functions.TagIcons.Keys.Contains(type) ? Functions.TagIcons[type] : 0);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                TagType type = TagType.EnumerateTypes()[lvwTypes.SelectedIndices[0]];
                this.Compound.AddTag(tbxName.Text, type, type.DataType.IsValueType ? Activator.CreateInstance(type.DataType) : null);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Add Tag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxName.Text))
            {
                btnCreate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = true;
            }
        }
    }
}
