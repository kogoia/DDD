using System.Collections.Generic;

namespace AggregatRoot.Infrastructure
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
            return new FakeAggregateRoot<TEntity, TEntityEvent>(Apply, Apply(_entity.Apply().Result(), evnt));
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _entity.Apply().Event();
        }
    }

}
