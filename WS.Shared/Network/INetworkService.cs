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
        /// Connect to service.
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnect from service.
        /// </summary>
        void Disconnect();
    }
}