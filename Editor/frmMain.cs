using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.BinaryTagStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTagEditor
{
    public partial class frmMain : Form
    {
        public void RefreshTreeview(TagCompound compound, TreeNode node)
        {
            node.Nodes.Clear();

            foreach (TagCompound tag in compound.EnumerateCompounds())
            {
                TreeNode n = new TreeNode(tag.Name, Functions.TagIcons[TagType.TagCompound], Functions.TagIcons[TagType.TagCompound]);
                node.Nodes.Add(n);
                this.RefreshTreeview(tag, n);
            }

            foreach (Tag tag in compound.EnumerateTags())
            {
                int imageIndex = Functions.TagIcons.Keys.Contains(tag.Type) ? Functions.TagIcons[tag.Type] : 0;
                TreeNode n = new TreeNode(tag.Name + ": " + (tag.Value == null ? "" : tag.Value.ToString()), imageIndex, imageIndex);
                
                if (tag.GetType().IsGenericType && tag.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(TagList<>)))
                {
                    n = new TreeNode(tag.Name, imageIndex, imageIndex);

                    dynamic list = compound.GetTag(tag.Name);
                    int itemImageIndex = Functions.TagIcons.Keys.Contains((TagType)list.ListType) ? Functions.TagIcons[list.ListType] : 0;

                    for (int i = 0; i < list.Tags.Length; i++)
                    {
                        Tag item = list.Tags[i];
                        TreeNode itemNode = new TreeNode((list.ListType == TagType.TagCompound ? i.ToString() : (i.ToString() + ": " + (item.Value == null ? "Null" : item.Value.ToString()))), itemImageIndex, itemImageIndex);
                        
                        if (list.ListType == TagType.TagCompound)
                        {
                            this.RefreshTreeview((TagCompound)item, itemNode);
                        }

                        n.Nodes.Add(itemNode);
                    }
                }

                node.Nodes.Add(n);
            }
        }

        public string GetTagPathAtNode(TreeNode n)
        {
            string path = n.FullPath.Substring(n.FullPath.IndexOf("/") + 1, n.FullPath.Length - n.FullPath.IndexOf("/") - 1);

            string path2;

            if (path.Contains(':'))
            {
                path2 = path.Substring(0, path.IndexOf(':'));
            }
            else
            {
                path2 = path;
            }

            return path2;
        }

        public Tag GetTagAtNode(TreeNode n)
        {
            return Functions.Structure.GetTag(this.GetTagPathAtNode(n));
        }

        public frmMain()
        {
            InitializeComponent();

            Functions.Initialize();

            tbpFile1.Text = "new1.bts";

            ofdMain.Filter = "Binary Tag Structures (*.bts)|*.bts|All Files|*.*";
            sfdMain.Filter = "Binary Tag Structure (*.bts)|*.bts|Data File (*.dat)|*.dat";

            Functions.TagIcons.Add(TagType.TagEnd, 1);
            Functions.TagIcons.Add(TagType.TagCompound, 2);
            Functions.TagIcons.Add(TagType.TagList, 3);
            Functions.TagIcons.Add(TagType.TagByte, 4);
            Functions.TagIcons.Add(TagType.TagByteArray, 5);
            Functions.TagIcons.Add(TagType.TagShort, 6);
            Functions.TagIcons.Add(TagType.TagInteger, 7);
            Functions.TagIcons.Add(TagType.TagLong, 8);
            Functions.TagIcons.Add(TagType.TagFloat, 9);
            Functions.TagIcons.Add(TagType.TagDouble, 10);
            Functions.TagIcons.Add(TagType.TagString, 11);

            Functions.TagForms.Add(TagType.TagBoolean, typeof(frmEditBoolean));
            Functions.TagForms.Add(TagType.TagShort, typeof(frmEditShort));
            Functions.TagForms.Add(TagType.TagInteger, typeof(frmEditInteger));
            Functions.TagForms.Add(TagType.TagLong, typeof(frmEditLong));
            Functions.TagForms.Add(TagType.TagString, typeof(frmEditString));

            tvwMain.ImageList = Functions.Icons;

            tvwMain.PathSeparator = "/";

            tvwMain.Nodes.Add("new1.bts");

            //tvwMain.ContextMenu = ctxTag;

            Functions.Structure = new BinaryTagStructure();

            Functions.Structure.AddCompound("Comp1");
            Functions.Structure.AddCompound("Comp1/Comp2");
            Functions.Structure.AddTag("Comp1/Comp2/Tag1", TagType.TagBoolean, true);
            Functions.Structure.AddTag("Comp1/Tag1", TagType.TagInteger, 15);
            Functions.Structure.AddTag("Comp1/Tag2", TagType.TagString, "Test");
            //Functions.Structure.AddList("Comp1/List1", TagType.TagInteger, 3534, 57, 7354);

            this.RefreshTreeview(Functions.Structure, tvwMain.Nodes[0]);
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                Functions.Load(ofdMain.FileName);
                this.RefreshTreeview(Functions.Structure, tvwMain.Nodes[0]);

                tbpFile1.Text = ofdMain.SafeFileName;
                tvwMain.Nodes[0].Text = ofdMain.SafeFileName;
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (Functions.Structure.Path == null)
            {
                mnuFileSaveAs_Click(sender, e);
            }
            else
            {
                Functions.Save();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdMain.ShowDialog() == DialogResult.OK)
            {
                Functions.Save(sfdMain.FileName);

                tbpFile1.Text = Path.GetFileName(sfdMain.FileName);
                tvwMain.Nodes[0].Text = Path.GetFileName(sfdMain.FileName);
            }
        }

        private void ctxTagAddCompound_Click(object sender, EventArgs e)
        {
            if (tvwMain.SelectedNode == tvwMain.Nodes[0])
            {
                int index = 1;
                string name = "newCompound";

                // Suffixes the new name with a number to prevent duplicate names.
                while (true)
                {
                    if (Functions.Structure.ContainsTag(name))
                    {
                        index++;
                        name = "newCompound_" + index.ToString();
                    }
                    else
                    {
                        break;
                    }
                }

                Functions.Structure.AddCompound(name);
                this.RefreshTreeview(Functions.Structure, tvwMain.Nodes[0]);
            }
            else
            {
                TreeNode n = tvwMain.SelectedNode;
                string path = n.FullPath.Substring(n.FullPath.IndexOf("/") + 1, n.FullPath.Length - n.FullPath.IndexOf("/") - 1);

                int index = 1;
                string name = "/newCompound";

                // Suffixes the new name with a number to prevent duplicate names.
                while (true)
                {
                    if (Functions.Structure.ContainsTag(path + name))
                    {
                        index++;
                        name = "/newCompound_" + index.ToString();
                    }
                    else
                    {
                        break;
                    }
                }

                Functions.Structure.AddCompound(path + name);
                this.RefreshTreeview((TagCompound)Functions.Structure.GetTag(path), n);
            }
        }

        private void tvwMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvwMain.SelectedNode = tvwMain.GetNodeAt(e.Location);

                if (tvwMain.SelectedNode == tvwMain.Nodes[0])
                {
                    ctxTagDelete.Enabled = false;
                    ctxTagModify.Enabled = false;
                    ctxTagProperties.Enabled = false;
                    ctxTagRename.Enabled = false;
                }
                else
                {
                    ctxTagDelete.Enabled = true;
                    ctxTagModify.Enabled = tvwMain.SelectedNode.ImageIndex == 1 ? false : true;
                    ctxTagProperties.Enabled = true;
                    ctxTagRename.Enabled = true;
                }

                ctxTag.Show(tvwMain, e.Location);
            }
        }

        private void ctxTagRename_Click(object sender, EventArgs e)
        {
            TreeNode n = tvwMain.SelectedNode;
            Tag tag = this.GetTagAtNode(n);

            if (new frmRename(tag).ShowDialog() == DialogResult.OK)
            {
                this.RefreshTreeview(tag.Parent, n.Parent);
            }
        }

        private void ctxTagModify_Click(object sender, EventArgs e)
        {
            TreeNode n = tvwMain.SelectedNode;
            Tag tag = this.GetTagAtNode(n);

            EditForm form = Functions.TagForms.Keys.Contains(tag.Type) ? (EditForm)Activator.CreateInstance(Functions.TagForms[tag.Type], tag) : new frmEdit(tag);
            form.Text = "Modify Tag Value";
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (tag.Parent != null)
                {
                    this.RefreshTreeview(tag.Parent, n.Parent);
                }
                else
                {
                    this.RefreshTreeview(Functions.Structure, tvwMain.Nodes[0]);
                }
            }
        }

        private void ctxTagDelete_Click(object sender, EventArgs e)
        {
            TreeNode n = tvwMain.SelectedNode;
            string path = this.GetTagPathAtNode(n);
            Tag tag = this.GetTagAtNode(n);

            DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this tag?", "Delete Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Functions.Structure.RemoveTag(path);
                this.RefreshTreeview(tag.Parent, n.Parent);
            }
        }

        private void ctxTagProperties_Click(object sender, EventArgs e)
        {
            TreeNode n = tvwMain.SelectedNode;
            Tag tag = this.GetTagAtNode(n);

            if (new frmTagProperties(tag).ShowDialog() == DialogResult.OK)
            {
                this.RefreshTreeview(tag.Parent, n.Parent);
            }
        }

        private void ctxTagAddNew_Click(object sender, EventArgs e)
        {
            TreeNode n = tvwMain.SelectedNode;
            TagCompound tag = (TagCompound)this.GetTagAtNode(n);

            if (new frmAddTag(tag).ShowDialog() == DialogResult.OK)
            {
                this.RefreshTreeview(tag, n);
            }
        }

        private void ctxTag_Popup(object sender, EventArgs e)
        {
            TreeNode n = tvwMain.SelectedNode;
            Tag tag = this.GetTagAtNode(n);

            if (tag.Type == TagType.TagCompound)
            {
                ctxTagAdd.Enabled = true;
                ctxTagModify.Enabled = false;
            }
            else if (tag.Type == TagType.TagList)
            {
                ctxTagAdd.Enabled = true;
                ctxTagModify.Enabled = false;
            }
            else
            {
                ctxTagAdd.Enabled = false;
                ctxTagModify.Enabled = true;
            }
        }

        private void mnuStructureProperties_Click(object sender, EventArgs e)
        {
            (new frmFileProperties()).ShowDialog();
        }
    }
}
