using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.web.core;

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

            throw new NotImplementedException();
        }
    }
}