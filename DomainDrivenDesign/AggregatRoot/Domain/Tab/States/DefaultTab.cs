using AggregatRoot.Domain.Tab.States.Types;

namespace AggregatRoot.Domain.Tab.States
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
            return new OpendTab(
                        _state.WithwWiter(waiter)
                   );
        }
    }

}
