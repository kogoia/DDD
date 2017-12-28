using DDD.Domain.Tab.Model.OpendTab;

namespace DDD.Domain.Tab.Model.DefaultTab
{
    public class DefaultTab : IDefaultTab
    {
        private readonly TabState _state;

        public DefaultTab(int tabId, string name)
            :this(new TabState(tabId)) { }

        public DefaultTab(TabState state, string number)
            : this(state.WithNumber(number))
        {
            
        }
        public DefaultTab(TabState state)
        {
            _state = state;
        }

        public IOpendTab Opened(string waiter)
        {
            return new OpendTab.OpendTab(
                        _state.WithwWiter(waiter)
                   );
        }
    }

}
