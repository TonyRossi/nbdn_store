using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.log4net;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfiguringInfrastructure : StartupCommand
    {
        StartupFacilities startup_facilities;

        public ConfiguringInfrastructure(StartupFacilities startup_facilities)
        {
            this.startup_facilities = startup_facilities;
        }

        public void run()
        {
            var registry = new DefaultDependencyFactories(startup_facilities.original_factories);
            DependencyContainer the_container = new BasicDependencyContainer(registry);
            ContainerResolver resolver = () => the_container;
            Container.container_resolver = resolver;

            startup_facilities.register(the_container);
            startup_facilities.register<LoggerFactory, Log4NetLoggerFactory>();
            startup_facilities.register<Log4NetInitializationCommand, DefaultLog4NetInitializationCommand>();
        }
    }
}