namespace BinaryTagEditor
{
    partial class frmEditBoolean
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbnTrue = new System.Windows.Forms.RadioButton();
            this.rbnFalse = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbnTrue
            // 
            this.rbnTrue.AutoSize = true;
            this.rbnTrue.Location = new System.Drawing.Point(12, 12);
            this.rbnTrue.Name = "rbnTrue";
            this.rbnTrue.Size = new System.Drawing.Size(47, 17);
            this.rbnTrue.TabIndex = 0;
            this.rbnTrue.TabStop = true;
            this.rbnTrue.Text = "True";
            this.rbnTrue.UseVisualStyleBackColor = true;
            // 
            // rbnFalse
            // 
            this.rbnFalse.AutoSize = true;
            this.rbnFalse.Location = new System.Drawing.Point(112, 12);
            this.rbnFalse.Name = "rbnFalse";
            this.rbnFalse.Size = new System.Drawing.Size(50, 17);
            this.rbnFalse.TabIndex = 1;
            this.rbnFalse.TabStop = true;
            this.rbnFalse.Text = "False";
            this.rbnFalse.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(66, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(147, 38);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmEditBoolean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 73);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.rbnFalse);
            this.Controls.Add(this.rbnTrue);
            this.Name = "frmEditBoolean";
            this.Text = "frmEditBoolean";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnTrue;
        private System.Windows.Forms.RadioButton rbnFalse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}