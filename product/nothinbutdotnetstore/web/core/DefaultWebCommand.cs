using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultWebCommand : WebCommand
    {
    	private RequestCriteria criteria;

		public DefaultWebCommand(RequestCriteria criteria)
		{
			this.criteria = criteria;
		}

    	public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(Request request)
        {
        	return criteria(request);
        }
    }
}