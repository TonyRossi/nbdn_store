using System.Xml;
using log4net.Config;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public interface Log4NetInitializationCommand : Command
    {
    }

    public class DefaultLog4NetInitializationCommand : Log4NetInitializationCommand
    {
        XmlElement configuration_element;

        public DefaultLog4NetInitializationCommand(XmlElement configuration_element)
        {
            this.configuration_element = configuration_element;
        }

        public DefaultLog4NetInitializationCommand()
        {
        }

        public void run()
        {
            XmlConfigurator.Configure(configuration_element);
        }
    }
}