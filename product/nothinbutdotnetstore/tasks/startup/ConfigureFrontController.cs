using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        StartupFacilities startup_facilities;

        public ConfigureFrontController(StartupFacilities startup_facilities)
        {
            this.startup_facilities = startup_facilities;
        }

        public void run()
        {
            startup_facilities.register<FrontController, DefaultFrontController>();
            startup_facilities.register<WebCommandRegistry, DefaultWebCommandRegistry>();
            startup_facilities.register<ResponseEngine, WebFormResponseEngine>();
            startup_facilities.register<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
            startup_facilities.register<CurrentContextResolver>(() => HttpContext.Current);
            startup_facilities.register<ViewRegistry, StubViewRegistry>();
            startup_facilities.register<ViewFactory, HttpHandlerViewFactory>();
        }
    }
}