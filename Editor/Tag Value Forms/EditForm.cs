using System;
using System.Collections.Generic;
using System.IO.BinaryTagStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTagEditor
{
    public class EditForm : Form
    {
        public Tag EditTag { get; set; }

        public EditForm() { }

        public EditForm(Tag tag)
        {
            this.EditTag = tag;
        }

        protected void Apply(object value)
        {
            try
            {
                this.EditTag.Value = value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Modify Tag Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
