using AggregatRoot.Domain.Tab;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Events.Messages;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Events.Handlers
{
    public class CreatedTab : IApplicable<Tab>
    {
        private readonly TabCreatedEvent _evnt;

        public CreatedTab(int tabId, string tabNumber)
            : this(new TabCreatedEvent(tabId, tabNumber))
        {
        }

        public CreatedTab(TabCreatedEvent evnt)
        {
            _evnt = evnt;
        }

        public AppliedEventResult<Tab> Apply()
        {
            return new Applied<Tab>(
                _evnt,
                new Tab(
                    new DefaultTab(_evnt.TabId, _evnt.Name)
                )
            ).Apply();
        }
    }
}
