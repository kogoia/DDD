namespace AggregatRoot
{
    public class DefaultTab : IDefaultTab
    {
        public DefaultTab(int tabId, string name)
        {

        }
        public IOpendTab Opened()
        {
            return new OpendTab();
        }
    }

}
