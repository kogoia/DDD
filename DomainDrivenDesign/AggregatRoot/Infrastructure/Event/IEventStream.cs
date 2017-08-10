using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Infrastructure.Event
{
    public interface IEventStream : IEnumerable<IDomainEventType>
    {
    }

    public class EventStream : IEventStream
    {
        private readonly IEnumerable<IDomainEventType> _events;

        public EventStream(params IDomainEventType[] events)
        {
            _events = events;
        }
        public IEnumerator<IDomainEventType> GetEnumerator()
        {
            return _events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

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
