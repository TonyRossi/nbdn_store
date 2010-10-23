using System;
using System.IO;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartSpecs
    {
        public abstract class concern : Observes<Start>
        {
        }

        [Subject(typeof(StartUp))]
        public class when_it_has_finished_running : concern
        {
            Establish e = () =>
            {
                file_location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_start_file.txt");
                file_contents = @"A_StartupCommand
B_StartupCommand";
                add_pipeline_behaviour(
                    new PipelineBehaviour(() => File.WriteAllText(file_location, file_contents),
                                          () => File.Delete(file_location)));
            };

            Because b = () => 
                Start.by_running_the_pipeline_defined_in(file_location);

            It should_be_able_to_run_the_application_correctly = () =>
            {
                A_StartupCommand.ran.ShouldBeTrue();
                B_StartupCommand.ran.ShouldBeTrue();
            };

            static string file_location;
            static string file_contents;
        }

        public class A_StartupCommand : StartupCommand
        {
            public static bool ran { get; private set; }

            public void run()
            {
                ran = true;
                return;
            }
        }

        public class B_StartupCommand : StartupCommand
        {
            public static bool ran { get; private set; }

            public void run()
            {
                ran = true;
                return;
            }
        }
    }
}