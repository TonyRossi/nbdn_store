using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException: Exception
    {
        public Type type_that_could_not_be_created { get; set; }

        public DependencyCreationException(Exception inner_exception, Type type_that_could_not_be_created) : base(string.Empty, inner_exception)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created;
        }
    }
}