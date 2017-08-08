using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Messages;
using AggregatRoot.Types.Interfaces;

namespace AggregatRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            //    new Tab(
            //        new DefaultTabState()
            //    )
            //    .Match(
            //        (dTab) => "",
            //        (oTab) => "",
            //        (cTab) => ""
            //    );

            new Tab(
                new ClosedTab(
                    new TabState("Gio 1")
                )
            );

            new TabAggregateRoot(
                123, 
                "Gio"
            )
            .Apply(new TabOpendEvent())
            .Apply(new TabClosedEvent());
        }
    }
}
