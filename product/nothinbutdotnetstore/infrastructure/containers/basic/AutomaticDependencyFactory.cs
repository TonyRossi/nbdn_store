using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutomaticDependencyFactory : DependencyFactory
    {
        private readonly DependencyContainer _dependencyContainer;
        private readonly ConstructorSelectionStrategy _constructorSelectionStrategy;
        private readonly Type _type;

        public AutomaticDependencyFactory(DependencyContainer dependencyContainer, ConstructorSelectionStrategy constructorSelectionStrategy, Type type)
        {
            _dependencyContainer = dependencyContainer;
            _constructorSelectionStrategy = constructorSelectionStrategy;
            _type = type;
        }

        public object create()
        {
            return _constructorSelectionStrategy.get_applicable_constructor_on(_type)
                .Invoke(_constructorSelectionStrategy.get_applicable_constructor_on(_type)
                .GetParameters().Select(info => _dependencyContainer.an(info.ParameterType)).ToArray());
        }
    }
}