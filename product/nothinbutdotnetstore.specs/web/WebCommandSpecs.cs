 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class WebCommandSpecs
     {
         public abstract class concern : Observes<WebCommand,
                                             DefaultWebCommand>
         {
        
         }

         [Subject(typeof(DefaultWebCommand))]
         public class when_determining_if_it_can_handle_a_request : concern
         {

             Establish c = () =>
             {
                 request = an<Request>();
                 provide_a_basic_sut_constructor_argument<RequestCriteria>(x => true);
             };

             Because b = () =>
                 result = sut.can_handle(request);

             It should_make_the_determination_by_using_its_request_criteria = () =>
                 result.ShouldBeTrue();


             static bool result;
             static Request request;
         }

         [Subject(typeof(DefaultWebCommand))]
         public class when_processing_a_request : concern
         {

             Establish c = () =>
             {
                 request = an<Request>();
                 application_command = the_dependency<ApplicationCommand>();
                 provide_a_basic_sut_constructor_argument<RequestCriteria>(x => true);

             };

             Because b = () =>
                 sut.process(request);


             It should_trigger_the_application_specific_command_that_does_the_real_work = () =>
                 application_command.received(x => x.process(request));


             static bool result;
             static Request request;
             static ApplicationCommand application_command;
         }
     }
 }
