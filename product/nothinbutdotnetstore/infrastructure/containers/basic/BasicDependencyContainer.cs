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
            try
            {
                return (Dependency)dependency_factories.get_factory_that_can_create(typeof(Dependency)).create();
            }
            catch (Exception ex)
            {
                throw new DependencyCreationException(ex, typeof(Dependency));
            }

            
        }
    }
}