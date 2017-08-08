using AggregatRoot.Messages;

namespace AggregatRoot
{
    public class TabCreatedEvent : IDomainEvent
    {
        public int TabId { get; }
        public string Name { get;  }
        public TabCreatedEvent(int tabId, string name)
        {
            TabId = tabId;
            Name = name;
        }
    }
}