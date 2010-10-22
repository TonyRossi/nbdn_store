using System;
using System.Linq.Expressions;
using System.Reflection;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.utility
{
    public static class ExpressionUtility
    {
        public static ConstructorInfo get_constructor_pointed_at_by<T>(Expression<Func<T>> ctor)
        {
            return ctor.Body.downcast_to<NewExpression>().Constructor;
        } 
    }
}