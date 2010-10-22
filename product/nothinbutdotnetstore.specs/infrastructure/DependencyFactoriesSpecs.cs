using System;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class DependencyFactoriesSpecs
    {
        public abstract class concern : Observes<DependencyFactories, DefaultDependencyFactories>
        {
        }

        [Subject(typeof(DefaultDependencyFactories))]
        public class when_getting_a_factory_for_a_dependency_and_it_has_the_factory : concern
        {
            Establish c = () =>
            {
                dependency_type = typeof(int);
                the_correct_factory = an<DependencyFactory>();
                factories = new Dictionary<Type, DependencyFactory>();
                factories.Add(dependency_type, the_correct_factory);

                provide_a_basic_sut_constructor_argument<IDictionary<Type, DependencyFactory>>(factories);
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(dependency_type);

            It should_return_a_factory_that_can_create_the_type = () =>
                result.ShouldEqual(the_correct_factory);

            static Type dependency_type;
            static DependencyFactory result;
            static DependencyFactory the_correct_factory;
            static Dictionary<Type, DependencyFactory> factories;
        }

        [Subject(typeof(DefaultDependencyFactories))]
        public class when_attempting_to_get_a_factory_for_a_dependency_and_it_has_no_factory : concern
        {
            Establish c = () =>
            {
                dependency_type = typeof(int);
                factories = new Dictionary<Type, DependencyFactory>();
                provide_a_basic_sut_constructor_argument<IDictionary<Type, DependencyFactory>>(factories);
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(dependency_type);


            It should_return_a_factory_that_can_create_the_type = () =>
                result.ShouldBeAn<MissingDependencyFactory>()
                      .type_that_has_no_dependency_factory.ShouldEqual(dependency_type);

            static Type dependency_type;
            static DependencyFactory result;
            static Dictionary<Type, DependencyFactory> factories;
        }
    }
}