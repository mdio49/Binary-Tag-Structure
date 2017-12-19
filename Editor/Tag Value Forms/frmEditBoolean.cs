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
    public partial class frmEditBoolean : EditForm
    {
        public frmEditBoolean(Tag tag) : base(tag)
        {
            InitializeComponent();

            rbnTrue.Checked = (bool)tag.Value == true;
            rbnFalse.Checked = (bool)tag.Value == false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Apply(rbnTrue.Checked);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }
    }
}
