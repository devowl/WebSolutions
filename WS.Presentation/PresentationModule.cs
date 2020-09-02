using Autofac;

using WS.Presentation.Prism;
using WS.Shared.Autofac;

namespace WS.Presentation
{
    /// <summary>
    /// Presentation assembly module.
    /// </summary>
    public class PresentationModule : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.ModuleViewRegistration();
            builder.RegisterType<LocalNavigator>().SingleInstance();
        }
    }
}
