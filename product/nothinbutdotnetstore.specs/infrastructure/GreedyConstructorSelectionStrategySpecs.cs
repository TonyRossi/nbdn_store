using System;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.specs.utility;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class GreedyConstructorSelectionStrategySpecs
    {
        public abstract class concern : Observes<ConstructorSelectionStrategy, GreedyConstructorSelectionStrategy>
        {
        }

        [Subject(typeof(GreedyConstructorSelectionStrategy))]
        public class when_getting_a_constructor_for_a_type_that_has_one_constructor : concern
        {
            Establish c = () =>
            {
                dependency_type = typeof(MyType);
                expected_constructor = ExpressionUtility.get_constructor_pointed_at_by(() => new MyType(0));
            };

            Because b = () =>
                        result = sut.get_applicable_constructor_on(dependency_type);

            It should_return_that_one_constructor = () =>
                                                                  result.ShouldEqual(expected_constructor);

            static Type dependency_type;
            static ConstructorInfo result;
            private static ConstructorInfo expected_constructor;

            public class MyType
            {
                public MyType(int dummy)
                {
                }
            }
        }

        [Subject(typeof(GreedyConstructorSelectionStrategy))]
        public class when_getting_a_constructor_for_a_type_that_has_no_constructors_defined : concern
        {
            Establish c = () =>
            {
                dependency_type = typeof(MyType);
                expected_constructor = ExpressionUtility.get_constructor_pointed_at_by(() => new MyType());
            };

            Because b = () =>
                        result = sut.get_applicable_constructor_on(dependency_type);

            It should_return_the_default_constructor = () =>
                                                                  result.ShouldEqual(expected_constructor);

            static Type dependency_type;
            static ConstructorInfo result;
            private static ConstructorInfo expected_constructor;

            public class MyType
            {
            }
        }


        [Subject(typeof(GreedyConstructorSelectionStrategy))]
        public class when_getting_a_constructor_for_a_type_that_has_mutiple_constructors_defined : concern
        {
            Establish c = () =>
            {
                dependency_type = typeof(MyType);
                expected_constructor = ExpressionUtility.get_constructor_pointed_at_by(() => new MyType(null, null));
            };

            Because b = () =>
                        result = sut.get_applicable_constructor_on(dependency_type);

            It should_return_the_constructor_with_the_most_arguments = () =>
                                                                  result.ShouldEqual(expected_constructor);

            static Type dependency_type;
            static ConstructorInfo result;
            private static ConstructorInfo expected_constructor;

            public class MyType
            {
                public MyType(object obj1)
                {
                    
                }

                public MyType(object obj1, object  obj2)
                {

                }
            }
        }
    }
}