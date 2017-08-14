using System;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States.Types;
using DDD.Infrastructure.Infrastructure.Event;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class AppliedTabClosedEvent : Appliable<TabClosedEvent, TabType>
    {
        public AppliedTabClosedEvent(TabClosedEvent evnt, TabType tab) : base(evnt, tab) {}
        public AppliedTabClosedEvent(TabClosedEvent evnt, IApplicable<TabType> tab) : base(evnt, tab) {}
        protected override TabType When(TabClosedEvent evnt, TabType tab)
        {
            return tab
                .Match(
                    (dTab) => throw new Exception("Can't close DefaultTab"),
                    (oTab) => new TabType(oTab.Closed(evnt.Price)),
                    (cTab) => throw new Exception("Can't close ClosedTab")
                );
        }
    }
}
