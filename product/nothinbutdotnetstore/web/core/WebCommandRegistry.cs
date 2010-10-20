namespace nothinbutdotnetstore.web.core
{
    public interface WebCommandRegistry
    {
        WebCommand get_the_command_that_can_process(Request request);
    }
}