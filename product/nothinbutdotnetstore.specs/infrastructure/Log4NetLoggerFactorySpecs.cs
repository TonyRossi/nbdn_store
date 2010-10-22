 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging.log4net;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class Log4NetLoggerFactorySpecs
     {
         public abstract class concern : Observes<LoggerFactory,
                                             Log4NetLoggerFactory>
         {
        
         }

         [Subject(typeof(Log4NetLoggerFactory))]
         public class when_creating_a_logger_bound_to_a_type_and_it_is_the_first_request_for_a_logger : concern
         {
             Establish c = () =>
             {
                 initialization_command = the_dependency<Command>();
             };

             Because b = () =>
                 result = sut.create_logger_bound_to(typeof(int));


             It should_run_the_log4net_initialization_command = () =>
                 initialization_command.received(x => x.run());

             It should_return_a_log4net_log_with_its_underlying_logger = () =>
                 result.ShouldBeAn<Log4NetLog>().underlying_logger.ShouldNotBeNull();
  

             static Command initialization_command;
             static Logger result;
         }

         [Subject(typeof(Log4NetLoggerFactory))]
         public class when_creating_a_logger_bound_to_a_type_and_it_is_not_the_first_request_for_a_logger : concern
         {
             Establish c = () =>
             {
                 initialization_command = the_dependency<Command>();
             };

             Because b = () =>
             {
                 sut.create_logger_bound_to(typeof(int));
                 result = sut.create_logger_bound_to(typeof(int));
             };


             It should_not_run_the_initialization_command = () =>
                 initialization_command.received(x => x.run()).only_once();

             It should_return_a_log4net_log_with_its_underlying_logger = () =>
                 result.ShouldBeAn<Log4NetLog>().underlying_logger.ShouldNotBeNull();
  

             static Command initialization_command;
             static Logger result;
         }
     }
 }
