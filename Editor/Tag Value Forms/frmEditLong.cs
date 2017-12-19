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
    public partial class frmEditLong : EditForm
    {
        public frmEditLong(Tag tag) : base(tag)
        {
            InitializeComponent();

            nupValue.Minimum = long.MinValue;
            nupValue.Maximum = long.MaxValue;

            nupValue.Value = (long)tag.Value;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Apply((long)nupValue.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }
    }
}
