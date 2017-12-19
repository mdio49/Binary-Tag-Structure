using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.BinaryTagStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTagEditor
{
    public partial class frmRename : Form
    {
        public Tag EditTag { get; set; }

        public frmRename(Tag tag)
        {
            InitializeComponent();

            this.EditTag = tag;

            tbxName.Text = this.EditTag.Name;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                this.EditTag.Parent.RenameTag(this.EditTag.Name, tbxName.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Rename Tag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxName.Text))
            {
                btnApply.Enabled = false;
            }
            else
            {
                btnApply.Enabled = true;
            }
        }
    }
}
