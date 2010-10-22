using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.application.mappers
{
    public class InputKey<ValueKeyRepresents>
    {
        string key_name;

        public InputKey(string key_name)
        {
            this.key_name = key_name;
        }

        public static implicit operator string(InputKey<ValueKeyRepresents> input_key)
        {
            return input_key.ToString();
        }

        public override string ToString()
        {
            return this.key_name;
        }

        public ValueKeyRepresents map_from(NameValueCollection payload)
        {
            return (ValueKeyRepresents) Convert.ChangeType(payload[key_name], typeof(ValueKeyRepresents));
        }
    }
}