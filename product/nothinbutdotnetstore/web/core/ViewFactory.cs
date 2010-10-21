using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewFactory
    {
        IHttpHandler create_a_view_that_can_display<ViewModel>(ViewModel the_view_model);
    }
}