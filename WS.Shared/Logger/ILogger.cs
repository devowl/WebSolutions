using System;

namespace WS.Shared.Logger
{
    /// <summary>
    /// Application logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write info to log.
        /// </summary>
        /// <param name="text">Log text.</param>
        void Info(string text);

        /// <summary>
        /// Write warning to log.
        /// </summary>
        /// <param name="text">Log text.</param>
        void Warning(string text);

        /// <summary>
        /// Write error to log.
        /// </summary>
        /// <param name="text">Log text.</param>
        void Error(string text);

        /// <summary>
        /// Write error to log.
        /// </summary>
        /// <param name="exception">Thrown exception.</param>
        /// <param name="text">Log text.</param>
        void Error(Exception exception, string text);
    }
}