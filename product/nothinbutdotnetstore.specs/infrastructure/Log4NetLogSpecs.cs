 using log4net;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging.log4net;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class Log4NetLogSpecs
     {
         public abstract class concern : Observes<Logger,
                                             Log4NetLog>
         {
        
         }

         [Subject(typeof(Log4NetLog))]
         public class when_logging_an_informational_message : concern
         {

             Establish c = () =>
             {
                 underlying_logger = the_dependency<ILog>();
                 the_message = "this is the message";
             };

             Because b = () =>
                 sut.informational(the_message);


             It should_dispatch_the_appropriate_message_to_log_4_net = () =>
                 underlying_logger.received(x => x.Info(the_message));

             static ILog underlying_logger;
             static string the_message;
         }
     }
 }
