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
        public class
            when_retrieving_an_implementation_of_a_dependency_and_it_has_the_dependency_factory_for_the_dependency :
                concern
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

        public class MyDependency
        {
        }
    }
}