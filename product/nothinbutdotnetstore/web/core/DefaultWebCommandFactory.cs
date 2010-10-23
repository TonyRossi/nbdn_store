using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultWebCommandFactory : WebCommandFactory
    {
        DependencyContainer container;

        public DefaultWebCommandFactory(DependencyContainer container)
        {
            this.container = container;
        }

        public WebCommand create_web_command_for<TheCommand>(RequestCriteria criteria) where TheCommand : ApplicationCommand
        {
            return new DefaultWebCommand(criteria, container.an<TheCommand>());
        }
    }
}