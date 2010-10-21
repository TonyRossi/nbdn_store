using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void display<ViewModel>(ViewModel details)
        {
            HttpContext.Current.Items.Add("blah", details);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx",true);
        }
    }
}