using System;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

using WS.Presentation.Interface.Windows;
using WS.Shared.Countries;
using WS.Shared.Logger;
using WS.Shared.Network;

namespace WS.Presentation.Interface.ViewModels
{
    /// <summary>
    /// Login view model.
    /// </summary>
    public class LoginViewModel : BindableBase
    {
        private Country _selectedCountry;

        /// <summary>
        /// Constructor for <see cref="LoginViewModel"/>.
        /// </summary>
        public LoginViewModel(INetworkService networkService)
        {
            NetworkService = networkService;
            NetworkService.StatusChanged += ConnectionStatusChanged;
            Connect = new DelegateCommand(async () => await ConnectHandler(), CanConnect);
            ChooseCountry = new DelegateCommand(ChooseCountryHandler);
        }

        /// <summary>
        /// Connect button command.
        /// </summary>
        public DelegateCommand Connect { get; }

        /// <summary>
        /// Choose country command.
        /// </summary>
        public DelegateCommand ChooseCountry { get; }

        /// <summary>
        /// Application logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Country window factory.
        /// </summary>
        public Func<ChooseCountryWindow> CountryWindowFactory { get; set; }

        /// <summary>
        /// Network service.
        /// </summary>
        public INetworkService NetworkService { get; }

        /// <summary>
        /// Selected country.
        /// </summary>
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(() => SelectedCountry);
            }
        }

        private void ConnectionStatusChanged(object sender, EventArgs e)
        {
            Connect.RaiseCanExecuteChanged();
            OnPropertyChanged(() => NetworkService);
        }

        private bool CanConnect()
        {
            var status = NetworkService.Status;
            return status == ConnectionStatus.Disconnected || status == ConnectionStatus.None;
        }

        private void ChooseCountryHandler()
        {
            var window = CountryWindowFactory();
            window.Owner = Application.Current.MainWindow;
            var result = window.ShowDialog();
            if (result == true)
            {
                OnPropertyChanged(() => NetworkService);
            }
        }

        private async Task ConnectHandler()
        {
            Logger.Info($"Connecting to server");
            await NetworkService.Connect();
        }
    }
}