 
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.log4net;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Startup))]
        public class when_it_has_finished_running : concern
        {
            Because b = () =>
                Startup.run();

            It should_be_able_to_run_the_application_correctly = () =>
            {
                Container.retrieve.an<FrontController>().ShouldBeAn<DefaultFrontController>();
                Container.retrieve.an<LoggerFactory>().ShouldBeAn<Log4NetLoggerFactory>();
            };
                
        }
    }
}
