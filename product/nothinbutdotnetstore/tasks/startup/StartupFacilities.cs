using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupFacilities
    {
        void register<Contract, Implementation>();
        void register<Contract>(Contract instance);
        IDictionary<Type, DependencyFactory> original_factories { get; }
    }
}