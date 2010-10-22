using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        IDictionary<Type, DependencyFactory> factories;

        public ConfigureFrontController(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public void run()
        {
            factories.Add(typeof(FrontController), new BasicDependencyFactory(() =>
                                                                                  new DefaultFrontController(
                                                                                  new DefaultWebCommandRegistry(
                                                                                      new StubSetOfCommands()))));

            factories.Add(typeof(RequestFactory), new BasicDependencyFactory(() =>
                                                                                 new StubRequestFactory()));
        }
    }
}