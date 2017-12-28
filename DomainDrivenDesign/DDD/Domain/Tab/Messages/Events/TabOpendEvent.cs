using System;
using DDD.Infrastructure;

namespace DDD.Domain.Tab.Messages.Events
{
    public class TabOpendEvent : IEvent<Tab>
    {
        public string Waiter { get; }

        public TabOpendEvent(string waiter)
        {
            Waiter = waiter;
        }

        public Tab Handle(Tab model)
        {
            return model
                .Match(
                    (dTab) => new Tab(dTab.Opened(Waiter)),
                    (oTab) => throw new Exception("Can't open OpendTab"),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }

        public string Serialazed()
        {
            throw new NotImplementedException();
        }
    }
}
