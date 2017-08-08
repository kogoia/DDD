using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Infrastructure;
using AggregatRoot.Infrastructure.Unions;
using AggregatRoot.Messages;

namespace AggregatRoot
{
    public interface IOpendTab
    {
        IClosedTab Closed();
    }

    public interface IClosedTab
    {
        
    }

    public interface IDefaultTab
    {
        IOpendTab Opened();
    }

    public class OpendTabState : IOpendTab
    {
        public IClosedTab Closed()
        {
            throw new NotImplementedException();
        }
    }

    public class ClosedTabState : IClosedTab
    {
        
    }

    public class DefaultTabState : IDefaultTab
    {
        public IOpendTab Opened()
        {
            return new OpendTabState();
        }
    }

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

    public class TabAggregateRoot : EventSourcedRootEntity
        <
            TabOpendEvent, 
            TabClosedEvent, 
            Tab
        >
    {
        public TabAggregateRoot(Tab root) : base(root)
        {
        }

        protected override Tab When(TabOpendEvent e)
        {
            return _root
                .Match(
                    (dTab) => new Tab(dTab.Opened()),
                    (oTab) => throw new Exception("Can't open OpendTab"),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }

        protected override Tab When(TabClosedEvent e)
        {
            return _root
                .Match(
                    (dTab) => throw new Exception("Can't open DefaultTab"),
                    (oTab) => new Tab(oTab.Closed()),
                    (cTab) => throw new Exception("Can't open ClosedTab")
                );
        }
    }

}
