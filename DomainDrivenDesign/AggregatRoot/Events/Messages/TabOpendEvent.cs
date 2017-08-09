using AggregatRoot.Infrastructure;

namespace AggregatRoot.Events.Messages
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
