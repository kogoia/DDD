using System.Collections;
using System.Collections.Generic;

namespace AggregatRoot.Infrastructure.Event
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
