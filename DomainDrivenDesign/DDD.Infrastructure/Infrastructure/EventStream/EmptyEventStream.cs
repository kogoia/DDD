using System.Collections;
using System.Collections.Generic;
using DDD.Infrastructure.Infrastructure.Event;

namespace DDD.Infrastructure.Infrastructure.EventStream
{
    public class EmptyEventStream : IEventStream
    {
        public IEnumerator<IDomainEventType> GetEnumerator()
        {
            return new List<IDomainEventType>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
