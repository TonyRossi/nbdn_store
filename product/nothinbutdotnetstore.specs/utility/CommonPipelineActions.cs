using Machine.Specifications.DevelopWithPassion;
using nothinbutdotnetstore.infrastructure.containers;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.utility
{
    public class CommonPipelineActions
    {
        public static PipelineBehaviour scaffold_the_container_based_return_of<Dependency>(Dependency dependency)
        {
            var container = MockRepository.GenerateMock<DependencyContainer>();
            ContainerResolver resolver = () => container;
            container.Stub(x => x.an<Dependency>()).Return(dependency);

            return new PipelineBehaviour(() => { Container.container_resolver = resolver; },
                                         () => { Container.container_resolver = null; });
        }
    }
}