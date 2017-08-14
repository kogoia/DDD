using System;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States.Types;

using DDD.Infrastructure.Infrastructure.Event;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class AppliedTabOpendEvent : Appliable<TabOpendEvent, TabType>
    {
        public AppliedTabOpendEvent(TabOpendEvent evnt, TabType tab) : base(evnt, tab) {}
        public AppliedTabOpendEvent(TabOpendEvent evnt, IApplicable<TabType> tab) : base(evnt, tab) {}

        protected override TabType When(TabOpendEvent evnt, TabType entity)
        {
            return entity
                .Match(
                    (dTab) => new TabType(dTab.Opened(evnt.Waiter)),
                    (oTab) => throw new Exception("Can't open OpendTab"),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }
    }
}
