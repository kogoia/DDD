using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Infrastructure;

namespace AggregatRoot.Domain.Tab.EventHandlers
{
    public class CreatedTab : IApplicable<States.Types.Tab>
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

        public AppliedEventResult<States.Types.Tab> Apply()
        {
            return new Applied<States.Types.Tab>(
                _evnt,
                new States.Types.Tab(
                    new DefaultTab(_evnt.TabId, _evnt.Name)
                )
            ).Apply();
        }
    }
}
