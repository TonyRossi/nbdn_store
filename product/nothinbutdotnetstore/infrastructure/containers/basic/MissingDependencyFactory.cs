using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class MissingDependencyFactory : DependencyFactory
    {
        const string exception_message_format = "There was no dependency factory configured for the type:{0}";

        public Type type_that_has_no_dependency_factory { get; private set; }

        public MissingDependencyFactory(Type dependency_type)
        {
            this.type_that_has_no_dependency_factory = dependency_type;
        }

        public object create()
        {
            throw new Exception(string.Format(exception_message_format,type_that_has_no_dependency_factory.FullName));
        }
    }
}