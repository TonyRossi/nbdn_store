using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupCommandFactory : StartupCommandFactory
    {
        StartupFacilities startup_facilities;

        public DefaultStartupCommandFactory()
        {
        }

        public DefaultStartupCommandFactory(StartupFacilities startup_facilities)
        {
            this.startup_facilities = startup_facilities;
        }

        public StartupCommand create_from(Type command_type)
        {
            return (StartupCommand)Activator.CreateInstance(command_type, startup_facilities);
        }
    }
}