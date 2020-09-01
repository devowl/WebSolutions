using Autofac;

using WS.Shared.Autofac;

namespace WS.Application
{
    /// <summary>
    /// Application module.
    /// </summary>
    public class ApplicationModule : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.ModuleViewRegistration();
        }
    }
}
