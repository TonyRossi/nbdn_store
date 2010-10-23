namespace nothinbutdotnetstore.web.core
{
    public interface WebCommandFactory
    {
        WebCommand create_web_command_for<T>(RequestCriteria criteria) where T : ApplicationCommand;
    }
}