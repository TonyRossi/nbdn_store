using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static StartupPipelineBuilder by<CommandToRun>() where CommandToRun : StartupCommand
        {
            return new StartupPipelineBuilder(typeof(CommandToRun));
        }

        public static void by_running_the_pipeline_defined_in(string combine)
        {
            throw new NotImplementedException();
        }
    }
}