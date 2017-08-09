using System;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class AppliedTabOpendEvent : Appliable<TabOpendEvent, States.Types.Tab>
    {
        public AppliedTabOpendEvent(TabOpendEvent evnt, States.Types.Tab tab) : base(evnt, tab) {}
        public AppliedTabOpendEvent(TabOpendEvent evnt, IApplicable<States.Types.Tab> tab) : base(evnt, tab) {}

        protected override States.Types.Tab Apply(TabOpendEvent evnt, States.Types.Tab entity)
        {
            return entity
                .Match(
                    (dTab) => new States.Types.Tab(dTab.Opened(evnt.Waiter)),
                    (oTab) => throw new Exception("Can't open OpendTab"),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }
    }
}
