using DDD.Domain.Tab.Model.ClosedTab;

namespace DDD.Domain.Tab.Model.OpendTab
{
    public class OpendTab : IOpendTab
    {
        private readonly TabState _state;

        public OpendTab(TabState state)
        {
            _state = state;
        }
        public IClosedTab Closed(decimal price)
        {
            return new ClosedTab.ClosedTab(
                    _state,
                    price
                );
        }
    }

}
