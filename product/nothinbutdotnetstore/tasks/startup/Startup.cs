using System;
using System.IO;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        public static void run()
        {
            Start.by_running_the_pipeline_defined_in(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                  "startup_pipeline.txt"));
        }
    }
}