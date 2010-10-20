using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultWebCommandRegistry : WebCommandRegistry
    {
        IEnumerable<WebCommand> known_commands;

        public DefaultWebCommandRegistry(IEnumerable<WebCommand> knownCommands)
        {
            known_commands = knownCommands;
        }

        public WebCommand get_the_command_that_can_process(Request request)
        {
            var commands = known_commands.Where(x => x.can_handle(request));

            if (commands.Any())
                return known_commands.First(x => x.can_handle(request));

            return new MissingWebCommand();
        }
    }
}