using System;
using System.Windows.Forms;
using System.IO;

namespace KillerForExplorer.Models
{
    internal class TrayManager
    {
        private NotifyIcon notifyIcon;
        private MainWindow mainWindow;

        public TrayManager(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/gun.ico")).Stream;
            notifyIcon.Icon = new System.Drawing.Icon(iconStream);
            notifyIcon.Visible = true;
            notifyIcon.Click += NotifyIcon_Click;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            mainWindow.WindowState = System.Windows.WindowState.Normal;
        }

        public void MinimizeToTray()
        {
            mainWindow.Hide();
        }
    }
}
