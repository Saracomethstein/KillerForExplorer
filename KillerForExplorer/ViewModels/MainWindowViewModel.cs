using KillerForExplorer.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace KillerForExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _buttonText;
        private RelayCommand _killerAndStartExplorerCommand;
        private RelayCommand _exitAppCommand;
        private RelayCommand _miniAppCommand;

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

        private void ExitApploication()
        {
            Process.Start(@"C:\Windows\explorer");
            Process.GetCurrentProcess().Kill();
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
