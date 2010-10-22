using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyFactory : DependencyFactory
    {
    	private readonly Func<object> _dependency;

    	public BasicDependencyFactory(Func<object> dependency)
		{
			_dependency = dependency;
		}

    	public object create()
    	{
    		return _dependency();
    	}
    }
}