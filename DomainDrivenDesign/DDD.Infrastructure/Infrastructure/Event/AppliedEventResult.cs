using System.Collections.Generic;

namespace DDD.Infrastructure.Infrastructure.Event
{
    public interface IAppliedEventResult<out TResult>
    {
        TResult Result();
        IEnumerable<IDomainEvent> Events();
    }
    public class AppliedEventResult<TResult> : IAppliedEventResult<TResult>
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

        public IEnumerable<IDomainEvent> Events()
        {
            return _evnt;
        }
    }

    public class AppliedEventEmptyResult<TResult> : IAppliedEventResult<TResult>
        where TResult : class
    {
        public TResult Result()
        {
            return null;
        }

        public IEnumerable<IDomainEvent> Events()
        {
            return new List<IDomainEvent>();
        }
    }
}
