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
     }
 }
