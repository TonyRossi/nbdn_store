using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<WebCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<WebCommand> GetEnumerator()
        {
            yield return new DefaultWebCommand(x => true, 
                new ViewMainDeparmentsInTheStore(new StubStoreDirectory(), 
                    new WebFormResponseEngine(
                        new HttpHandlerViewFactory(new StubViewRegistry(), 
                            (x, y) => BuildManager.CreateInstanceFromVirtualPath(x,y)),()=>HttpContext.Current)));
        }
    }
}