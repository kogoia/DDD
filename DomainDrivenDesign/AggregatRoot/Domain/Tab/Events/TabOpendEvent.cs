using AggregatRoot.Infrastructure;

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
