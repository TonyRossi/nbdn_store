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
        }

        [Subject(typeof(DefaultWebCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                web_commands = new List<WebCommand>();

                the_command_that_can_process_the_request = an<WebCommand>();
                request = an<Request>();

                Enumerable.Range(1,100).each(x => web_commands.Add(an<WebCommand>()));
                web_commands.Add(the_command_that_can_process_the_request);
                provide_a_basic_sut_constructor_argument<IEnumerable<WebCommand>>(web_commands);
                               

                the_command_that_can_process_the_request.Stub(x => x.can_handle(request)).Return(true);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_the_command_that_can_process_the_request = () =>
                result.ShouldEqual(the_command_that_can_process_the_request);

            static WebCommand result;
            static WebCommand the_command_that_can_process_the_request;
            static Request request;
            static IList<WebCommand> web_commands;
        }
    }
}