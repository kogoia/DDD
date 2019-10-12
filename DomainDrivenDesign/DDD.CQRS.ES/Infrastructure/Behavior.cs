using System;
using System.Collections.Generic;

namespace DDD.CQRS.ES.Infrastructure
{
    public class @Behavior<TEvent, TEntity> : Reaction<TEvent, TEntity>
    {
        private readonly Func<TEvent, TEntity, TEntity> _behavior;

        public @Behavior(Func<TEvent, TEntity, TEntity> behavior)
        {
            _behavior = behavior;
        }
        public (Type eventType, Func<TEntity, Message, (TEntity state, IEnumerable<Message>)> react) Content()
        {
            return (
                        typeof(TEvent),
                         (s, m) =>
                         {
                             var entity = _behavior((TEvent)m, s);
                             return (entity, new List<Message> { m });
                         }
            );
        }
    }
}
