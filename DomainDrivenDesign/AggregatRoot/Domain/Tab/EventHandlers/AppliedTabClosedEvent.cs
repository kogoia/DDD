using System;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class AppliedTabClosedEvent : Appliable<TabClosedEvent, States.Types.Tab>
    {
        public AppliedTabClosedEvent(TabClosedEvent evnt, States.Types.Tab tab) : base(evnt, tab) {}
        public AppliedTabClosedEvent(TabClosedEvent evnt, IApplicable<States.Types.Tab> tab) : base(evnt, tab) {}
        protected override States.Types.Tab Apply(TabClosedEvent evnt, States.Types.Tab tab)
        {
            return tab
                .Match(
                    (dTab) => throw new Exception("Can't close DefaultTab"),
                    (oTab) => new States.Types.Tab(oTab.Closed()),
                    (cTab) => throw new Exception("Can't close ClosedTab")
                );
        }
    }
}
