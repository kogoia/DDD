using System;

namespace DDD.CQRS.ES
{
    public interface Reaction<out TEvent, TEntity>
    {
        public (Type eventType, Func<TEntity, Message, (TEntity state, Message[])> react) Content();
    }
}
