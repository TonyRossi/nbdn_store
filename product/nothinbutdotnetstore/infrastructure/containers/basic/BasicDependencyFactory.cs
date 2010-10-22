using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicDependencyFactory : DependencyFactory
    {
    	private readonly Func<object> _connection;

    	public BasicDependencyFactory(Func<object> connection)
		{
			_connection = connection;
		}

    	public object create()
    	{
    		return _connection();
    	}
    }
}