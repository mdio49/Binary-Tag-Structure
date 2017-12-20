using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class HexadecimalLayoutPanel : FlowLayoutPanel
    {
        public event EventHandler TextChanged;

        public bool ReadOnly { get; set; }

        private TextBox selectedBox = null;

        public HexadecimalLayoutPanel()
        {
            InitializeComponent();

            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.ReadOnly = false;
        }

        public void AddBox(byte value)
        {
            TextBox tbx_hex = new TextBox
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                CharacterCasing = CharacterCasing.Upper,
                MaxLength = 2,
                ReadOnly = true,              
                Size = new Size(20, 20),
                TabStop = false,
                Text = BitConverter.ToString(new byte[]{ value }, 0),
                TextAlign = HorizontalAlignment.Center
            };

            tbx_hex.LostFocus += tbx_hex_LostFocus;
            tbx_hex.KeyDown += tbx_hex_KeyDown;
            tbx_hex.KeyPress += tbx_hex_KeyPress;
            tbx_hex.MouseClick += tbx_hex_MouseClick;
            tbx_hex.TextChanged += tbx_hex_TextChanged;
            tbx_hex.TextChanged += this.TextChanged;

            this.Controls.Add(tbx_hex);
        }

        public void SetValue(byte[] value)
        {
            this.Controls.Clear();

            foreach (byte b in value)
            {
                this.AddBox(b);
            }
        }

        public byte[] GetValue()
        {
            byte[] bytes = new byte[this.Controls.Count];

            for (int i = 0; i < bytes.Length; i++)
            {
                TextBox tbx = (TextBox)this.Controls[i];
                bytes[i] = Convert.ToByte(tbx.Text, 16);
            }

            return bytes;
        }

        private void SetSelected(TextBox box)
        {
            foreach (TextBox tbx in this.Controls)
            {
                tbx.BackColor = Color.White;
                tbx.ForeColor = Color.Black;
                tbx.ReadOnly = true;
            }

            if (box != null)
            {
                box.BackColor = Color.Black;
                box.ForeColor = Color.White;
                box.ReadOnly = this.ReadOnly;

                selectedBox = box;
            }
            else
            {
                this.Focus();

                selectedBox = null;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (TextBox box in this.Controls)
                {
                    box.DeselectAll();
                }

                this.SetSelected(null);
            }

            base.OnMouseClick(e);
        }

        private void tbx_hex_LostFocus(object sender, EventArgs e)
        {
            this.SetSelected(null);
        }

        private void tbx_hex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                this.SetSelected(null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;

                this.Controls.Remove((TextBox)sender);
            }
        }

        private void tbx_hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '0' && e.KeyChar != '1'
                    && e.KeyChar != '2' && e.KeyChar != '3'
                    && e.KeyChar != '4' && e.KeyChar != '5'
                    && e.KeyChar != '6' && e.KeyChar != '7'
                    && e.KeyChar != '8' && e.KeyChar != '9'
                    && e.KeyChar != 'A' && e.KeyChar != 'a'
                    && e.KeyChar != 'B' && e.KeyChar != 'b'
                    && e.KeyChar != 'C' && e.KeyChar != 'c'
                    && e.KeyChar != 'D' && e.KeyChar != 'd'
                    && e.KeyChar != 'E' && e.KeyChar != 'e'
                    && e.KeyChar != 'F' && e.KeyChar != 'f')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void tbx_hex_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                box.SelectAll();

                this.SetSelected((TextBox)sender);
            }
        }

        private void tbx_hex_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (box.TextLength >= 2)
            {
                this.SetSelected(null);
            }
        }
    }
}
