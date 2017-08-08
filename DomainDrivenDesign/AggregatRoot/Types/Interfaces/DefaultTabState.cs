namespace AggregatRoot
{
    public class DefaultTabState : IDefaultTab
    {
        public IOpendTab Opened()
        {
            return new OpendTabState();
        }
    }

}
