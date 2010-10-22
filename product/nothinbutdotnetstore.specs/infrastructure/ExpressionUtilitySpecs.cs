using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ExpressionUtilitySpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(ExpressionUtility))]
        public class when_retrieving_the_name_of_a_property_from_an_expression : concern
        {
            Because b = () =>
                result = ExpressionUtility.get_name_of_property<OurClassWithValues>(x => x.the_name);

            It should_return_the_name_of_the_property_in_all_lowercase = () =>
                result.ShouldEqual("the_name");

            It should_be_able_to_add_two_numbers = () =>
            {
                Expression<Func<Department, bool>> the_criteria = x => x.name.StartsWith("blah")
                    && x.address.EndsWith("cool") || x.created_on > new DateTime(2010,10,10);



            };

            It should_be_able_to_build_code_dynamically = () =>
            {
                var number2 = Expression.Constant(2);
                var number3 = Expression.Constant(3);

                var add = Expression.Add(number2, number3);

                var add_2_numbers = Expression.Lambda<Func<int>>(add);

                var trigger = add_2_numbers.Compile();

                trigger().ShouldEqual(5);
            };

            static string result;
        }

        public class OurClassWithValues
        {
            public string the_name { get; set; }
        }
    }
}