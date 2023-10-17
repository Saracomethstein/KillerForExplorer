using KillerForExplorer.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace KillerForExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _startStopButton;
        private string _settingsButton;
        private string _foregroundForSet;
        private string _foregroundForStartStop;
        private string _shortcutSymbol;
        private int _actualWidth;
        private int _actualHeight;
        private RelayCommand _killerAndStartExplorerCommand;
        private RelayCommand _exitAppCommand;
        private RelayCommand _miniAppCommand;
        private RelayCommand _miniToTrayCommand;
        private RelayCommand _settingsCommand;

        #region Properties
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

        public int ActualWidth
        {
            get { return _actualWidth; }
            set
            {
                _actualWidth = value;
                NotifyPropertyChanged(nameof(ActualWidth));
            }
        }

        public int ActualHeight
        {
            get { return _actualHeight; }
            set
            {
                _actualHeight = value;
                NotifyPropertyChanged(nameof(ActualHeight));
            }
        }

        public string ForegroundForSettings
        {
            get { return _foregroundForSet; }
            set
            {
                _foregroundForSet = value;
                NotifyPropertyChanged(nameof(ForegroundForSettings));
            }
        }

        public string ForegroundForStartStop
        {
            get { return _foregroundForStartStop; }
            set
            {
                _foregroundForStartStop = value;
                NotifyPropertyChanged(nameof(ForegroundForStartStop));
            }
        }

        public string ShortcutSymbol
        {
            get { return _shortcutSymbol; }
            set
            {
                _shortcutSymbol = value;
                NotifyPropertyChanged(nameof(ShortcutSymbol));
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            StartStopButtonText = "▶";
            SettingsButtonText = "⚙";
            ForegroundForSettings = "Black";
            ForegroundForStartStop = "Green";
            ShortcutSymbol = "A";
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

        public RelayCommand SettingsCommand
            => _settingsCommand ?? (_settingsCommand = new RelayCommand(() =>
            {
                OpenOrCloseSet();
            }));
        #endregion

        private void StartOrKill()
        {
            switch (ForegroundForStartStop)
            {
                case "Green":
                    KillerExplorer();
                    StartStopButtonText = "◼️";
                    ForegroundForStartStop = "Red";

                    break;
                case "Red":
                    StartExplorer();
                    StartStopButtonText = "▶️";
                    ForegroundForStartStop = "Green";
                    break;
            }
        }

        private void OpenOrCloseSet()
        {
            switch (ForegroundForSettings)
            {
                case "Black":
                    OpenSettingsWindow();
                    ForegroundForSettings = "Blue";
                    break;
                case "Blue":
                    CloseSettingWindow();
                    ForegroundForSettings = "Black";
                    break;
            }
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
                MessageBox.Show($"Error when starting the process: {ex.Message}");
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

        #region Working with Windows

        private void MiniApplication()
        {
            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void MiniToTray()
        {
            TrayManager trayManager = new TrayManager(Application.Current.MainWindow as MainWindow);
            if (trayManager != null)
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

        private void OpenSettingsWindow()
        {
            var window = System.Windows.Application.Current.Windows[0];
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = window.ActualWidth,
                To = window.ActualWidth,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                From = window.ActualHeight,
                To = window.ActualHeight + 80,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(heightAnimation);

            Storyboard.SetTarget(widthAnimation, window);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Button.WidthProperty));

            Storyboard.SetTarget(heightAnimation, window);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Button.HeightProperty));

            storyboard.Begin();
        }

        private void CloseSettingWindow()
        {
            var window = System.Windows.Application.Current.Windows[0];
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = window.ActualWidth,
                To = window.ActualWidth,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                From = window.ActualHeight,
                To = window.ActualHeight - 80,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(heightAnimation);

            Storyboard.SetTarget(widthAnimation, window);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Button.WidthProperty));

            Storyboard.SetTarget(heightAnimation, window);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Button.HeightProperty));

            storyboard.Begin();
        }

        #endregion
    }
}
