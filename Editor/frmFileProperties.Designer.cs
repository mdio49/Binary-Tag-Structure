namespace BinaryTagEditor
{
    partial class frmFileProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileProperties));
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.tbpCompression = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbpEncryption = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEncryption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbrPrivateKey = new System.Windows.Forms.TrackBar();
            this.tbxPrivateKey = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnPrivateKey = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxPublicKey = new System.Windows.Forms.CheckBox();
            this.tbxPublicKey = new System.Windows.Forms.TextBox();
            this.btnPublicKey = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbpPassword = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbcMain.SuspendLayout();
            this.tbpEncryption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrPrivateKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tbpPassword.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpGeneral);
            this.tbcMain.Controls.Add(this.tbpCompression);
            this.tbcMain.Controls.Add(this.tbpPassword);
            this.tbcMain.Controls.Add(this.tbpEncryption);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(434, 260);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(426, 222);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // tbpCompression
            // 
            this.tbpCompression.Location = new System.Drawing.Point(4, 22);
            this.tbpCompression.Name = "tbpCompression";
            this.tbpCompression.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCompression.Size = new System.Drawing.Size(426, 222);
            this.tbpCompression.TabIndex = 1;
            this.tbpCompression.Text = "Compression";
            this.tbpCompression.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(347, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(185, 266);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // tbpEncryption
            // 
            this.tbpEncryption.Controls.Add(this.groupBox2);
            this.tbpEncryption.Controls.Add(this.groupBox1);
            this.tbpEncryption.Controls.Add(this.cbxEncryption);
            this.tbpEncryption.Controls.Add(this.label1);
            this.tbpEncryption.Location = new System.Drawing.Point(4, 22);
            this.tbpEncryption.Name = "tbpEncryption";
            this.tbpEncryption.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEncryption.Size = new System.Drawing.Size(426, 234);
            this.tbpEncryption.TabIndex = 2;
            this.tbpEncryption.Text = "Encryption";
            this.tbpEncryption.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encryption protects files, making them unreadable without the key.";
            // 
            // cbxEncryption
            // 
            this.cbxEncryption.AutoSize = true;
            this.cbxEncryption.Location = new System.Drawing.Point(8, 6);
            this.cbxEncryption.Name = "cbxEncryption";
            this.cbxEncryption.Size = new System.Drawing.Size(109, 17);
            this.cbxEncryption.TabIndex = 1;
            this.cbxEncryption.Text = "Enable Encyption";
            this.cbxEncryption.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPrivateKey);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.tbxPrivateKey);
            this.groupBox1.Controls.Add(this.tbrPrivateKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Private Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Key Strength:";
            // 
            // tbrPrivateKey
            // 
            this.tbrPrivateKey.AutoSize = false;
            this.tbrPrivateKey.BackColor = System.Drawing.SystemColors.Window;
            this.tbrPrivateKey.Location = new System.Drawing.Point(83, 19);
            this.tbrPrivateKey.Name = "tbrPrivateKey";
            this.tbrPrivateKey.Size = new System.Drawing.Size(251, 26);
            this.tbrPrivateKey.TabIndex = 1;
            // 
            // tbxPrivateKey
            // 
            this.tbxPrivateKey.Location = new System.Drawing.Point(6, 51);
            this.tbxPrivateKey.Name = "tbxPrivateKey";
            this.tbxPrivateKey.Size = new System.Drawing.Size(317, 20);
            this.tbxPrivateKey.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(340, 23);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // btnPrivateKey
            // 
            this.btnPrivateKey.Location = new System.Drawing.Point(329, 49);
            this.btnPrivateKey.Name = "btnPrivateKey";
            this.btnPrivateKey.Size = new System.Drawing.Size(75, 23);
            this.btnPrivateKey.TabIndex = 4;
            this.btnPrivateKey.Text = "Generate";
            this.btnPrivateKey.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnPublicKey);
            this.groupBox2.Controls.Add(this.tbxPublicKey);
            this.groupBox2.Controls.Add(this.cbxPublicKey);
            this.groupBox2.Location = new System.Drawing.Point(8, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Public Key";
            // 
            // cbxPublicKey
            // 
            this.cbxPublicKey.AutoSize = true;
            this.cbxPublicKey.Location = new System.Drawing.Point(6, 19);
            this.cbxPublicKey.Name = "cbxPublicKey";
            this.cbxPublicKey.Size = new System.Drawing.Size(151, 17);
            this.cbxPublicKey.TabIndex = 0;
            this.cbxPublicKey.Text = "Use Public Key Encryption";
            this.cbxPublicKey.UseVisualStyleBackColor = true;
            // 
            // tbxPublicKey
            // 
            this.tbxPublicKey.Location = new System.Drawing.Point(6, 42);
            this.tbxPublicKey.Name = "tbxPublicKey";
            this.tbxPublicKey.Size = new System.Drawing.Size(317, 20);
            this.tbxPublicKey.TabIndex = 5;
            // 
            // btnPublicKey
            // 
            this.btnPublicKey.Location = new System.Drawing.Point(329, 40);
            this.btnPublicKey.Name = "btnPublicKey";
            this.btnPublicKey.Size = new System.Drawing.Size(75, 23);
            this.btnPublicKey.TabIndex = 5;
            this.btnPublicKey.Text = "Generate";
            this.btnPublicKey.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "bit";
            // 
            // tbpPassword
            // 
            this.tbpPassword.Controls.Add(this.textBox1);
            this.tbpPassword.Controls.Add(this.label8);
            this.tbpPassword.Controls.Add(this.groupBox3);
            this.tbpPassword.Controls.Add(this.label6);
            this.tbpPassword.Controls.Add(this.checkBox1);
            this.tbpPassword.Location = new System.Drawing.Point(4, 22);
            this.tbpPassword.Name = "tbpPassword";
            this.tbpPassword.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPassword.Size = new System.Drawing.Size(426, 234);
            this.tbpPassword.TabIndex = 3;
            this.tbpPassword.Text = "Permissions";
            this.tbpPassword.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(388, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "This key is used to unlock the file, and lock it if Public Key Encryption is disa" +
    "bled.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "If Public Key Encryption is enabled, then a different key is used to lock the fil" +
    "e.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(415, 39);
            this.label6.TabIndex = 1;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox4);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(8, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 134);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permissions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Password:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable Permissions";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Full Access:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Block",
            "Block for Users",
            "Block for Third-Party Applications",
            "Allow"});
            this.comboBox1.Location = new System.Drawing.Point(202, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Block",
            "Block for Users",
            "Block for Third-Party Applications",
            "Allow"});
            this.comboBox2.Location = new System.Drawing.Point(202, 46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Edit Access:";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Block",
            "Block for Users",
            "Block for Third-Party Applications",
            "Allow"});
            this.comboBox3.Location = new System.Drawing.Point(202, 73);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(200, 21);
            this.comboBox3.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Write Access:";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Block",
            "Block for Users",
            "Block for Third-Party Applications",
            "Allow"});
            this.comboBox4.Location = new System.Drawing.Point(202, 100);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(200, 21);
            this.comboBox4.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Read Access:";
            // 
            // frmFileProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 301);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Structure Properties";
            this.tbcMain.ResumeLayout(false);
            this.tbpEncryption.ResumeLayout(false);
            this.tbpEncryption.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrPrivateKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbpPassword.ResumeLayout(false);
            this.tbpPassword.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCompression;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabPage tbpEncryption;
        private System.Windows.Forms.CheckBox cbxEncryption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPublicKey;
        private System.Windows.Forms.TextBox tbxPublicKey;
        private System.Windows.Forms.CheckBox cbxPublicKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrivateKey;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox tbxPrivateKey;
        private System.Windows.Forms.TrackBar tbrPrivateKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbpPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
    }
}