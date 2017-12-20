namespace BinaryTagEditor
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnu_file = new System.Windows.Forms.MenuItem();
            this.mnuFileNew = new System.Windows.Forms.MenuItem();
            this.mnuFileOpen = new System.Windows.Forms.MenuItem();
            this.mnuFileSave = new System.Windows.Forms.MenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mnuFileExit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.mnuStructure = new System.Windows.Forms.MenuItem();
            this.mnuStructureProperties = new System.Windows.Forms.MenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbcPages = new System.Windows.Forms.TabControl();
            this.tbpFile1 = new System.Windows.Forms.TabPage();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.ctxTag = new System.Windows.Forms.ContextMenu();
            this.ctxTagAdd = new System.Windows.Forms.MenuItem();
            this.ctxTagAddNew = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.ctxTagAddCompound = new System.Windows.Forms.MenuItem();
            this.ctxTagAddList = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.ctxTagAddByte = new System.Windows.Forms.MenuItem();
            this.ctxTagAddInteger = new System.Windows.Forms.MenuItem();
            this.ctxTagAddString = new System.Windows.Forms.MenuItem();
            this.ctxTagAddFloat = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.ctxTagRename = new System.Windows.Forms.MenuItem();
            this.ctxTagModify = new System.Windows.Forms.MenuItem();
            this.ctxTagDelete = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.ctxTagProperties = new System.Windows.Forms.MenuItem();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.tvwMain = new Controls.TreeView();
            this.toolStrip1.SuspendLayout();
            this.tbcPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnu_file,
            this.menuItem1,
            this.menuItem14,
            this.menuItem13,
            this.mnuStructure});
            // 
            // mnu_file
            // 
            this.mnu_file.Index = 0;
            this.mnu_file.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.menuItem6,
            this.mnuFileExit});
            this.mnu_file.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Index = 0;
            this.mnuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnuFileNew.Text = "&New";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Index = 1;
            this.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Index = 2;
            this.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Index = 3;
            this.mnuFileSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.mnuFileSaveAs.Text = "Save &As";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Index = 5;
            this.mnuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.mnuFileExit.Text = "&Exit";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12,
            this.menuItem15,
            this.menuItem16});
            this.menuItem1.Text = "&Edit";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "&Undo";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "&Redo";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.Text = "Cu&t";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.Text = "&Copy";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 5;
            this.menuItem12.Text = "&Paste";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 6;
            this.menuItem15.Text = "-";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 7;
            this.menuItem16.Text = "Insert";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 2;
            this.menuItem14.Text = "&Search";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "&View";
            // 
            // mnuStructure
            // 
            this.mnuStructure.Index = 4;
            this.mnuStructure.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuStructureProperties});
            this.mnuStructure.Text = "&Structure";
            // 
            // mnuStructureProperties
            // 
            this.mnuStructureProperties.Index = 0;
            this.mnuStructureProperties.Text = "&Properties";
            this.mnuStructureProperties.Click += new System.EventHandler(this.mnuStructureProperties_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbcPages
            // 
            this.tbcPages.Controls.Add(this.tbpFile1);
            this.tbcPages.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcPages.Location = new System.Drawing.Point(0, 25);
            this.tbcPages.Name = "tbcPages";
            this.tbcPages.SelectedIndex = 0;
            this.tbcPages.Size = new System.Drawing.Size(624, 21);
            this.tbcPages.TabIndex = 3;
            // 
            // tbpFile1
            // 
            this.tbpFile1.Location = new System.Drawing.Point(4, 22);
            this.tbpFile1.Name = "tbpFile1";
            this.tbpFile1.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFile1.Size = new System.Drawing.Size(616, 0);
            this.tbpFile1.TabIndex = 0;
            this.tbpFile1.Text = "Open File";
            this.tbpFile1.UseVisualStyleBackColor = true;
            // 
            // ctxTag
            // 
            this.ctxTag.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxTagAdd,
            this.menuItem5,
            this.ctxTagRename,
            this.ctxTagModify,
            this.ctxTagDelete,
            this.menuItem7,
            this.ctxTagProperties});
            this.ctxTag.Popup += new System.EventHandler(this.ctxTag_Popup);
            // 
            // ctxTagAdd
            // 
            this.ctxTagAdd.Index = 0;
            this.ctxTagAdd.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxTagAddNew,
            this.menuItem3,
            this.ctxTagAddCompound,
            this.ctxTagAddList,
            this.menuItem2,
            this.ctxTagAddByte,
            this.ctxTagAddInteger,
            this.ctxTagAddString,
            this.ctxTagAddFloat});
            this.ctxTagAdd.Text = "&Add";
            // 
            // ctxTagAddNew
            // 
            this.ctxTagAddNew.Index = 0;
            this.ctxTagAddNew.Text = "&New Tag...";
            this.ctxTagAddNew.Click += new System.EventHandler(this.ctxTagAddNew_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // ctxTagAddCompound
            // 
            this.ctxTagAddCompound.Index = 2;
            this.ctxTagAddCompound.Text = "&Compound Tag";
            this.ctxTagAddCompound.Click += new System.EventHandler(this.ctxTagAddCompound_Click);
            // 
            // ctxTagAddList
            // 
            this.ctxTagAddList.Index = 3;
            this.ctxTagAddList.Text = "&List Tag";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "-";
            // 
            // ctxTagAddByte
            // 
            this.ctxTagAddByte.Index = 5;
            this.ctxTagAddByte.Text = "&Byte Tag";
            // 
            // ctxTagAddInteger
            // 
            this.ctxTagAddInteger.Index = 6;
            this.ctxTagAddInteger.Text = "&Integer Tag";
            // 
            // ctxTagAddString
            // 
            this.ctxTagAddString.Index = 7;
            this.ctxTagAddString.Text = "&String Tag";
            // 
            // ctxTagAddFloat
            // 
            this.ctxTagAddFloat.Index = 8;
            this.ctxTagAddFloat.Text = "&Float Tag";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // ctxTagRename
            // 
            this.ctxTagRename.Index = 2;
            this.ctxTagRename.Text = "&Rename Tag";
            this.ctxTagRename.Click += new System.EventHandler(this.ctxTagRename_Click);
            // 
            // ctxTagModify
            // 
            this.ctxTagModify.Index = 3;
            this.ctxTagModify.Text = "&Modify Tag";
            this.ctxTagModify.Click += new System.EventHandler(this.ctxTagModify_Click);
            // 
            // ctxTagDelete
            // 
            this.ctxTagDelete.Index = 4;
            this.ctxTagDelete.Text = "&Delete Tag";
            this.ctxTagDelete.Click += new System.EventHandler(this.ctxTagDelete_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "-";
            // 
            // ctxTagProperties
            // 
            this.ctxTagProperties.Index = 6;
            this.ctxTagProperties.Text = "&Tag Properties...";
            this.ctxTagProperties.Click += new System.EventHandler(this.ctxTagProperties_Click);
            // 
            // tvwMain
            // 
            this.tvwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwMain.Location = new System.Drawing.Point(0, 46);
            this.tvwMain.Name = "tvwMain";
            this.tvwMain.Size = new System.Drawing.Size(624, 372);
            this.tvwMain.TabIndex = 4;
            this.tvwMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwMain_MouseClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 440);
            this.Controls.Add(this.tvwMain);
            this.Controls.Add(this.tbcPages);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(639, 479);
            this.Name = "frmMain";
            this.Text = "Binary Tag Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbcPages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnu_file;
        private System.Windows.Forms.MenuItem mnuFileNew;
        private System.Windows.Forms.MenuItem mnuFileOpen;
        private System.Windows.Forms.MenuItem mnuFileSave;
        private System.Windows.Forms.MenuItem mnuFileSaveAs;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem mnuFileExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tbpFile1;
        private Controls.TreeView tvwMain;
        private System.Windows.Forms.TabControl tbcPages;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.ContextMenu ctxTag;
        private System.Windows.Forms.MenuItem ctxTagAdd;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem ctxTagRename;
        private System.Windows.Forms.MenuItem ctxTagModify;
        private System.Windows.Forms.MenuItem ctxTagDelete;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem ctxTagProperties;
        private System.Windows.Forms.MenuItem ctxTagAddCompound;
        private System.Windows.Forms.MenuItem ctxTagAddList;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem ctxTagAddByte;
        private System.Windows.Forms.MenuItem ctxTagAddInteger;
        private System.Windows.Forms.MenuItem ctxTagAddString;
        private System.Windows.Forms.MenuItem ctxTagAddFloat;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.MenuItem ctxTagAddNew;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem mnuStructure;
        private System.Windows.Forms.MenuItem mnuStructureProperties;
    }
}

