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
    public partial class frmTagProperties : Form
    {
        public Tag EditTag { get; set; }

        public object EditValue { get; set; }
        public int EditLength { get; set; }

        public frmTagProperties(Tag tag)
        {
            InitializeComponent();

            this.EditTag = tag;
            this.EditValue = this.EditTag.Value;

            cbxTypes.Text = this.EditTag.Type.Name;
            tbxName.Text = this.EditTag.Name;

            nupLength.Value = this.EditTag.Length;

            if (this.EditTag.Type != TagType.TagCompound)
            {
                nupLength.Enabled = false;//this.EditTag.Type.Length == -1;
                tbxValue.Text = this.EditTag.Value.ToString();
                btnEditValue.Enabled = true;

                hlpData.ReadOnly = false;
                hlpData.TextChanged += hlpData_TextChanged;
                hlpData.SetValue(this.EditTag.Type.ConvertToBytes(this.EditTag.Value));
            }
            else
            {
                btnChangeType.Enabled = false;

                nupLength.Enabled = false;
                tbxValue.Text = "";
                btnEditValue.Enabled = false;

                hlpData.ReadOnly = true;
                hlpData.SetValue(this.EditTag.Data);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxName.Text != this.EditTag.Name)
                {
                    this.EditTag.Parent.RenameTag(this.EditTag.Name, tbxName.Text);
                }

                this.EditTag.Value = this.EditValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Apply Tag Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnEditValue_Click(object sender, EventArgs e)
        {
            if (this.EditTag.Type != TagType.TagCompound)
            {
                Tag tag = new Tag(this.EditTag.Name, this.EditTag.Type, this.EditValue);

                EditForm form = Functions.TagForms.Keys.Contains(this.EditTag.Type) ? (EditForm)Activator.CreateInstance(Functions.TagForms[this.EditTag.Type], tag) : new frmEdit(tag);
                form.Text = "Modify Tag Value";
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.ShowIcon = false;
                form.ShowInTaskbar = false;
                form.MinimizeBox = false;
                form.MaximizeBox = false;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.EditValue = tag.Value;
                    this.EditLength = tag.Length;

                    nupLength.Value = tag.Length;
                    tbxValue.Text = this.EditValue.ToString();
                    hlpData.SetValue(this.EditTag.Type.ConvertToBytes(this.EditValue));

                    btnChangeType.Enabled = true;
                    cbxTypes.Enabled = false;
                }
            }
        }

        private void btnChangeType_Click(object sender, EventArgs e)
        {
            cbxTypes.Items.Clear();

            foreach (TagType type in TagType.EnumerateTypes())
            {
                if (TagType.CanConvert(this.EditValue, type))
                {
                    cbxTypes.Items.Add(type.Name);
                }
            }

            btnChangeType.Enabled = false;
            cbxTypes.Enabled = true;
            cbxTypes.Text = this.EditTag.Type.Name;
        }

        private void cbxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TagType type in TagType.EnumerateTypes())
            {
                if (type.Name == cbxTypes.SelectedItem.ToString())
                {
                    this.EditTag.Type = type;

                    nupLength.Value = this.EditTag.Length;
                    nupLength.Enabled = false;//this.EditTag.Type.Length == -1;
                    tbxValue.Text = this.EditValue.ToString();
                    hlpData.SetValue(this.EditTag.Type.ConvertToBytes(this.EditValue));
                }
            }
        }

        private void hlpData_TextChanged(object sender, EventArgs e)
        {
            this.EditValue = this.EditTag.Type.ConvertToValue(hlpData.GetValue());
            this.EditLength = hlpData.GetValue().Length;
            tbxValue.Text = this.EditValue.ToString();

            btnChangeType.Enabled = true;
            cbxTypes.Enabled = false;
        }

        private void nupLength_ValueChanged(object sender, EventArgs e)
        {
            /*byte[] oldData = this.EditTag.Type.ConvertToBytes(this.EditValue);
            byte[] newData = new byte[(int)nupLength.Value];

            for (int i = 0; i < newData.Length; i++)
            {
                if (i < oldData.Length)
                {
                    newData[i] = oldData[i];
                }
                else
                {
                    newData[i] = 0x00;
                }
            }

            this.EditValue = this.EditTag.Type.ConvertToValue(newData);
            this.EditLength = (int)nupLength.Value;
            tbxValue.Text = this.EditValue.ToString();
            hlpData.SetValue(this.EditTag.Type.ConvertToBytes(this.EditValue));*/
        }
    }
}
