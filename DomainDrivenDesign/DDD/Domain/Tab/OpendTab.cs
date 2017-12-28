using DDD.Domain.Tab.Types;

namespace DDD.Domain.Tab
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
            return new ClosedTab(
                    _state,
                    price
                );
        }
    }

}
