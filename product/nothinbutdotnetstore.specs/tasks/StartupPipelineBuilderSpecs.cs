using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;
using Rhino.Mocks;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupPipelineBuilderSpecs
    {
        public abstract class concern : Observes<StartupPipelineBuilder>
        {
        }

        [Subject(typeof(StartupPipelineBuilder))]
        public class when_created_with_the_initial_command_type_to_run : concern
        {
            Establish c = () =>
            {
                all_commands = new List<StartupCommand>();
                the_first_command = an<StartupCommand>();
                startup_command_factory = the_dependency<StartupCommandFactory>();
                provide_a_basic_sut_constructor_argument(all_commands);
                provide_a_basic_sut_constructor_argument(typeof(OurFirstCommand));

                startup_command_factory.Stub(x => x.create_from(typeof(OurFirstCommand)))
                    .Return(the_first_command);
            };

            It should_add_the_command_to_the_list_of_commands_that_will_run = () =>
                all_commands.ShouldContainOnly(the_first_command);

            static IList<StartupCommand> all_commands;
            static StartupCommand the_first_command;
            static StartupCommandFactory startup_command_factory;
        }

        public abstract class concern_for_a_builder_with_one_command : Observes<StartupPipelineBuilder>
        {
            Establish c = () =>
            {
                all_commands = new List<StartupCommand>();
                the_first_command = an<StartupCommand>();
                startup_command_factory = the_dependency<StartupCommandFactory>();
                provide_a_basic_sut_constructor_argument(all_commands);
                provide_a_basic_sut_constructor_argument(typeof(OurFirstCommand));

                startup_command_factory.Stub(x => x.create_from(typeof(OurFirstCommand)))
                    .Return(the_first_command);
            };

            protected static IList<StartupCommand> all_commands;
            protected static StartupCommand the_first_command;
            protected static StartupCommandFactory startup_command_factory;
        }

        [Subject(typeof(StartupPipelineBuilder))]
        public class when_followed_by_a_command_type_to_run : concern_for_a_builder_with_one_command
        {
            Establish c = () =>
            {
                the_second_command = an<StartupCommand>();

                startup_command_factory.Stub(x => x.create_from(typeof(OurSecondCommand)))
                    .Return(the_second_command);
            };

            Because b = () =>
                result = sut.then_by<OurSecondCommand>();

            It should_add_the_command_to_the_list_of_commands_that_will_run = () =>
                all_commands.ShouldContainOnly(the_first_command,the_second_command);

            It should_return_itself_to_continue_the_chaining_process = () =>
                result.ShouldEqual(sut);

            static StartupPipelineBuilder result;
            static StartupCommand the_second_command;
        }

        [Subject(typeof(StartupPipelineBuilder))]
        public class when_finishing_with_a_command : concern_for_a_builder_with_one_command
        {
            Establish c = () =>
            {
                the_second_command = an<StartupCommand>();
                startup_command_factory.Stub(x => x.create_from(typeof(OurSecondCommand))).Return(the_second_command);
                Enumerable.Range(1,100).each(x => all_commands.Add(an<StartupCommand>()));
            };

            Because b = () =>
                     sut.finish_by<OurSecondCommand>();

            It should_add_the_command_to_the_list_of_commands_to_run = () =>
                all_commands.ShouldContain(the_second_command,the_first_command);

            It should_run_all_of_the_commands = () =>
                all_commands.each(x => x.received(y => y.run()));

            static StartupCommand the_second_command;
        }

        public class OurFirstCommand : StartupCommand
        {
            public void run()
            {
                throw new NotImplementedException();
            }

        }
            public class OurSecondCommand : StartupCommand
            {
                public void run()
                {
                    throw new NotImplementedException();
                }
            }
    }
}