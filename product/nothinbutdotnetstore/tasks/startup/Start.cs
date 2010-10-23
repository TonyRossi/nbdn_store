using System;
using System.IO;
using System.Linq;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static StartupPipelineBuilder by<CommandToRun>() where CommandToRun : StartupCommand
        {
            return new StartupPipelineBuilder(typeof(CommandToRun));
        }

        public static void by_running_the_pipeline_defined_in(string pipeline_file_location)
        {
            new StartupPipelineBuilder(typeof(NulloStartupCommand)).run_all_commands_in(
                File.ReadAllLines(pipeline_file_location).Select<string,Type>(new StringToTypeMapper().map_from));
        }

        public class NulloStartupCommand : StartupCommand
        {
            StartupFacilities startup_facilities;

            public NulloStartupCommand(StartupFacilities startup_facilities)
            {
                this.startup_facilities = startup_facilities;
            }

            public void run()
            {
            }
        }
    }
}