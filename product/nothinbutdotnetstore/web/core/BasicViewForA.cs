using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class BasicViewForA<ViewModel> : Page, ViewForA<ViewModel>
    {
        public ViewModel model { get; set; }
    }
}