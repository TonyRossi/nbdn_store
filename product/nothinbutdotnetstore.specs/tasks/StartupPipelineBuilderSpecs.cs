 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;
 using Rhino.Mocks;

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


                 startup_command_factory.Stub(x => x.create_from(typeof(OurFirstCommand)))
                     .Return(the_first_command);
             };

             It should_add_the_command_to_the_list_of_commands_that_will_run = () =>
                 all_commands.ShouldContainOnly(the_first_command);

             static IList<StartupCommand> all_commands;
             static StartupCommand the_first_command;
             static StartupCommandFactory startup_command_factory;
         }

         public class OurFirstCommand : StartupCommand
     {
             public void run()
             {
                 throw new NotImplementedException();
             }
     }
     }

 }
