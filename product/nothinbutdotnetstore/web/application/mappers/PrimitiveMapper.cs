using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.application.mappers
{
    public class PrimitiveMapper<ConvertibleType> : Mapper<string,ConvertibleType> where ConvertibleType
        : IConvertible
    {
        public ConvertibleType map_from(string input)
        {
            return (ConvertibleType)Convert.ChangeType(input, typeof(ConvertibleType));
        }
    }
}