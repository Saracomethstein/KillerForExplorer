using KillerForExplorer.Models;
using System;
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

        public RelayCommand KillerAndStartExplorerCommand
            => _killerAndStartExplorerCommand ?? (_killerAndStartExplorerCommand = new RelayCommand(() =>
            {
                ButtonText = "Off!";
                switch (ButtonText)
                {
                    case "Off!":
                        KillerExplorer();
                        break;
                    case "On!":
                        StartExplorer();
                        break;
                }
            }));

        #region Command
        private void KillerExplorer()
        {
            Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
        }

        private void StartExplorer()
        {
            try
            {
                Process.Start("explorer.exe");
                Console.WriteLine("Explorer is running.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting Explorer: {ex.Message}");
            }
        }
        #endregion
    }
}
