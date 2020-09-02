namespace WS.Shared.Countries
{
    /// <summary>
    /// World country.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Constructor for <see cref="Country"/>.
        /// </summary>
        public Country(string name, string flagCode)
        {
            Name = name;
            FlagCode = flagCode;
        }

        /// <summary>
        /// Country name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Flag unicode code.
        /// </summary>
        public string FlagCode { get; }
    }
}