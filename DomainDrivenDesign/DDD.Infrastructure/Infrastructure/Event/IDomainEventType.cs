using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DDD.Infrastructure.Infrastructure.DiscriminatedUnion;

namespace DDD.Infrastructure.Infrastructure.Event
{

    public interface IEventTypes : IEnumerable<string>
    {
    }

    public interface IDomainEventType
    {
        IEventTypes EventTypes();
    }

    public abstract class DomainEventType<T1, T2> : Union<T1, T2>, IDomainEventType
        where T1 : class, IDomainEvent
        where T2 : class, IDomainEvent
        
    {
        protected DomainEventType(T1 t1) : base(t1) {}
        protected DomainEventType(T2 t2) : base(t2) {}
        public IEventTypes EventTypes()
        {
            return new EventTypeNames(
                    typeof(T1),
                    typeof(T2)
                );
        }
    }

    public abstract class DomainEventType<T1, T2, T3> : Union<T1, T2, T3>, IDomainEventType
        where T1 : class, IDomainEvent
        where T2 : class, IDomainEvent
        where T3 : class, IDomainEvent

    {
        internal DomainEventType() : base((T1)null) {}
        protected DomainEventType(T1 t1) : base(t1) { }
        protected DomainEventType(T2 t2) : base(t2) { }
        protected DomainEventType(T3 t3) : base(t3) { }
        public IEventTypes EventTypes()
        {
            return new EventTypeNames(
                typeof(T1),
                typeof(T2),
                typeof(T3)
            );
        }
    }

    public class EventTypeNames : IEventTypes
    {
        private readonly IEnumerable<Type> _enventTypes;

        public EventTypeNames(params Type[] enventTypes)
        {
            _enventTypes = enventTypes;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _enventTypes
                .Select(et => et.Name)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
