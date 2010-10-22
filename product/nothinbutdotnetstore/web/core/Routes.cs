using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.core
{
    public class Routes
    {
        public static void add<AppCommand>(RequestCriteria the_criteria) where AppCommand : ApplicationCommand
        {
            Container.retrieve.an<RouteTable>().register<AppCommand>(the_criteria);
        }
    }
}