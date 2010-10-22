using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class DependencyFactoriesSpecs
    {
        public abstract class concern : Observes <DependencyFactories>
        {
        }

        [Subject(typeof(Container))]
        public class when_providing_a_factory : concern
        {
            Establish c = () =>
                              {
                                  dependency_type = typeof (int);
                              };

            private Because b = () =>
                               result = sut.get_factory_that_can_create(dependency_type);

            private It should_return_a_factory_that_can_create_the_type = () =>
                             result.type_that_can_be_created.ShouldBeOfType(dependency_type);

            static Type dependency_type;
            static DependencyFactory result;
        }
    }
}