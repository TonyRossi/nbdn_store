namespace nothinbutdotnetstore.web.core
{
    public interface WebCommand : ApplicationCommand
    {
        bool can_handle(Request request);
    }
}