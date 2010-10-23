using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StringToTypeMapper : Mapper<string,Type>
    {
        public Type map_from(string input)
        {
            throw new NotImplementedException();
        }
    }
}