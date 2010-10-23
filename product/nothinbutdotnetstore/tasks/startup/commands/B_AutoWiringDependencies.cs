using System;

namespace nothinbutdotnetstore.tasks.startup.commands
{
    public class B_AutoWiringDependencies : StartupCommand
    {
        StartupFacilities startup_facilities;

        public B_AutoWiringDependencies(StartupFacilities startup_facilities)
        {
            this.startup_facilities = startup_facilities;
        }

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}