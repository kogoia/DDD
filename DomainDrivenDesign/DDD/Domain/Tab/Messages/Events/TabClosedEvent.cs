using System;
using DDD.Infrastructure;

namespace DDD.Domain.Tab.Messages.Events
{
    public class TabClosedEvent : IEvent<Tab>
    {
        public decimal Price { get; }
        public TabClosedEvent(decimal price)
        {
            Price = price;
        }

		public Tab Handle(Tab model)
		{
            return model
                .Match(
                    (dTab) => throw new Exception("Can't close DefaultTab"),
                    (oTab) => new Tab(oTab.Closed(Price)),
                    (cTab) => throw new Exception("Can't close ClosedTab")
                );
        }

        public string Serialazed()
        {
	        throw new System.NotImplementedException();
        }
	}
}
