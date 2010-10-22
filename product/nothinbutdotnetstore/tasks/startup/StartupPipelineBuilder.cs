using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupPipelineBuilder
    {
        StartupCommandFactory factory;
        IList<StartupCommand> all_commands;

        public StartupPipelineBuilder(StartupCommandFactory factory, IList<StartupCommand> allCommands, Type first_command_type)
        {
            this.factory = factory;
            this.all_commands = allCommands;

            append_command(first_command_type);
        }

        public StartupPipelineBuilder then_by<TheCommand>() where TheCommand : StartupCommand
        {
            append_command(typeof(TheCommand));
            return this;
        }

        void append_command(Type command_type)
        {
            all_commands.Add(factory.create_from(command_type));
        }

        public void finish_by<TheCommand>() where TheCommand :StartupCommand
        {
            append_command(typeof(TheCommand));

            foreach (StartupCommand command in all_commands)
            {
                command.run();
            }
        }
    }
}