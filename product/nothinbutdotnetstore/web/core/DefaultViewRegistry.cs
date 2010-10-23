using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewRegistry : ViewRegistry
    {
        IDictionary<Type, string> views;

        public DefaultViewRegistry(IDictionary<Type, string> views)
        {
            this.views = views;
        }

        public string get_the_path_to_the_view_that_can_display<ViewModel>()
        {
            return views[typeof(ViewModel)];
        }
    }
}