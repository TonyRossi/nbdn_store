using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyContainer : DependencyContainer
    {
        private readonly DependencyFactories _dependencyFactories;

        public BasicDependencyContainer(DependencyFactories dependencyFactories)
        {
            _dependencyFactories = dependencyFactories;
        }

        public Dependency an<Dependency>()
        {
            DependencyFactory dependencyFactory = _dependencyFactories.get_factory_that_can_create(typeof (Dependency));
            return (Dependency)dependencyFactory.create();
        }
    }
}