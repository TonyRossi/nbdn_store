using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.infrastructure
{
    public static class ExpressionUtility
    {
        public static string get_name_of_property<T>(Expression<Func<T, object>> property_accessor)
        {
            return ((MemberExpression) property_accessor.Body).Member.Name;
        }

        public static Expression<Func<T,object>> get_the_expression_of<T>(Expression<Func<T, object>> accessor)
        {
            return accessor;
        }
    }
}