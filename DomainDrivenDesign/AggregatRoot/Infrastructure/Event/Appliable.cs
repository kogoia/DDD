using System.Collections.Generic;
using System.Linq;

namespace AggregatRoot.Infrastructure.Event
{

    public abstract class Appliable<TEntityEvent, TEntity> : IApplicable<TEntity>
        where TEntityEvent: IDomainEvent
    {
        private readonly IApplicable<TEntity> _entity;
        private readonly TEntityEvent _evnt;

        protected Appliable(TEntityEvent evnt, TEntity entity)
            : this(evnt, new Applied<TEntity>(entity))
        { }

        protected Appliable(TEntityEvent evnt, IApplicable<TEntity> entity)
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
}
