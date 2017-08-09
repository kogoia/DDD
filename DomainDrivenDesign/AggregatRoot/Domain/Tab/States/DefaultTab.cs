using AggregatRoot.Domain.Tab.States.Types;

namespace AggregatRoot.Domain.Tab.States
{
    public class DefaultTab : IDefaultTab
    {
        public DefaultTab(int tabId, string name)
        {

        }

        public IOpendTab Opened(string waiter)
        {
            return new OpendTab();
        }
    }

}
