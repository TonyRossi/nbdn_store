using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupPipelineBuilder
    {
        StartupCommandFactory factory;
        IList<StartupCommand> all_commands;
        StartupCommand the_first_command;

        public StartupPipelineBuilder(StartupCommandFactory factory, IList<StartupCommand> allCommands, Type firstCommandType)
        {
            this.factory = factory;
            all_commands = allCommands;
            var startupCommand = factory.create_from(firstCommandType);
            all_commands.Add(startupCommand);
        }
    }
}