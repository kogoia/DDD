using AggregatRoot.Domain.Tab.EventHandlers;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Infrastructure;
using AggregatRoot.Domain.Tab.States.Types;

namespace AggregatRoot.Domain.Tab
{

    public class TabAggregateRoot : AggregateRoot<TabType, TabEvent>
    {
        public TabAggregateRoot(IApplicable<TabType> entity) : base(entity) {}

        protected override IApplicable<TabType> Apply(TabType tab, TabEvent evnt)
        {
            return evnt
                .Match<IApplicable<TabType>>(
                    toe => new AppliedTabOpendEvent(toe, tab),
                    tce => new AppliedTabClosedEvent(tce, tab),
                    tcre => new AppliedTabCreatedEvent(tcre)
                );
        }
    }
}
