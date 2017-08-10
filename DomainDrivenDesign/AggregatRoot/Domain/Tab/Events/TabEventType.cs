using AggregatRoot.Infrastructure;
using AggregatRoot.Infrastructure.DiscriminatedUnion;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Domain.Tab.Events
{
    public class TabEventType : DomainEventType<TabOpendEvent, TabClosedEvent, TabCreatedEvent>
    {
        public TabEventType(TabOpendEvent t1) : base(t1)
        {
        }

        public TabEventType(TabClosedEvent t2) : base(t2)
        {
        }

        public TabEventType(TabCreatedEvent t3) : base(t3)
        {
        }
    }
}
