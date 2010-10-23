namespace nothinbutdotnetstore.web.core
{
    public class    DefaultWebCommand : WebCommand
    {
        RequestCriteria criteria;
        ApplicationCommand command;

        public DefaultWebCommand(RequestCriteria criteria, ApplicationCommand command)
        {
            this.criteria = criteria;
            this.command = command;
        }

        public void process(Request request)
        {
            command.process(request);
        }

        public bool can_handle(Request request)
        {
            return criteria(request);
        }
    }
}