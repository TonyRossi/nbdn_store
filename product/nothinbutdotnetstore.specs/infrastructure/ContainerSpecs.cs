 
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Container))]
        public class when_providing_access_to_the_container_facade : concern
        {
            Establish c = () =>
            {
                the_dependency_container = an<DependencyContainer>();
                ContainerResolver resolver = () => the_dependency_container;

                change(() => Container.container_resolver).to(resolver);
            };

            Because b = () =>
                result = Container.retrieve;

            It should_return_the_facade_to_the_configured_container_api = () =>
                result.ShouldEqual(the_dependency_container);

            static DependencyContainer result;
            static DependencyContainer the_dependency_container;
        }
    }
}
