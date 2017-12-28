
using DDD.Domain.Tab.Model.DefaultTab;
using DDD.Infrastructure;

namespace DDD.Domain.Tab.Messages.Events
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
            return new Tab(
                        new DefaultTab(TabId, Name)
                    );
        }

        public string Serialazed()
        {
            throw new System.NotImplementedException();
        }
    }
}