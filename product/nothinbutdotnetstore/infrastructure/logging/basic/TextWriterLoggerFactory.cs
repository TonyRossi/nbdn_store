using System;
using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.basic
{
    public class TextWriterLoggerFactory : LoggerFactory
    {
        TextWriter writer;

        public TextWriterLoggerFactory(TextWriter writer)
        {
            this.writer = writer;
        }

        public Logger create_logger_bound_to(Type type_that_requested_logging_services)
        {
            return new TextWriterLogger(writer);
        }
    }
}