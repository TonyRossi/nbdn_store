using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface RouteTable : IEnumerable<WebCommand>
    {
        void register<Command>(RequestCriteria criteria) where Command : ApplicationCommand;
    }
}