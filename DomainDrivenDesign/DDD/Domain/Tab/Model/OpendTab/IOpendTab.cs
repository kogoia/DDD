using DDD.Domain.Tab.Model.ClosedTab;

namespace DDD.Domain.Tab.Model.OpendTab
{
    public interface IOpendTab
    {
        IClosedTab Closed(decimal price);
    }

}
