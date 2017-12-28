namespace DDD.Domain.Tab.Types
{
    public interface IOpendTab
    {
        IClosedTab Closed(decimal price);
    }

}
