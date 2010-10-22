using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface DependencyContainer
    {
        Dependency an<Dependency>();
        object an(Type dependency_type);
    }
}