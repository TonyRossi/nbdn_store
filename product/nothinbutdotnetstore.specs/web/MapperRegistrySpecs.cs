using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    class MapperRegistrySpecs
    {
        public abstract class concern : Observes<MapperRegistry,
                                            DefaultMapperRegistry>
        {
        }

        [Subject(typeof(DefaultMapperRegistry))]
        public class when_asked_for_a_mapper : concern
        {
            Establish c = () =>
            {
                container = the_dependency<DependencyContainer>();
                the_mapper = an<Mapper<int, string>>();
                container.Stub(x => x.an<Mapper<int, string>>()).Return(the_mapper);
            };

            Because b = () =>
                mapper = sut.get_mapper_to_map<int, string>();

            It should_return_the_mapper_of_the_requested_type = () =>
                mapper.ShouldEqual(the_mapper);

            static Mapper<int, string> mapper;
            static Mapper<int, string> the_mapper;
            static DependencyContainer container;
        }
    }
}