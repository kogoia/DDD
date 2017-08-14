using System.Collections.Generic;
using DDD.Infrastructure.Infrastructure.Event;

namespace DDD.Infrastructure.Infrastructure.EventStream
{
    public interface IEventStream : IEnumerable<IDomainEventType>
    {
    }
}
