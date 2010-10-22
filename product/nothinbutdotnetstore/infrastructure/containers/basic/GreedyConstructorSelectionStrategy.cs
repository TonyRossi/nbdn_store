using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class GreedyConstructorSelectionStrategy : ConstructorSelectionStrategy
    {
        public ConstructorInfo get_applicable_constructor_on(Type type)
        {
            return type.GetConstructors().OrderByDescending(c => c.GetParameters().Count()).First();
        }
    }
}