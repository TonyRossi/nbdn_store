using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupPipelineBuilder
    {
        StartupCommandFactory factory;
        IList<StartupCommand> all_commands;

        public StartupPipelineBuilder(Type initial_command_type):this(new DefaultStartupCommandFactory(),
            new List<StartupCommand>(),initial_command_type)
        {
        }

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
            run_all_commands();
        }

        void run_all_commands()
        {
            all_commands.each(x => x.run());
        }

        public void run_all_commands_in(IEnumerable<Type> all_command_types)
        {
            all_command_types.each(append_command);            
            run_all_commands();
        }
    }
}