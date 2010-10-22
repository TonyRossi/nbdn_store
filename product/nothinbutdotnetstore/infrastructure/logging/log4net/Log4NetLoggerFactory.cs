using System;
using log4net;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public class Log4NetLoggerFactory : LoggerFactory
    {
        Command initialization_command;
        bool initialized;

        public Log4NetLoggerFactory(Command initialization_command)
        {
            this.initialization_command = initialization_command;
        }

        public Logger create_logger_bound_to(Type type_that_requested_logging_services)
        {
            initialize_logging_infrastructure();
            return new Log4NetLog(LogManager.GetLogger(type_that_requested_logging_services));
        }

        void initialize_logging_infrastructure()
        {
            if (initialized) return;
            initialization_command.run();
            initialized = true;
        }
    }
}