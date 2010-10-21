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
            }


            public InputModel map<InputModel>() 
            {
                throw new NotImplementedException();
            }

            public string Url
            {
                get; private set;
            }
        }
    }
}