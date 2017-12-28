using System.Collections.Generic;

namespace DDD.Infrastructure
{
	public interface ICommand<TModel> : IEnumerable<IEvent<TModel>>
	{

	}

}
