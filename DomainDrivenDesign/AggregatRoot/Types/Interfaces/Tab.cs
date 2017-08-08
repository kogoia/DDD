using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Infrastructure.Unions;

namespace AggregatRoot
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
