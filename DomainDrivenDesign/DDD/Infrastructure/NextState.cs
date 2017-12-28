using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD
{
    public class NextState<TModel>
    {
		private readonly TModel model;
		private readonly IEnumerable<IEvent<TModel>> events;

		public NextState(TModel model, IEnumerable<IEvent<TModel>> events)
		{
			this.model = model;
			this.events = events;
		}
		public NextStateResult<TModel> State()
		{
			;
			return new NextStateResult<TModel>(
						events.Aggregate(model, (prev, next) => next.Handle(prev)), 
						new string[] { "" }
					);
		}
    }
}
