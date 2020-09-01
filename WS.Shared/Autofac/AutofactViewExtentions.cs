using System;
using System.Collections.Generic;
using System.Reflection;

using Autofac;

namespace WS.Shared.Autofac
{
    /// <summary>
    /// Autofac view extension methods.
    /// </summary>
    public static class AutofactViewExtentions
    {
        /// <summary>
        /// Module views and view models registration.
        /// </summary>
        /// <param name="builder">Autofac builder.</param>
        public static void ModuleViewRegistration(this ContainerBuilder builder)
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var registredTypes = callingAssembly.GetTypes(); 

            RegisterKnownType(builder, registredTypes, "ViewModel");
            RegisterKnownType(builder, registredTypes, "View");
            RegisterKnownType(builder, registredTypes, "Window");
        }

        private static void RegisterKnownType(ContainerBuilder builder, IEnumerable<Type> registredTypes, string postfix)
        {
            foreach (var type in registredTypes)
            {
                if (type.Name.EndsWith(postfix))
                {
                    builder
                        .RegisterType(type)
                        .AsImplementedInterfaces()
                        .AsSelf()
                        .PropertiesAutowired();
                }
            }
        }

    }
}
