using DDD.Domain.Tab.Model.OpendTab;

namespace DDD.Domain.Tab.Model.DefaultTab
{
    public interface IDefaultTab
    {
        IOpendTab Opened(string waiter);
    }

}
