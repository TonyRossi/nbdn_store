using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException: Exception
    {
        public DependencyCreationException(string message, Exception innerException, Type typeThatCouldNotBeCreated) : base(message, innerException)
        {
            type_that_could_not_be_created = typeThatCouldNotBeCreated;
        }

        public Type type_that_could_not_be_created { get; set; }
    }
}