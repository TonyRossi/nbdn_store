using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{
    public class DefaultRequest : Request
    {
        InputModelMapper input_model_mapper;
        Payload payload;

        public DefaultRequest(InputModelMapper input_model_mapper, Payload payload)
        {
            this.input_model_mapper = input_model_mapper;
            this.payload = payload;
        }

        public InputModel map<InputModel>()

        {
            return input_model_mapper.map_from<InputModel>(this.payload);
        }
    }
}