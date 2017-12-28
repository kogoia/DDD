using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DDD.Infrastructure
{
    public class NextState<TModel>
        where TModel : class
    {
		private readonly TModel _model;
		private readonly IEnumerable<IEvent<TModel>> _events;

        public NextState(IEvent<TModel> firstEvent, IEnumerable<IEvent<TModel>> events)
            : this(firstEvent.Handle(null), events)
        {

        }

        public NextState(TModel model, IEnumerable<IEvent<TModel>> events)
        {
            this._model = model;
            this._events = events;
        }

        public NextStateResult<TModel> State()
        {
            return new NextStateResult<TModel>(
                        _events.Aggregate(_model, (prev, next) => next.Handle(prev)), 
                        new [] { "" }
                    );
            }
        }
}
