using System;

namespace WS.Shared.Network
{
    /// <summary>
    /// Status change arguments.
    /// </summary>
    public class StatusChangeArgs : EventArgs
    {
        /// <summary>
        /// Constructor for <see cref="StatusChangeArgs"/>.
        /// </summary>
        public StatusChangeArgs(ConnectionStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// Status value.
        /// </summary>
        public ConnectionStatus Status { get; }
    }
}