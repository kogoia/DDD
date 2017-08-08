using System;
using AggregatRoot.Infrastructure;
using AggregatRoot.Messages;
using System.Collections.Generic;

namespace AggregatRoot
{
    public class TabAggregateRoot : EventSourcedRootEntity
        <
            TabOpendEvent, 
            TabClosedEvent,
            TabCreatedEvent,
            Tab
        >
    {
        public TabAggregateRoot(IEnumerable<IDomainEvent> eventStream) : base(eventStream)
        {

        }

        public TabAggregateRoot(int tabId, string name)
            : base(new List<IDomainEvent>() { new TabCreatedEvent(tabId, name) })
        {
        }

        protected override Tab When(TabOpendEvent e)
        {
            return _root
                .Match(
                    (dTab) => new Tab(dTab.Opened()),
                    (oTab) => throw new Exception("Can't open OpendTab"),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }

        protected override Tab When(TabClosedEvent e)
        {
            return _root
                .Match(
                    (dTab) => throw new Exception("Can't open DefaultTab"),
                    (oTab) => new Tab(oTab.Closed()),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }

        protected override Tab When(TabCreatedEvent e)
        {
            return new Tab(
                        new DefaultTab(
                            e.TabId,
                            e.Name
                        )
                    );
        }
    }

}
