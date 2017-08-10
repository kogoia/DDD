using System.Collections.Generic;
using AggregatRoot.Infrastructure.DiscriminatedUnion;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Infrastructure.AggregateRoot
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
