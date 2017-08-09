using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregatRoot.Infrastructure
{
    public class FakeAggregateRoot<TEntity, TEntityEvent> : IAggregateRoot<TEntityEvent>
         where TEntityEvent : IUnion, IDomainEvent
    {
        private readonly Func<TEntity, TEntityEvent, IApplicable<TEntity>> _f;
        private readonly IApplicable<TEntity> _entity;
        private readonly IEnumerable<IDomainEvent> _ucommetedEvents;
        public FakeAggregateRoot(Func<TEntity, TEntityEvent, IApplicable<TEntity>> f, IApplicable<TEntity> entity)
            : this(f, entity, new List<IDomainEvent>())
        {
        }

        public FakeAggregateRoot(Func<TEntity, TEntityEvent, IApplicable<TEntity>> f, IApplicable<TEntity> entity, IEnumerable<IDomainEvent> ucommetedEvents)
        {
            _f = f;
            _entity = entity;
            _ucommetedEvents = ucommetedEvents;
        }

        public IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt)
        {
            var applied = _entity.Apply();
            _ucommetedEvents.ToList().Add((IDomainEvent)evnt.Content());
            return new FakeAggregateRoot<TEntity, TEntityEvent>(_f, _f(applied.Result(), evnt), _ucommetedEvents);
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _ucommetedEvents;
            return _entity.Apply().Event();
        }
    }

}
