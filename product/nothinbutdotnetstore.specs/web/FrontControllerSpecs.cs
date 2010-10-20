 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class FrontControllerSpecs
     {
         public abstract class concern : Observes<FrontController,
                                             DefaultFrontController>
         {
        
         }

         [Subject(typeof(DefaultFrontController))]
         public class when_processing_a_request : concern
         {

             Establish c = () =>
             {
                 web_command_registry = the_dependency<WebCommandRegistry>();
                 command_that_can_process_the_request = an<WebCommand>();
                 request = an<Request>();

                 web_command_registry.Stub(x => x.get_the_command_that_can_process(request)).Return(
                     command_that_can_process_the_request);
             };

             Because b = () =>
                 sut.process(request);


             It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
                 command_that_can_process_the_request.received(x => x.process(request));


             static WebCommand command_that_can_process_the_request;
             static Request request;
             static WebCommandRegistry web_command_registry;
         }
     }
 }
