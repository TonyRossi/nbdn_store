using System;
using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.web.application.mappers
{
    public class InputKeys
    {
        public class department
        {
            public static readonly InputKey<string> name = new InputKey<string>("name");
            public static readonly InputKey<string> address = new InputKey<string>("address");
            public static readonly InputKey<string> phone = new InputKey<string>("phone");
            public static readonly InputKey<DateTime> created_on = new InputKey<DateTime>("created_on");
            public static readonly InputKey<int> number_of_items = new InputKey<int>("number_of_items");
            public static readonly InputKey<Details> details = new InputKey<Details>("details");
        }
    }
}