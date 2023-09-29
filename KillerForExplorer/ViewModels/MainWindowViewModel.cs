using KillerForExplorer.Models;

namespace KillerForExplorer.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _buttonText;
        private RelayCommand _killerExplorerCommand;
        private RelayCommand _startExplorerCommand;

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                NotifyPropertyChanged(nameof(ButtonText));
            }
        }

        public RelayCommand KillerExplorerCommand
            => _killerExplorerCommand ?? (_killerExplorerCommand = new RelayCommand(() =>
            {

            }));

        public RelayCommand StartExplorerCommand
            => _killerExplorerCommand ?? (_startExplorerCommand = new RelayCommand(() =>
            {

            }));
    }
}
