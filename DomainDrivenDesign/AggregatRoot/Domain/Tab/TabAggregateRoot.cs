using AggregatRoot.Domain.Tab.EventHandlers;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Domain.Tab
{

    public class TabAggregateRoot : AggregateRoot<States.Types.Tab, TabEvent>
    {
        public TabAggregateRoot(IApplicable<States.Types.Tab> entity) : base(entity) {}

        protected override IApplicable<States.Types.Tab> Apply(States.Types.Tab tab, TabEvent evnt)
        {
            return evnt
                .Match<IApplicable<States.Types.Tab>>(
                    toe => new AppliedTabOpendEvent(toe, tab),
                    tce => new AppliedTabClosedEvent(tce, tab),
                    tcre => new AppliedTabCreatedEvent(tcre)
                );
        }
    }
}
