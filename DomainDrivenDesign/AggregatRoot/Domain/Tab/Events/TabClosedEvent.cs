using AggregatRoot.Infrastructure;

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
