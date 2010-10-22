using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    [Register]
    public class DefaultInputModelMapper : InputModelMapper
    {
        MapperRegistry mapper_registry;

        public DefaultInputModelMapper(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public InputModel map_from<InputModel>(Payload payload)
        {
            return mapper_registry.get_mapper_to_map<NameValueCollection, InputModel>()
                .map_from(payload.input_values);
        }
    }
}