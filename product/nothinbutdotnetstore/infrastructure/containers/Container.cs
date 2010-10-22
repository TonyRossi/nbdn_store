using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static ContainerResolver container_resolver =
            delegate { throw new NotImplementedException("This has to be configured by a startup process"); };

        public static DependencyContainer retrieve
        {
            get { return container_resolver(); }
        }
    }
}