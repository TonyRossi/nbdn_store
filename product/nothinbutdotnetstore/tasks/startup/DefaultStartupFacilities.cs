using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupFacilities : StartupFacilities
    {
        IDictionary<Type, DependencyFactory> factories;
        DependencyContainer dependency_container;

        public DefaultStartupFacilities(IDictionary<Type, DependencyFactory> factories, DependencyContainer dependency_container)
        {
            this.factories = factories;
            this.dependency_container = dependency_container;
        }

        public void register<Contract, Implementation>()
        {
            factories.Add(typeof(Contract),new AutomaticDependencyFactory(dependency_container, 
                new GreedyConstructorSelectionStrategy(),typeof(Implementation)));
        }

        public void register<Contract>(Contract instance)
        {
            factories.Add(typeof(Contract),new BasicDependencyFactory(() => instance));
        }

        public IDictionary<Type, DependencyFactory> original_factories
        {
            get {return factories;}
        }
    }
}