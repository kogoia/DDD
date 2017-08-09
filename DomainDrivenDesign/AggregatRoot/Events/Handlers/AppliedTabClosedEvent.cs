using System;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Events.Messages;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Events.Handlers
{
    public class AppliedTabClosedEvent : Appliable<TabClosedEvent, Tab>
    {
        public AppliedTabClosedEvent(TabClosedEvent evnt, Tab tab) : base(evnt, tab) {}
        public AppliedTabClosedEvent(TabClosedEvent evnt, IApplicable<Tab> tab) : base(evnt, tab) {}
        protected override Tab Apply(TabClosedEvent evnt, Tab tab)
        {
            return tab
                .Match(
                    (dTab) => throw new Exception("Can't close DefaultTab"),
                    (oTab) => new Tab(oTab.Closed()),
                    (cTab) => throw new Exception("Can't close ClosedTab")
                );
        }
    }
}
