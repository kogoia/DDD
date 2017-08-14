using System;
using DDD.Infrastructure.Infrastructure.AggregateRoot;

namespace DDD.Infrastructure.Infrastructure.Entity
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
