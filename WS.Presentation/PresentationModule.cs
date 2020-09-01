using Autofac;

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
        }
    }
}
