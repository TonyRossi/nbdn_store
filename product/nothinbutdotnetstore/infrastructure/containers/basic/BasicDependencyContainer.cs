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
            return (Dependency) dependency_factories.get_factory_that_can_create(typeof(Dependency)).create();
        }
    }
}