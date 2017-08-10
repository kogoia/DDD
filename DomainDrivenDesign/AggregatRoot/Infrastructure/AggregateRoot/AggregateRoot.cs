using System.Collections.Generic;
using System.Linq;
using AggregatRoot.Infrastructure.DiscriminatedUnion;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Infrastructure.AggregateRoot
{
    public abstract class AggregateRoot<TEntity, TEntityEvent> : IAggregateRoot<TEntityEvent>
        where TEntityEvent : IUnion, IDomainEvent
    {
        private readonly IApplicable<TEntity> _entity;

        protected AggregateRoot(IApplicable<TEntity> entity)
        {
            _entity = entity;
        }

        protected abstract IApplicable<TEntity> Apply(TEntity entity, TEntityEvent evnt);
        public IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt)
        {
            var applied = _entity.Apply();
            return new FakeAggregateRoot<TEntity, TEntityEvent>(Apply, Apply(applied.Result(), evnt), applied.Event().Concat(new List<IDomainEvent>() { (IDomainEvent)evnt.Content() }));
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _entity.Apply().Event();
        }
    }

}
