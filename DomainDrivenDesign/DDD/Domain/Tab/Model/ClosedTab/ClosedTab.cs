namespace DDD.Domain.Tab.Model.ClosedTab
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
