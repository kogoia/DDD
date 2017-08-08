using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Messages;

namespace AggregatRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Tab(
                new DefaultTabState()
            )
            .Match(
                (dTab) => "",
                (oTab) => "",
                (cTab) => ""
            );

            new TabAggregateRoot(
                new Tab(
                    new DefaultTabState()
                )
            )
            .Apply(new TabOpendEvent())
            .Apply(new TabClosedEvent());
        }
    }
}
