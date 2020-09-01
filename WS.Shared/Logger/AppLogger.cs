using System;

using log4net;
using log4net.Config;

namespace WS.Shared.Logger
{
    /// <summary>
    /// Logger implementation.
    /// </summary>
    internal class AppLogger : ILogger
    {
        private static readonly ILog Logger = LogManager.GetLogger("VPNLogger"); 

        static AppLogger()
        {
            XmlConfigurator.Configure();
        }

        /// <inheritdoc/>
        public void Info(string text)
        {
            Logger.Info(text);
        }

        /// <inheritdoc/>
        public void Warning(string text)
        {
            Logger.Warn(text);
        }

        /// <inheritdoc/>
        public void Error(string text)
        {
            Logger.Error(text);
        }

        /// <inheritdoc/>
        public void Error(Exception exception, string text)
        {
            Logger.Error(text, exception);
        }
    }
}