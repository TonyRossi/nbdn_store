using System.Collections.Specialized;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class InputModelMapperSpecs
    {
        public abstract class concern : Observes<InputModelMapper,
                                            DefaultInputModelMapper>
        {
        }

        [Subject(typeof(DefaultInputModelMapper))]
        public class when_mapping_an_input_model_from_the_payload : concern
        {
            Establish c = () =>
            {
                payload = an<Payload>();
                mapper_registry = the_dependency<MapperRegistry>();
                the_mapped_model = new OurModel();
                input_values = new NameValueCollection();

                payload.Stub(x => x.input_values).Return(input_values);
                the_mapper = an<Mapper<NameValueCollection,OurModel>>();

                the_mapper.Stub(x => x.map_from(input_values)).Return(the_mapped_model);
                mapper_registry.Stub(x => x.get_mapper_to_map<NameValueCollection, OurModel>()).Return(the_mapper);

            };

            Because b = () =>
                result = sut.map_from<OurModel>(payload);

            It should_return_the_item_mapped_from_the_payloads_data_bag = () =>
                result.ShouldEqual(the_mapped_model);

            static OurModel result;
            static OurModel the_mapped_model;
            static Payload payload;
            static NameValueCollection input_values;
            static Mapper<NameValueCollection, OurModel> the_mapper;
            static MapperRegistry mapper_registry;
        }

        public class OurModel
        {
        }
    }
}