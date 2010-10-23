using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class WebCommandFactorySpecs
    {
        public abstract class concern : Observes<WebCommandFactory,
                                            DefaultWebCommandFactory>
        {
        }

        [Subject(typeof(DefaultWebCommandFactory))]
        public class when_asked_to_create_a_web_command : concern
        {
            Establish c = () =>
            {
                criteria = an<RequestCriteria>();
                dependency_container = the_dependency<DependencyContainer>();
                command = new OurCommand();


                dependency_container.Stub(x => x.an<OurCommand>()).Return(command);
            };

            Because b = () =>
                results = sut.create_web_command_for<OurCommand>(criteria);

            It should_return_a_new_web_command_with_supplied_criteria_and_application_command_type = () =>
                results.ShouldBeAn<WebCommand>();

            static RequestCriteria criteria;
            static WebCommand results;
            static OurCommand command;
            static DependencyContainer dependency_container;
        }

        internal class OurCommand : ApplicationCommand
        {
            public void process(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}