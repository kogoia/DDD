using System;
using System.Collections.Generic;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Domain.Tab.Events;
using DDD.Infrastructure.Infrastructure.Event;
using DDD.Infrastructure.Infrastructure.EventStream;

namespace AggregatRoot
{
    class Program
    {
        static void Main(string[] args)
        {

            var tabState = new TabState(1).FromJSON("{ \"Id\": 1, \"Number\": \"Vip-12\", \"Waiter\": \"asd\",\"Price\": 12.0}");
            var eventStore = new List<Tuple<int, IDomainEventType>>()
            {
                new Tuple<int, IDomainEventType>(
                    127, 
                    new TabEventType(
                        new TabCreatedEvent(127, "VIP-Table")
                    )
                ),
                new Tuple<int, IDomainEventType>(
                    127,
                    new TabEventType(
                        new TabOpendEvent("Saba")
                    )
                )
            };


            var eventStream = new EventStream(
                                127,
                                eventStore
                            );

            var events = new Tab(
                            eventStream
                         ).Apply(
                             new TabEventType(
                                 new TabClosedEvent(49.50m)
                             )
                         ).UncommitedEvents();

            new TabEventType()
            

            var events2 = new Tab(
                            127,
                            eventStore
                        ).Apply(
                            new TabEventType(
                                new TabClosedEvent(49.50m)
                            )
                        ).UncommitedEvents();

            Console.ReadLine();
        }
    }
}
