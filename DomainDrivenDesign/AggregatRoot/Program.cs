using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Domain.Tab.EventHandlers;
using AggregatRoot.Domain.Tab.Events;
using AggregatRoot.Domain.Tab.States;
using AggregatRoot.Domain.Tab.States.Types;

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

            new TabAggregateRoot(
                new CreatedTab(127, "VIP-Table")
            ).Apply(
                new TabEvent(
                    new TabOpendEvent("Saba")
                )
            ).Apply(null);
        }
    }
}
