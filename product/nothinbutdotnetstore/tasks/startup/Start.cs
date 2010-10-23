using System;
using System.IO;
using System.Linq;
using System.Reflection;

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
            var lines = File.ReadAllLines(pipeline_file_location);
            foreach (var line in lines)
            {
                string line1 = line;
                var matching_type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).First(t => t.Name.Contains(line1)); 
                var instance = (StartupCommand) Activator.CreateInstance(matching_type);
                
                instance.run();
            }
        }
    }
}