using System;
using System.Threading;

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
        public ConnectionStatus Status { get; }

        /// <inheritdoc/>
        public void Connect()
        {
            Thread.Sleep(5000);
        }

        /// <inheritdoc/>
        public void Disconnect()
        {

        }
    }
}