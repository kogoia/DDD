using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Domain.Tab.States.Types;
using AggregatRoot.Infrastructure.AggregateRoot;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Infrastructure.Entity
{
    public interface IIdentity
    {
        string Id();
        //IEventTypes EventTypes();
    }

    public abstract class Identity<TAggregatType> : IIdentity
        where TAggregatType : IAggregateRoot, new()
    {
        protected Identity()
        {
            
        }

        public string Id()
        {
            throw new NotImplementedException();
        }

        //public IEventTypes EventTypes()
        //{
        //    return new TAggregatType().EventTypes();
        //}
    }

    //public class TabId : Identity<Tab>
    //{
        
    //}
}
