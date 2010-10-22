using System;
using log4net;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public class Log4NetLog : Logger
    {
        private readonly ILog _underlyingLogger;

        public Log4NetLog(ILog underlying_logger)
        {
            _underlyingLogger = underlying_logger;
        }

        public void informational(string message)
        {
            _underlyingLogger.Info(message);
        }
    }
}