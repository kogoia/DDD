using System;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Events.Messages;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Events.Handlers
{
    public class AppliedTabOpendEvent : Appliable<TabOpendEvent, Tab>
    {
        public AppliedTabOpendEvent(TabOpendEvent evnt, Tab tab) : base(evnt, tab) {}
        public AppliedTabOpendEvent(TabOpendEvent evnt, IApplicable<Tab> tab) : base(evnt, tab) {}

        protected override Tab Apply(TabOpendEvent evnt, Tab entity)
        {
            return entity
                .Match(
                    (dTab) => new Tab(dTab.Opened(evnt.Waiter)),
                    (oTab) => throw new Exception("Can't open OpendTab"),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }
    }
}
