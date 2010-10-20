using System;
using System.Collections.Generic;

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
            foreach(var command in known_commands)
            {
                if (command.can_handle(request))
                    return command;
            }
            throw new Exception("No commands found that match the given request");
        }
    }
}