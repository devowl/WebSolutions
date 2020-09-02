using System.Collections.Generic;
using System.Linq;

using FamFamFam.Flags.Wpf;

namespace WS.Shared.Countries
{
    /// <summary>
    /// Countries provider.
    /// </summary>
    internal class CountryProvider : ICountryProvider
    {
        private IEnumerable<Country> _allCountries;

        /// <inheritdoc/>
        public IEnumerable<Country> GetCountries()
        {
            if (_allCountries != null)
            {
                return _allCountries;
            }

            return _allCountries = CountryData.AllCountries.Select(i => new Country(i.Name, i.Iso2));
        }
    }
}