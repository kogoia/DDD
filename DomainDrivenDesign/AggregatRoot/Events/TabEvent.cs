﻿using AggregatRoot.Events.Messages;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Events
{
    public class TabEvent : Union<TabOpendEvent, TabClosedEvent, TabCreatedEvent>
    {
        public TabEvent(TabOpendEvent t1) : base(t1)
        {
        }

        public TabEvent(TabClosedEvent t2) : base(t2)
        {
        }

        public TabEvent(TabCreatedEvent t3) : base(t3)
        {
        }
    }
}
