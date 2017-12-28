
using DDD.Infrastructure;

namespace DDD.Domain.Tab.Events
{
    public class TabCreatedEvent : IEvent<Tab>
    {
        public int TabId { get; }
        public string Name { get;  }
        public TabCreatedEvent(int tabId, string name)
        {
            TabId = tabId;
            Name = name;
        }

        public Tab Handle(Tab model)
        {
            throw new System.NotImplementedException();
        }

        public string Serialazed()
        {
            throw new System.NotImplementedException();
        }
    }
}