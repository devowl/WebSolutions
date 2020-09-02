using System;
using System.Threading.Tasks;

using WS.Shared.Countries;

namespace WS.Shared.Network
{
    /// <summary>
    /// VPN network service.
    /// </summary>
    public interface INetworkService
    {
        /// <summary>
        /// Connection status.
        /// </summary>
        ConnectionStatus Status { get; }

        /// <summary>
        /// Connection country.
        /// </summary>
        Country CurrentCountry { get; }

        /// <summary>
        /// Status changed event.
        /// </summary>
        event EventHandler<StatusChangeArgs> StatusChanged;

        /// <summary>
        /// Change user country.
        /// </summary>
        /// <param name="userCountry">User country.</param>
        void SetCountry(Country userCountry);

        /// <summary>
        /// Connect to service.
        /// </summary>
        Task Connect();

        /// <summary>
        /// Disconnect from service.
        /// </summary>
        void Disconnect();
    }
}