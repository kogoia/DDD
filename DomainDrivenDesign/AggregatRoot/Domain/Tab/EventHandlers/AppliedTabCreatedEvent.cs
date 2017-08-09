using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class AppliedTabCreatedEvent : Appliable<TabCreatedEvent, States.Types.Tab>
    {
        public AppliedTabCreatedEvent(int id, string number) 
            : this(new TabCreatedEvent(id, number)) {}
        public AppliedTabCreatedEvent(TabCreatedEvent evnt) : 
            this(
                    evnt, 
                    new Applied<States.Types.Tab>(
                        evnt,
                        new States.Types.Tab(
                            new DefaultTab(evnt.TabId, evnt.Name)
                        )
                    )
                )
        {
        }

        public AppliedTabCreatedEvent(TabCreatedEvent evnt, IApplicable<States.Types.Tab> entity) : base(evnt, entity)
        {
        }

        protected override States.Types.Tab Apply(TabCreatedEvent evnt, States.Types.Tab entity)
        {
            return entity;
        }

    }
}



