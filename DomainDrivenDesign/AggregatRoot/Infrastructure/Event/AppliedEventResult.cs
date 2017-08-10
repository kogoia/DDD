using System.Collections.Generic;

namespace AggregatRoot.Infrastructure.Event
{
    public class AppliedEventResult<TResult>
    {
        private readonly TResult _entity;
        private readonly IEnumerable<IDomainEvent> _evnt;

        public AppliedEventResult(TResult entity, IEnumerable<IDomainEvent> evnt)
        {
            _entity = entity;
            _evnt = evnt;
        }

        public TResult Result()
        {
            return _entity;
        }

        public IEnumerable<IDomainEvent> Event()
        {
            return _evnt;
        }
    }
}
