using System.Collections.Generic;

namespace WS.Shared.Countries
{
    /// <summary>
    /// Countries provider.
    /// </summary>
    public interface ICountryProvider
    {
        /// <summary>
        /// Get all available countries. 
        /// </summary>
        /// <returns>Countries roster.</returns>
        IEnumerable<Country> GetCountries();
    }
}