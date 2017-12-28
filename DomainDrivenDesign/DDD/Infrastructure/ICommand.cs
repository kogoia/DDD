using System;
using System.Collections.Generic;
using System.Text;

namespace DDD
{
	public interface ICommand<TModel> : IEnumerable<IEvent<TModel>>
	{

	}

}
