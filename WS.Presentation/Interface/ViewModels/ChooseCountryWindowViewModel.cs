using System;
using System.Collections.Generic;

using Microsoft.Practices.Prism.Commands;

using WS.Shared.Countries;
using WS.Shared.Network;

namespace WS.Presentation.Interface.ViewModels
{
    /// <summary>
    /// Choose country view model.
    /// </summary>
    public class ChooseCountryWindowViewModel
    {
        private readonly Action _closeWindow;

        private Country _selectedCountry;

        /// <summary>
        /// Constructor for <see cref="ChooseCountryWindowViewModel"/>.
        /// </summary>
        public ChooseCountryWindowViewModel(Action closeWindow, ICountryProvider countryProvider)
        {
            _closeWindow = closeWindow;
            AllCountries = countryProvider.GetCountries();
            AcceptChoose = new DelegateCommand(AcceptHandler, CanAcceptChoose);
        }

        private void AcceptHandler()
        {
            NetworkService.SetCountry(SelectedCountry);
            _closeWindow();
        }

        /// <summary>
        /// Network service.
        /// </summary>
        public INetworkService NetworkService { get; set; }

        /// <summary>
        /// Available countries.
        /// </summary>
        public IEnumerable<Country> AllCountries { get; }

        /// <summary>
        /// Selected country.
        /// </summary>
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                SelectionChanged();
            }
        }

        /// <summary>
        /// Accept country choose.
        /// </summary>
        public DelegateCommand AcceptChoose { get; }

        private void SelectionChanged()
        {
            AcceptChoose.RaiseCanExecuteChanged();
        }

        private bool CanAcceptChoose()
        {
            return _selectedCountry != null;
        }
    }
}