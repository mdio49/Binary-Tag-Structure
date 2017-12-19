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
    public partial class frmEditInteger : EditForm
    {
        public frmEditInteger(Tag tag) : base(tag)
        {
            InitializeComponent();

            nupValue.Minimum = int.MinValue;
            nupValue.Maximum = int.MaxValue;

            nupValue.Value = (int)tag.Value;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Apply((int)nupValue.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }
    }
}
