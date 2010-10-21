using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class HttpHandlerViewFactory : ViewFactory
    {
        ViewRegistry view_registry;
        PageFactory page_factory;

        public HttpHandlerViewFactory():this(new StubViewRegistry(),BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public HttpHandlerViewFactory(ViewRegistry view_registry, PageFactory page_factory)
        {
            this.view_registry = view_registry;
            this.page_factory = page_factory;
        }

        public IHttpHandler create_a_view_that_can_display<ViewModel>(ViewModel the_view_model)
        {
            var view = (ViewForA<ViewModel>)page_factory(view_registry.get_the_path_to_the_view_that_can_display<ViewModel>(), 
                typeof(ViewForA<ViewModel>));

            view.model = the_view_model;

            return view;
        }
    }
}