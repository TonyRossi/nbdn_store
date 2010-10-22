using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    [Register]
    public class DefaultFrontController : FrontController
    {
        WebCommandRegistry web_command_registry;

        public DefaultFrontController(WebCommandRegistry web_command_registry)
        {
            this.web_command_registry = web_command_registry;
        }

        public void process(Request request)
        {
            web_command_registry.get_the_command_that_can_process(request).process(request);
        }
    }
}