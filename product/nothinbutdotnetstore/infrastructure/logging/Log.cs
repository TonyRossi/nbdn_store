using System;
using System.Diagnostics;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        public static Logger an
        {
            get { return Container.retrieve.an<LoggerFactory>().create_logger_bound_to(get_the_calling_type()); }
        }

        static Type get_the_calling_type()
        {
            return new StackFrame(2).GetMethod().DeclaringType;
        }
    }
}