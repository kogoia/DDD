﻿using AggregatRoot.Infrastructure;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Domain.Tab.Events
{
    public class TabOpendEvent : IDomainEvent
    {
        public string Waiter { get; }

        public TabOpendEvent(string waiter)
        {
            Waiter = waiter;
        }
    }
}
