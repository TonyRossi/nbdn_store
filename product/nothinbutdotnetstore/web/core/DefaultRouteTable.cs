using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRouteTable : RouteTable
    {
        WebCommandFactory web_command_factory;
        List<WebCommand> web_commands;

        public DefaultRouteTable(WebCommandFactory webCommandFactory)
        {
            web_command_factory = webCommandFactory;
            web_commands = new List<WebCommand>();
        }

        public IEnumerator<WebCommand> GetEnumerator()
        {
            return web_commands.GetEnumerator();
        }

        public void register<Command>(RequestCriteria criteria) where Command : ApplicationCommand
        {
            web_commands.Add(web_command_factory.create_web_command_for<Command>(criteria));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}