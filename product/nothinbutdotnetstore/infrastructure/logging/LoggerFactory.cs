using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface LoggerFactory
    {
        Logger create_logger_bound_to(Type type_that_requested_logging_services);
    }
}