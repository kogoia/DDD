using System.Collections.Generic;
using AggregatRoot.Infrastructure.DiscriminatedUnion;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Infrastructure.AggregateRoot
{
    public interface IAggregateRoot<in TEntityEvent>
        where TEntityEvent : IUnion, IDomainEvent
    {
        IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt);
        IEnumerable<IDomainEvent> UncommitedEvents();
    }

}
