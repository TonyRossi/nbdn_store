using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class WebFormResponseEngine : ResponseEngine
    {
        ViewFactory view_factory;
        CurrentContextResolver context_resolver;

        public WebFormResponseEngine():this(new HttpHandlerViewFactory(),
            () => HttpContext.Current)
        {
        }

        public WebFormResponseEngine(ViewFactory view_factory, CurrentContextResolver context_resolver)
        {
            this.view_factory = view_factory;
            this.context_resolver = context_resolver;
        }

        public void display<ViewModel>(ViewModel details)
        {
            view_factory.create_a_view_that_can_display(details).ProcessRequest(context_resolver());
        }
    }
}