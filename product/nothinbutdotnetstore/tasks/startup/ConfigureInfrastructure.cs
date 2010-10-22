using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.log4net;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureInfrastructure : StartupCommand
    {
        IDictionary<Type, DependencyFactory> factories;

        public ConfigureInfrastructure(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public void run()
        {
            var registry = new DefaultDependencyFactories(factories);
            var the_container = new BasicDependencyContainer(registry);
            ContainerResolver resolver = () => the_container;
            Container.container_resolver = resolver;

            factories.Add(typeof(LoggerFactory), new BasicDependencyFactory(() =>
                                                                                new Log4NetLoggerFactory(
                                                                                new Log4NetInitializationCommand())));
        }
    }
}