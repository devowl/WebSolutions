using System;
using System.Threading.Tasks;

using WS.Shared.Countries;
using WS.Shared.Network;

namespace WS.Network.Services
{
    /// <summary>
    /// Network service implementation.
    /// </summary>
    internal class NetworkService : INetworkService
    {
        /// <summary>
        /// Constructor for <see cref="NetworkService"/>.
        /// </summary>
        public NetworkService()
        {
            Status = ConnectionStatus.None;
        }

        /// <inheritdoc/>
        public event EventHandler<StatusChangeArgs> StatusChanged;

        /// <inheritdoc/>
        public ConnectionStatus Status { get; private set; }

        /// <summary>
        /// User country.
        /// </summary>
        public Country CurrentCountry { get; private set; }

        /// <inheritdoc/>
        public void SetCountry(Country userCountry)
        {
            CurrentCountry = userCountry;
        }

        /// <inheritdoc/>
        public async Task Connect()
        {
            ChangeStatus(ConnectionStatus.Connecting);
            await Task.Delay(5000);
            ChangeStatus(ConnectionStatus.Disconnected);
        }

        /// <inheritdoc/>
        public void Disconnect()
        {
        }

        private void ChangeStatus(ConnectionStatus status)
        {
            Status = status;
            StatusChanged?.Invoke(this, new StatusChangeArgs(status));
        }
    }
}