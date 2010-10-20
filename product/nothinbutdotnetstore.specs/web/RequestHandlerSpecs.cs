 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RequestHandlerSpecs
     {
         public abstract class concern : Observes<IHttpHandler,
                                             RequestHandler>
         {
        
         }

         [Subject(typeof(RequestHandler))]
         public class when_processing_an_incoming_http_context : concern
         {

             Establish c = () =>
             {
                 front_controller = the_dependency<FrontController>();
                 request_factory = the_dependency<RequestFactory>();
                 request = an<Request>();
                 an_http_context = ObjectMother.create_http_context();

                 request_factory.Stub(x => x.create_request_from(an_http_context)).Return(request);
             };

             Because b = () =>
                 sut.ProcessRequest(an_http_context);

             It should_delegate_the_processing_of_a_request_to_the_front_controller = () =>
                 front_controller.received(x => x.process(request));

             static FrontController front_controller;
             static Request request;
             static HttpContext an_http_context;
             static RequestFactory request_factory;
         }
     }
 }
