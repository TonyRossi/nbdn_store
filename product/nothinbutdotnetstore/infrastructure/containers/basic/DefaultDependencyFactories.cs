using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultDependencyFactories : DependencyFactories
    {
        IDictionary<Type,DependencyFactory> factories;

        public DefaultDependencyFactories(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public DependencyFactory get_factory_that_can_create(Type dependency_type)
        {
            try
            {
                return factories[dependency_type];
            }
            catch (KeyNotFoundException e)
            {
                return new MissingDependencyFactory(dependency_type);
            }
        }
    }
}