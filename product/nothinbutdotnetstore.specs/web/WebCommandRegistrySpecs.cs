using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class WebCommandRegistrySpecs
    {
        public abstract class concern : Observes<WebCommandRegistry,
                                            DefaultWebCommandRegistry>
        {
            Establish c = () =>
            {
                web_commands = new List<WebCommand>();
                Enumerable.Range(1,100).each(x => web_commands.Add(an<WebCommand>()));
                provide_a_basic_sut_constructor_argument<IEnumerable<WebCommand>>(web_commands);

                request = an<Request>();
                
            };

            protected static IList<WebCommand> web_commands;
            protected static Request request;
        }

        [Subject(typeof(DefaultWebCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                the_command_that_can_process_the_request = an<WebCommand>();

                web_commands.Add(the_command_that_can_process_the_request);
                the_command_that_can_process_the_request.Stub(x => x.can_handle(request)).Return(true);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_the_command_that_can_process_the_request = () =>
                result.ShouldEqual(the_command_that_can_process_the_request);

            static WebCommand result;
            static WebCommand the_command_that_can_process_the_request;
        }

        [Subject(typeof(DefaultWebCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_does_not_have_the_command : concern
        {
            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_a_missing_command = () =>
                result.ShouldBeAn<MissingWebCommand>();

            static WebCommand result;
        }
    }
}