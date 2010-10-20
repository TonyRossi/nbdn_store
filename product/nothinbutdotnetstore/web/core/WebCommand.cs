namespace nothinbutdotnetstore.web.core
{
    public interface WebCommand
    {
        void process(Request request);
        bool can_handle(Request request);
    }
}