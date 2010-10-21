using System;
using System.Web;
using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {

        public Request create_request_from(HttpContext http_context)
        {
            return new StubRequest(http_context.Request);
        }

        class StubRequest : Request
        {
            public StubRequest(HttpRequest request)
            {
                Url = request.Url.ToString();
                QueryString = request.Url.Query.Trim('?').Split('&');

            }

            public string[] QueryString
            {
                get;
                private set;
            }

            public InputModel map<InputModel>() where InputModel :new()
            {
                return new InputModel();
            }

            public string Url
            {
                get; private set;
            }
        }
    }
}