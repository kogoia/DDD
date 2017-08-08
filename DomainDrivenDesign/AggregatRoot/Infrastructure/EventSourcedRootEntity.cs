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
        TRoot
    >
        where TE1 : IEvent
        where TE2 : IEvent
    {
        protected TRoot _root;

        protected EventSourcedRootEntity(TRoot root)
        {
            _root = root;
        }
        private readonly List<IEvent> _events;

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
