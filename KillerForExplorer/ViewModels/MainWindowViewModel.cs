using KillerForExplorer.Models;
using System.Diagnostics;

namespace KillerForExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _buttonText;
        private RelayCommand _killerAndStartExplorerCommand;

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
