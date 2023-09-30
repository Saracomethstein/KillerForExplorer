using KillerForExplorer.Models;
using System;
using System.Diagnostics;
using System.Windows;

namespace KillerForExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _buttonText;
        private RelayCommand _killerAndStartExplorerCommand;
        private RelayCommand _exitAppCommand;
        private RelayCommand _miniAppCommand;
        private RelayCommand _miniToTrayCommand;

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                NotifyPropertyChanged(nameof(ButtonText));
            }
        }

        public MainWindowViewModel()
        {
            ButtonText = "Off!";
        }

        #region Command
        public RelayCommand KillerAndStartExplorerCommand
            => _killerAndStartExplorerCommand ?? (_killerAndStartExplorerCommand = new RelayCommand(() =>
            {
                StartOrKill();
            }));

        public RelayCommand ExitAppCommand
            => _exitAppCommand ?? (_exitAppCommand = new RelayCommand(() =>
            {
                ExitApploication();
            }));

        public RelayCommand MiniAppCommand
            => _miniAppCommand ?? (_miniAppCommand = new RelayCommand(() =>
            {
                MiniApplication();
            }));

        public RelayCommand MiniToTrayCommand
            => _miniToTrayCommand ?? (_miniToTrayCommand = new RelayCommand(() =>
            {
                MiniToTray();
            }));
        #endregion

        private void StartOrKill()
        {
            switch (ButtonText)
            {
                case "Off!":
                    KillerExplorer();
                    ButtonText = "On!";
                    break;
                case "On!":
                    StartExplorer();
                    ButtonText = "Off!";
                    break;
            }
        }

        private void MiniToTray()
        {
            TrayManager trayManager = new TrayManager(Application.Current.MainWindow as MainWindow);
            if(trayManager != null)
            {
                trayManager.MinimizeToTray();
            }
        }

        private void ExitApploication()
        {
            string processName = "explorer";

            if (IsProcessRunning(processName) == false)
            {
                StartProcess();
            }
            Process.GetCurrentProcess().Kill();
        }

        private bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        private void StartProcess()
        {
            try
            {
                Process.Start(@"C:\Windows\explorer");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске процесса: {ex.Message}");
            }
        }

        private void MiniApplication()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void KillerExplorer()
        {
            Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
        }

        private void StartExplorer()
        {
            Process.Start(@"C:\Windows\explorer");
        }
    }
}
