using Autofac;

using WS.Network.Services;

namespace WS.Network
{
    /// <summary>
    /// Network module.
    /// </summary>
    public class NetworkModule : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NetworkService>().AsImplementedInterfaces().SingleInstance().PropertiesAutowired();
        }
    }
}