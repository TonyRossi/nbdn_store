namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        string get_the_path_to_the_view_that_can_display<ViewModel>();
    }
}