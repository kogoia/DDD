using System.Collections.Generic;

namespace AggregatRoot.Infrastructure
{
    public interface IAggregateRoot<in TEntityEvent>
        where TEntityEvent : IUnion, IDomainEvent
    {
        IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt);
        IEnumerable<IDomainEvent> UncommitedEvents();
    }

}
