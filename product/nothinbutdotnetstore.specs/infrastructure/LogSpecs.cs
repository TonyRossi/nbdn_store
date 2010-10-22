 
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.specs.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class LogSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Log))]
        public class when_accessing_the_logging_facade : concern
        {
            Establish c = () =>
            {
                the_actual_logger = an<Logger>();
                logger_factory = an<LoggerFactory>();

                logger_factory.Stub(x => x.create_logger_bound_to(typeof(when_accessing_the_logging_facade)))
                    .Return(the_actual_logger);

                add_pipeline_behaviour(CommonPipelineActions.scaffold_the_container_based_return_of(logger_factory));
            };
            Because b = () =>
                result = Log.an;

            It should_provide_a_logger_that_is_bound_to_the_calling_type = () =>
                result.ShouldEqual(the_actual_logger);

            static Logger result;
            static Logger the_actual_logger;
            static LoggerFactory logger_factory;
            static DependencyContainer container;
        }
    }
}
