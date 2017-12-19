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
    public partial class frmEditShort : EditForm
    {
        public frmEditShort(Tag tag) : base(tag)
        {
            InitializeComponent();

            nupValue.Minimum = short.MinValue;
            nupValue.Maximum = short.MaxValue;

            nupValue.Value = (short)tag.Value;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Apply((short)nupValue.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }
    }
}
