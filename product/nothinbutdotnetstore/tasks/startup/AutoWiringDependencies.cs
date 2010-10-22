using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class AutoWiringDependencies : StartupCommand
    {
        StartupFacilities startup_facilities;

        public AutoWiringDependencies(StartupFacilities startup_facilities)
        {
            this.startup_facilities = startup_facilities;
        }

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}