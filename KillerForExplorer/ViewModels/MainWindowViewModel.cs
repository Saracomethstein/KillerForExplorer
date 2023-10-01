using KillerForExplorer.Models;
using System;
using System.Diagnostics;
using System.Windows;

namespace KillerForExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _startStopButton;
        private string _settingsButton;
        private RelayCommand _killerAndStartExplorerCommand;
        private RelayCommand _exitAppCommand;
        private RelayCommand _miniAppCommand;
        private RelayCommand _miniToTrayCommand;

        public string StartStopButtonText
        {
            get { return _startStopButton; }
            set
            {
                _startStopButton = value;
                NotifyPropertyChanged(nameof(StartStopButtonText));
            }
        }

        public string SettingsButtonText
        {
            get { return _settingsButton; }
            set
            {
                _settingsButton = value;
                NotifyPropertyChanged(nameof(SettingsButtonText));
            }
        }

        public MainWindowViewModel()
        {
            StartStopButtonText = "▶️";
            SettingsButtonText = "⚙";
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
            switch (StartStopButtonText)
            {
                case "▶️":
                    KillerExplorer();
                    StartStopButtonText = "◼️";
                    break;
                case "◼️":
                    StartExplorer();
                    StartStopButtonText = "▶️";
                    break;
            }
        }

        private void MiniToTray()
        {
            TrayManager trayManager = new TrayManager(Application.Current.MainWindow as MainWindow);
            if(trayManager != null)
            {
                trayManager.ToggleTrayVisibility();
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
