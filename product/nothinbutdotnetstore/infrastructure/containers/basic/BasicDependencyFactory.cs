using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyFactory : DependencyFactory
    {
    	private readonly Func<object> factory;

    	public BasicDependencyFactory(Func<object> factory)
		{
			this.factory = factory;
		}

    	public object create()
    	{
    		return factory();
    	}
    }
}