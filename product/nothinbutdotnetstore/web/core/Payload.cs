using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public interface Payload
    {
        NameValueCollection input_values { get;  }
    }
}