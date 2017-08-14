using System;
using System.Collections.Generic;
using DDD.Infrastructure.Infrastructure.Event;

namespace DDD.Infrastructure.Infrastructure.EventStore
{
    public interface IEventStore
    {
        IEnumerable<IDomainEventType> Events(int rootId);
    }

    public class FakeEventStore : IEventStore
    {
        public IEnumerable<IDomainEventType> Events(int rootId)
        {
            throw new NotImplementedException();
        }
    }
}
