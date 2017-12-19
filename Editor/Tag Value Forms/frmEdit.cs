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
    public partial class frmEdit : EditForm
    {
        public frmEdit(Tag tag) : base(tag)
        {
            InitializeComponent();
            hlpMain.SetValue(this.EditTag.Type.ConvertToBytes(this.EditTag.Value));
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply(this.EditTag.Type.ConvertToValue(hlpMain.GetValue()));
        }
    }
}
