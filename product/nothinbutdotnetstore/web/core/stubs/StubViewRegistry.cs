namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewRegistry : ViewRegistry
    {
        public string get_the_path_to_the_view_that_can_display<ViewModel>()
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}