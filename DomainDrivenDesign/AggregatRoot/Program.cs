using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Domain.Tab.EventHandlers;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Domain.Tab.States.Types;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            //new TabType(
            //    new ClosedTab(
            //        new TabState(127)
            //    )
            //);

            //new AppliedTabOpendEvent(
            //    new TabOpendEvent("Saba"),
            //    new AppliedTabCreatedEvent(127, "VIP-Table")
            //);


            var eventStream = new EventStream(
                                new TabEventType(
                                    new TabCreatedEvent(127, "VIP-Table")
                                ),
                                new TabEventType(
                                    new TabOpendEvent("Saba")
                                )
                                //new TabEventType(
                                //    new TabClosedEvent(49.50m)
                                //)
                            );

            var events = new Tab(
                            eventStream//new AppliedTabCreatedEvent(127, "VIP-Table
                         ).Apply(
                             new TabEventType(
                                 new TabClosedEvent(49.50m)
                             )
                         ).UncommitedEvents();

            Console.ReadLine();
        }
    }
}
