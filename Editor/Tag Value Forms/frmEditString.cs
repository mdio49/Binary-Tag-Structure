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
    public partial class frmEditString : EditForm
    {
        public frmEditString(Tag tag) : base(tag)
        {
            InitializeComponent();

            tbxValue.Text = tag.Value == null ? "" : tag.Value.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Apply(tbxValue.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }
    }
}
