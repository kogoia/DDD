using System.Collections.Generic;

namespace AggregatRoot.Infrastructure.Event
{
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
        public IAppliedEventResult<TEntity> Appled()
        {
            return new AppliedEventResult<TEntity>(
                    _entity,
                    _evnts
                );
        }
    }
}
