using System;

namespace nothinbutdotnetstore.web.core
{
    public class Url
    {
        public static UrlBuilder<ViewModel> create_from<ViewModel>(ViewModel model)
        {
            return new UrlBuilder<ViewModel>(model);
        }
    }

    public class UrlBuilder<ViewModel>
    {
        public UrlBuilder(ViewModel model)
        {
            throw new NotImplementedException();
        }

        public UrlBuilder<ViewModel> include_in_payload(Func<ViewModel, object> property_accessor)
        {
            throw new NotImplementedException();
        }
    }
}