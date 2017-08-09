using System.Collections.Generic;
using System.Linq;

namespace AggregatRoot.Infrastructure
{
    public interface IApplicable<TEntity>
    {
        AppliedEventResult<TEntity> Apply();
    }

    public abstract class Appliable<TEntityEvent, TEntity> : IApplicable<TEntity>
        where TEntityEvent: IDomainEvent
    {
        private readonly IApplicable<TEntity> _entity;
        private readonly TEntityEvent _evnt;

        public Appliable(TEntityEvent evnt, TEntity entity)
            : this(evnt, new Applied<TEntity>(entity))
        { }
        public Appliable(TEntityEvent evnt, IApplicable<TEntity> entity)
        {
            _entity = entity;
            _evnt = evnt;
        }

        protected abstract TEntity Apply(TEntityEvent evnt, TEntity entity);
        public AppliedEventResult<TEntity> Apply()
        {
            var applied = _entity.Apply();
            return new AppliedEventResult<TEntity>(
                    Apply(_evnt, applied.Result()),
                    applied
                        .Event()
                        .Concat(new List<IDomainEvent>() { _evnt })
                );
        }
    }

    public class Applied<TEntity> : IApplicable<TEntity>
    {
        private readonly IEnumerable<IDomainEvent> _evnts;
        private readonly TEntity _entity;

        public Applied(TEntity entity)
            : this(new IDomainEvent[] {}, entity)
        {
            
        }
        public Applied(IDomainEvent evnt, TEntity entity)
            : this(new [] { evnt }, entity)
        {
        }

        public Applied(IEnumerable<IDomainEvent> evnts, TEntity entity)
        {
            _evnts = evnts;
            _entity = entity;
        }
        public AppliedEventResult<TEntity> Apply()
        {
            return new AppliedEventResult<TEntity>(
                    _entity,
                    _evnts
                );
        }
    }
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
