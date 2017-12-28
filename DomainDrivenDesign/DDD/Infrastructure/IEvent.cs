using System;
using System.Collections.Generic;
using System.Text;

namespace DDD
{
	public interface IEvent<TModel>
	{
		TModel Handle(TModel model);
		string Serialazed();
	}
}
