using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Infrastructure.Infrastructure.DiscriminatedUnion;
using DDD.Infrastructure.Infrastructure.Event;

namespace DDD.Infrastructure.Infrastructure.AggregateRoot
{
    public class FakeAggregateRoot<TEntity, TEventType> : IAggregateRoot<TEventType>
         where TEventType : IUnion, IDomainEventType
    {
        private readonly Func<TEntity, TEventType, IApplicable<TEntity>> _f;
        private readonly IApplicable<TEntity> _entity;
        private readonly IEnumerable<IDomainEvent> _ucommetedEvents;
        public FakeAggregateRoot(Func<TEntity, TEventType, IApplicable<TEntity>> f, IApplicable<TEntity> entity)
            : this(f, entity, new List<IDomainEvent>())
        {
        }

        public FakeAggregateRoot(Func<TEntity, TEventType, IApplicable<TEntity>> f, IApplicable<TEntity> entity, IEnumerable<IDomainEvent> ucommetedEvents)
        {
            _f = f;
            _entity = entity;
            _ucommetedEvents = ucommetedEvents;
        }

        public IAggregateRoot<TEventType> Apply(TEventType evnt)
        {
            var applied = _entity.Appled();
            _ucommetedEvents.ToList().Add((IDomainEvent)evnt.Content());
            return new FakeAggregateRoot<TEntity, TEventType>(_f, _f(applied.Result(), evnt), _ucommetedEvents);
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _ucommetedEvents;
        }
    }

}
