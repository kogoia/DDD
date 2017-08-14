using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DDD.Infrastructure.Infrastructure.Event;

namespace DDD.Infrastructure.Infrastructure.EventStream
{
    public class EventStream : IEventStream
    {
        private readonly Lazy<IEnumerable<IDomainEventType>> _lazyEvents;

        public EventStream(int rootId, List<Tuple<int, IDomainEventType>> store)
            : this(() => store.Where(s => s.Item1 == rootId).Select(s => s.Item2)) {}

        public EventStream(params IDomainEventType[] events)
            : this(() => events) {}


        private EventStream(Func<IEnumerable<IDomainEventType>> func) 
            : this(new Lazy<IEnumerable<IDomainEventType>>(func)) {}

        private EventStream(Lazy<IEnumerable<IDomainEventType>> lazyEvents)
        {
            _lazyEvents = lazyEvents;
        }
        public IEnumerator<IDomainEventType> GetEnumerator()
        {
            return _lazyEvents.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
