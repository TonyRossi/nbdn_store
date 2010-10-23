using System;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutomaticDependencyFactory : DependencyFactory
    {
        public DependencyContainer dependency_container;
        public ConstructorSelectionStrategy constructor_selection_strategy;
        public Type type;

        public AutomaticDependencyFactory(DependencyContainer dependency_container,
                                          ConstructorSelectionStrategy constructor_selection_strategy, Type type)
        {
            this.dependency_container = dependency_container;
            this.constructor_selection_strategy = constructor_selection_strategy;
            this.type = type;
        }

        public object create()
        {
            var dependencies = constructor_selection_strategy.get_applicable_constructor_on(type)
                .GetParameters().Select(info => dependency_container.an(info.ParameterType)).ToArray();

            return constructor_selection_strategy.get_applicable_constructor_on(type)
                .Invoke(dependencies);
        }
    }
}