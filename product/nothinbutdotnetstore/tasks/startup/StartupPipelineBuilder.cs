using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupPipelineBuilder
    {
        StartupCommandFactory factory;
        IList<StartupCommand> all_commands;
        StartupCommand the_first_command;

        public StartupPipelineBuilder(StartupCommandFactory factory, IList<StartupCommand> allCommands, Type first_command_type)
        {
            this.factory = factory;
            all_commands = allCommands;
            all_commands.Add(factory.create_from(first_command_type));
        }

        public StartupPipelineBuilder then_by<TheCommand>() where TheCommand : StartupCommand
        {
            throw new NotImplementedException();
        }
    }
}