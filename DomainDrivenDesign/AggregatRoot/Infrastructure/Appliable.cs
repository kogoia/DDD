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
        private readonly TEntity _entity;
        private readonly IDomainEvent _evnt;

        public Applied(TEntity entity)
            : this(null, entity)
        {
            
        }
        public Applied(IDomainEvent evnt, TEntity entity)
        {
            _entity = entity;
            _evnt = evnt;
        }
        public AppliedEventResult<TEntity> Apply()
        {
            return new AppliedEventResult<TEntity>(
                    _entity, 
                    new List<IDomainEvent>() { _evnt }
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
