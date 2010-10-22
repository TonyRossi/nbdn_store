using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfiguringApplicationRoutes : StartupCommand
    {
        StartupFacilities startup_facilities;

        public ConfiguringApplicationRoutes(StartupFacilities startup_facilities)
        {
            this.startup_facilities = startup_facilities;
        }

        public void run()
        {
            Routes.add<ViewMainDeparmentsInTheStore>(x => true);
            Routes.add<ViewDepartmentsInDepartment>(x => true);
            Routes.add<ViewProductsInADepartment>(x => true);
        }
    }
}