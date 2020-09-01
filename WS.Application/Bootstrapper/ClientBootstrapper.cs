using System;
using System.Windows;

using Autofac;

using Microsoft.Practices.Prism.Logging;

using Prism.AutofacExtension;

using WS.Application.Interface.Windows;
using WS.Network;
using WS.Presentation;
using WS.Shared.Logger;

namespace WS.Application.Bootstrapper
{
    /// <summary>
    /// Client boots trapper.
    /// </summary>
    public class ClientBootstrapper : AutofacBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            SubscriptionOnUnhandledException();
            base.Run(runWithDefaultConfiguration);
        }

        /// <inheritdoc/>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <inheritdoc/>
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<NetworkModule>();
            builder.RegisterModule<PresentationModule>();
            builder.RegisterModule<ApplicationModule>();
        }

        /// <inheritdoc/>
        protected override ILoggerFacade CreateLogger()
        {
            return new TraceLogger();
        }

        /// <inheritdoc/>
        protected override void InitializeShell()
        {
            (System.Windows.Application.Current.MainWindow = Shell as Window)?.Show();
        }

        private void SubscriptionOnUnhandledException()
        {
            var domain = AppDomain.CurrentDomain;
            var application = System.Windows.Application.Current;

            domain.UnhandledException += (sender, args) => LogException(args.ExceptionObject as Exception);
            application.DispatcherUnhandledException += (sender, args) =>
                                                        {
                                                            LogException(args.Exception);
                                                            args.Handled = true;
                                                        };
        }

        private void LogException(Exception exception)
        {
            var logger = Container.Resolve<ILogger>();
            logger.Error(exception, "Unhandled exception");
            MessageBox.Show(exception.ToString(), "Unhandled exception thrown", MessageBoxButton.OK);
        }
    }
}