using System.Xml;
using log4net.Config;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public class Log4NetInitializationCommand : Command
    {
        XmlElement configuration_element;

        public Log4NetInitializationCommand(XmlElement configuration_element)
        {
            this.configuration_element = configuration_element;
        }

        public void run()
        {
            XmlConfigurator.Configure(configuration_element);
        }
    }
}