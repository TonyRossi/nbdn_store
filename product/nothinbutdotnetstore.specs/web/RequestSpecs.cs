using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestSpecs
    {
         public abstract class concern : Observes<Request,
                                             RequestImplementer>
         {
        
         }

         [Subject(typeof(Request))]
         public class when_asked_for_a_map : concern
         {
             Because b = () =>
                 input_model = sut.map<InputModel>();

             private It should_return_a_map_for_the_specified_input_model = () =>
                 input_model.ShouldBeOfType(typeof (InputModel));

             private static InputModel input_model;
         }

        public class InputModel
        {
            
        }
     }
}
