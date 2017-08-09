using AggregatRoot.Domain.Tab.States.Types;

namespace AggregatRoot.Domain.Tab.States
{
    public class ClosedTab : IClosedTab
    {
        private readonly TabState _state;

        public ClosedTab(TabState state)
        {
            _state = state;
        }
        public ClosedTab(TabState state, decimal price)
            : this(state.WithPrice(price))
        {
        }
    }

}
