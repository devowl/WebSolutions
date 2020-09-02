using Autofac;

using WS.Shared.Countries;
using WS.Shared.Logger;

namespace WS.Shared
{
    /// <summary>
    /// Shared module.
    /// </summary>
    public class SharedModule : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryProvider>().AsImplementedInterfaces().SingleInstance().PropertiesAutowired();
            builder.RegisterType<AppLogger>().AsImplementedInterfaces().SingleInstance().PropertiesAutowired();
        }
    }
}