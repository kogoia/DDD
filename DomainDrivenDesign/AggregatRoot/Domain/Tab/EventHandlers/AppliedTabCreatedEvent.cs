using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Domain.Tab.States.Types;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class AppliedTabCreatedEvent : Appliable<TabCreatedEvent, TabType>
    {
        public AppliedTabCreatedEvent(int id, string number) 
            : this(new TabCreatedEvent(id, number)) {}
        public AppliedTabCreatedEvent(TabCreatedEvent evnt) : 
            this(
                    evnt, 
                    new Applied<TabType>(
                        evnt,
                        new TabType(
                            new DefaultTab(evnt.TabId, evnt.Name)
                        )
                    )
                )
        {
        }

        public AppliedTabCreatedEvent(TabCreatedEvent evnt, IApplicable<TabType> entity) : base(evnt, entity)
        {
        }

        protected override TabType Apply(TabCreatedEvent evnt, TabType entity)
        {
            return entity;
        }

    }
}



