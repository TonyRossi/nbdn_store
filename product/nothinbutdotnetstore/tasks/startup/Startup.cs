using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup : Command
    {
        public void run()
        {
            var factories = new Dictionary<Type, DependencyFactory>();
            new ConfigureInfrastructure(factories).run();
            new ConfigureFrontController(factories).run();
        }

        public static void start_the_application()
        {
            new Startup().run();
        }
    }
}