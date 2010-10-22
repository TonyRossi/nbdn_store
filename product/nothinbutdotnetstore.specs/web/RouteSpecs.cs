 
using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{
    public class RouteSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Routes))]
        public class when_a_route_is_registered : concern
        {
            Establish c = () =>
            {
                the_criteria = x => true;
                route_table = an<RouteTable>();

                add_pipeline_behaviour(CommonPipelineActions.scaffold_the_container_based_return_of(route_table));
            };

            Because b = () =>
                Routes.add<OurCommand>(the_criteria);

            It should_register_the_route_with_the_route_table = () =>
                route_table.received(x => x.register<OurCommand>(the_criteria));

            static RequestCriteria the_criteria;
            static RouteTable route_table;
        }

        public class OurCommand : ApplicationCommand
    {
            public void process(Request request)
            {
                throw new NotImplementedException();
            }
    }
    }

}
