using DDD.Domain.Tab.Model.ClosedTab;
using DDD.Domain.Tab.Model.DefaultTab;
using DDD.Domain.Tab.Model.OpendTab;
using DiscriminatedUnion;

namespace DDD.Domain.Tab
{
    public class Tab : Union<IDefaultTab, IOpendTab, IClosedTab>
    {
        public Tab(IDefaultTab t1) : base(t1)
        {
        }

        public Tab(IOpendTab t2) : base(t2)
        {
        }

        public Tab(IClosedTab t3) : base(t3)
        {
        }
    }
}
