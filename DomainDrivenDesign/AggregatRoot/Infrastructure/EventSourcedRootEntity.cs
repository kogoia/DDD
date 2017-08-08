using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Messages;

namespace AggregatRoot.Infrastructure
{
    public abstract class EventSourcedRootEntity
       <
           TE1,
           TE2,
           TE3,
           TRoot
       >
       where TE1 : IDomainEvent
       where TE2 : IDomainEvent
       where TE3 : IDomainEvent
    {
        protected TRoot _root;

        protected EventSourcedRootEntity(
                IEnumerable<IDomainEvent> eventStream
            )
        {
            _root = eventStream.Select(e => When((dynamic)e)).First();
        }
        private readonly List<IDomainEvent> _events;

        protected abstract TRoot When(TE1 e);
        protected abstract TRoot When(TE2 e);
        protected abstract TRoot When(TE3 e);
        public EventSourcedRootEntity
        <
           TE1,
           TE2,
           TE3,
           TRoot
        > Apply(TE1 e)
        {
            _events.Add(e);
            _root = When(e);
            return this;
        }

        public EventSourcedRootEntity
        <
           TE1,
           TE2,
           TE3,
           TRoot    
        > Apply(TE2 e)
        {
            _events.Add(e);
            _root = When(e);
            return this;
        }

        public EventSourcedRootEntity
        <
            TE1,
            TE2,
            TE3,
            TRoot
        > Apply(TE3 e)
        {
            _events.Add(e);
            _root = When(e);
            return this;
        }
    }


    public abstract class EventSourcedRootEntity
    <
        TE1,
        TE2,
        TRoot
    >
        where TE1 : IDomainEvent
        where TE2 : IDomainEvent
    {
        protected TRoot _root;

        protected EventSourcedRootEntity(TRoot root)
        {
            _root = root;
        }
        private readonly List<IDomainEvent> _events;

        protected abstract TRoot When(TE1 e);
        protected abstract TRoot When(TE2 e);

        public EventSourcedRootEntity
        <
            TE1,
            TE2,
            TRoot
        > Apply(TE1 e)
        {
            _events.Add(e);
            _root = When(e);
            return this;
        }

        public EventSourcedRootEntity
        <
            TE1,
            TE2,
            TRoot
        > Apply(TE2 e)
        {
            _events.Add(e);
            _root = When(e);
            return this;
        }
    }
}
