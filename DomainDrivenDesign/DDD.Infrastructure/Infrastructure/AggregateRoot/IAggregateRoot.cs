using System.Collections.Generic;
using DDD.Infrastructure.Infrastructure.Event;
using DiscriminatedUnion;

namespace DDD.Infrastructure.Infrastructure.AggregateRoot
{
    public interface IAggregateRoot
    {
        //IEventTypes EventTypes();
    }
    public interface IAggregateRoot<in TEventType> : IAggregateRoot
        where TEventType : IUnion, IDomainEventType
    {
        IAggregateRoot<TEventType> Apply(TEventType evnt);
        IEnumerable<IDomainEvent> UncommitedEvents();
    }

}
