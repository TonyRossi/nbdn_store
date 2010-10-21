using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request,
                                            DefaultRequest>
        {
        }

        [Subject(typeof(Request))]
        public class when_mapping_an_input_model : concern
        {
            Establish c = () =>
            {
                the_mapped_model = new InputModel();
                payload = the_dependency<Payload>();
            };

            Because b = () =>
                result = sut.map<InputModel>();

            It should_return_the_model_mapped_from_its_payload = () =>
                result.ShouldEqual(the_mapped_model);


            static InputModel result;
            static InputModel the_mapped_model;
            static Payload payload;
        }

        public class InputModel
        {
        }
    }
}