using System;
using DDD.Infrastructure.Infrastructure.AggregateRoot;

namespace DDD.Infrastructure.Infrastructure.Entity
{
    public interface IIdentity
    {
        string Id();
        //IEventTypes EventTypes();
    }

    public abstract class Identity<TEntity> : IIdentity
        where TEntity : IEntity, new()
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

    public interface IEntity
    {
        
    }

    public abstract class Entity<TEntity>
        where TEntity : IEntity, new()
    {
        public Entity(Identity<TEntity> identity)
        {
            
        }
    }
    //public class TabId : Identity<Tab>
    //{
        
    //}
}
