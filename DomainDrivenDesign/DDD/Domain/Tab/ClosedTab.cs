using DDD.Domain.Tab.Types;

namespace DDD.Domain.Tab
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
