using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.log4net;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            var factories = new Dictionary<Type, DependencyFactory>();
            var registry = new DefaultDependencyFactories(factories);
            var the_container = new BasicDependencyContainer(registry);
            ContainerResolver resolver = () => the_container;
            Container.container_resolver = resolver;


            //playing the role of container configuration
            factories.Add(typeof(FrontController),new BasicDependencyFactory(() => new DefaultFrontController(new DefaultWebCommandRegistry(new StubSetOfCommands()))));
            factories.Add(typeof(LoggerFactory), new BasicDependencyFactory(()=> new Log4NetLoggerFactory(new Log4NetInitializationCommand())));
            factories.Add(typeof(RequestFactory), new BasicDependencyFactory(() => new StubRequestFactory()));

        }
    }
}