using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class BasicContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_retrieving_an_implementation_of_a_dependency_and_it_has_the_dependency_factory_for_the_dependency : concern
        {
            Establish c = () =>
            {
                dependency_factories = the_dependency<DependencyFactories>();
                dependency_factory = an<DependencyFactory>();
                dependency_created_by_factory = new MyDependency();

                dependency_factory.Stub(x => x.create()).Return(dependency_created_by_factory);
                dependency_factories.Stub(x => x.get_factory_that_can_create(typeof(MyDependency))).Return(
                    dependency_factory);
            };

            Because b = () =>
                result = sut.an<MyDependency>();

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(dependency_created_by_factory);

            static MyDependency result;
            static MyDependency dependency_created_by_factory;
            static DependencyFactory dependency_factory;
            static DependencyFactories dependency_factories;
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_the_dependency_factory_for_a_dependency_throws_an_exception_trying_to_create_the_dependency : concern
        {
            Establish c = () =>
            {
                dependency_factories = the_dependency<DependencyFactories>();
                dependency_factory = an<DependencyFactory>();

                inner_exception = new Exception();

                dependency_factory.Stub(x => x.create()).Throw(inner_exception);
                dependency_factories.Stub(x => x.get_factory_that_can_create(typeof(MyDependency))).Return(
                    dependency_factory);
            };

            Because b = () =>
                catch_exception(() => sut.an<MyDependency>());

            It should_throw_a_dependency_creation_exception_with_the_appropriate_information = () =>
            {
                var actual_exception = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                actual_exception.InnerException.ShouldEqual(inner_exception);
                actual_exception.type_that_could_not_be_created.ShouldEqual(typeof(MyDependency));
            };

            static DependencyFactory dependency_factory;
            static DependencyFactories dependency_factories;
            static Exception inner_exception;
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_retrieving_an_implementation_of_a_dependency_non_generically: concern
        {
            Establish c = () =>
            {
                dependency_factories = the_dependency<DependencyFactories>();
                dependency_factory = an<DependencyFactory>();
                dependency_created_by_factory = new MyDependency();

                dependency_factory.Stub(x => x.create()).Return(dependency_created_by_factory);
                dependency_factories.Stub(x => x.get_factory_that_can_create(typeof(MyDependency))).Return(
                    dependency_factory);
            };

            Because b = () =>
                result = sut.an(typeof(MyDependency));

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(dependency_created_by_factory);

            static object result;
            static MyDependency dependency_created_by_factory;
            static DependencyFactory dependency_factory;
            static DependencyFactories dependency_factories;
        }

        public class MyDependency
        {
        }
    }
}