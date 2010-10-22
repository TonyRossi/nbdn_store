using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyContainer : DependencyContainer
    {
        DependencyFactories dependency_factories;

        public BasicDependencyContainer(DependencyFactories dependencyFactories)
        {
            dependency_factories = dependencyFactories;
        }

        public Dependency an<Dependency>()
        {
            return (Dependency) an(typeof (Dependency));
        }

        public object an(Type dependency_type)
        {
            try
            {
                return dependency_factories.get_factory_that_can_create(dependency_type).create();
            }
            catch (Exception ex)
            {
                throw new DependencyCreationException(ex, dependency_type);
            }
        }
    }
}