
using DDD.Infrastructure.Infrastructure.Event;

namespace AggregatRoot.Domain.Tab.Events
{
    public class TabClosedEvent : IDomainEvent
    {
        public decimal Price { get; }
        public TabClosedEvent(decimal price)
        {
            Price = price;
        }
    }
}
