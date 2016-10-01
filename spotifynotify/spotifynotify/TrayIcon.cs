using System;
using System.Windows;
using System.Windows.Forms;

namespace spotifynotify
{
    /// <summary>
    /// Tray icon window
    /// </summary>
    public class TrayIcon : Window
    {
        private ContextMenu ctxMenu;
        private MenuItem menuItemExit;
        private NotifyIcon notifyIcon;

        public TrayIcon()
        {
            ctxMenu = new ContextMenu();
            menuItemExit = new MenuItem();
            menuItemExit.Index = 0;
            menuItemExit.Text = "Exit";
            menuItemExit.Click += MenuItemExit_Click;
            ctxMenu.MenuItems.AddRange(new MenuItem[] { menuItemExit });

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("Main.ico");
            notifyIcon.Visible = true;
            notifyIcon.Text = "spotifynotify";
            notifyIcon.ContextMenu = ctxMenu;
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
