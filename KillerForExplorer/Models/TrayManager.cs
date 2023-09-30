using System;
using System.Windows.Forms;
using System.IO;
using System.Windows;

namespace KillerForExplorer.Models
{
    internal class TrayManager
    {
        private NotifyIcon notifyIcon;
        private bool isAppMinimized;
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
            notifyIcon.Visible = false;
            notifyIcon.Click += NotifyIcon_Click;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            mainWindow.WindowState = System.Windows.WindowState.Normal;
            notifyIcon.Visible = false;
            isAppMinimized = false;
        }

        private void MinimizeToTray()
        {
            mainWindow.Hide();
            notifyIcon.Visible = true;
            isAppMinimized = true;
        }

        public void ToggleTrayVisibility()
        {
            if (isAppMinimized)
            {
                mainWindow.Show();
                mainWindow.WindowState = System.Windows.WindowState.Normal;
                notifyIcon.Visible = false;
                isAppMinimized = false;
            }
            else
            {
                MinimizeToTray();
            }
        }
    }
}
