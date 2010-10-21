using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewForA<ViewModel> : IHttpHandler
    {
        ViewModel model { get; set; }
    }
}