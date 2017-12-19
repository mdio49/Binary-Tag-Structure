using System;
using System.Runtime.InteropServices;

namespace Controls
{
    /// <summary>
    /// A class containing a function to apply system themes to certain controls.
    /// </summary>
    public static class VisualThemes
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
    }

    /// <summary>
    /// A treeview with system themes applied to it.
    /// </summary>
    public class TreeView : System.Windows.Forms.TreeView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
            {
                VisualThemes.SetWindowTheme(this.Handle, "explorer", null);
            }
        }
    }

    /// <summary>
    /// A list view with system themes applied to it.
    /// </summary>
    public class ListView : System.Windows.Forms.ListView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
            {
                VisualThemes.SetWindowTheme(this.Handle, "explorer", null);
            }
        }
    }
}
