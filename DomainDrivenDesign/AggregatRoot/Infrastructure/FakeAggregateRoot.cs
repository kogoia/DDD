using System;
using System.Collections.Generic;

namespace AggregatRoot.Infrastructure
{
    public class FakeAggregateRoot<TEntity, TEntityEvent> : IAggregateRoot<TEntityEvent>
         where TEntityEvent : IUnion, IDomainEvent
    {
        private readonly Func<TEntity, TEntityEvent, IApplicable<TEntity>> _f;
        private readonly IApplicable<TEntity> _entity;

        public FakeAggregateRoot(Func<TEntity, TEntityEvent, IApplicable<TEntity>> f, IApplicable<TEntity> entity)
        {
            _f = f;
            _entity = entity;
        }

        public IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt)
        {
            return new FakeAggregateRoot<TEntity, TEntityEvent>(_f, _f(_entity.Apply().Result(), evnt));
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _entity.Apply().Event();
        }
    }

}
