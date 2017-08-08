using System;
using AggregatRoot.Infrastructure;
using AggregatRoot.Messages;

namespace AggregatRoot
{
    public class TabAggregateRoot : EventSourcedRootEntity
        <
            TabOpendEvent, 
            TabClosedEvent, 
            Tab
        >
    {
        public TabAggregateRoot(Tab root) : base(root)
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
    }

}
