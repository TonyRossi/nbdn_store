using log4net;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public class Log4NetLog : Logger
    {
        public ILog underlying_logger { get; private set; }

        public Log4NetLog(ILog underlying_logger)
        {
            this.underlying_logger = underlying_logger;
        }

        public void informational(string message)
        {
            underlying_logger.Info(message);
        }
    }
}