using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Events.Handlers;
using AggregatRoot.Events.Messages;

namespace AggregatRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Tab(
                new ClosedTab(
                    new TabState("Gio 1")
                )
            );

            new AppliedTabOpendEvent(
                new TabOpendEvent("Saba"),
                new CreatedTab(127, "VIP-Table")
            );
        }
    }
}
