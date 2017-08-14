using DDD.Infrastructure.Infrastructure.DiscriminatedUnion;

namespace AggregatRoot.Domain.Tab.States.Types
{
    public class TabType : Union<IDefaultTab, IOpendTab, IClosedTab>
    {
        public TabType(IDefaultTab t1) : base(t1)
        {
        }

        public TabType(IOpendTab t2) : base(t2)
        {
        }

        public TabType(IClosedTab t3) : base(t3)
        {
        }
    }
}
