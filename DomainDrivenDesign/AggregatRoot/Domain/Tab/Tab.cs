using System;
using System.Collections.Generic;
using System.Threading;
using AggregatRoot.Domain.Tab.EventHandlers;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Domain.Tab.States.Types;
using DDD.Infrastructure.Infrastructure.AggregateRoot;
using DDD.Infrastructure.Infrastructure.Event;
using DDD.Infrastructure.Infrastructure.EventStream;

namespace AggregatRoot.Domain.Tab
{

    public class Tab : AggregateRoot<TabType, TabEventType>
    {
        public Tab(int tabId, List<Tuple<int, IDomainEventType>> store)
            : this(new EventStream(tabId, store)) {}
        public Tab(IEventStream eventStream)
            : this(new EmptyApplicable<TabType>(), eventStream) {}
        public Tab(int id, string number) :
            this(new AppliedTabCreatedEvent(id, number)) {}
        public Tab(IApplicable<TabType> entity) 
            : this(entity, new EmptyEventStream()) { }
        public Tab(IApplicable<TabType> entity, IEventStream eventStream) : base(entity, eventStream) {}

        protected override IApplicable<TabType> When(TabType tab, TabEventType evnt)
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
