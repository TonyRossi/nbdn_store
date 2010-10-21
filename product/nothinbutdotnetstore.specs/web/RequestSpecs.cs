using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

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
                payload_mapper = the_dependency<PayloadMapper>();
                payload_mapper.Stub(x => x.map_payload_to_input_model<InputModel>(payload)).Return(the_mapped_model);
            };

            Because b = () =>
                result = sut.map<InputModel>();

          It should_return_the_model_mapped_from_its_payload = () =>
                result.ShouldEqual(the_mapped_model);


            static InputModel result;
            static InputModel the_mapped_model;
            static Payload payload;
            static PayloadMapper payload_mapper;
        }

        public class InputModel
        {
        }
    }
}