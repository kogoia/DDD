using System;
using System.Collections.Generic;

namespace DDD.CQRS.ES.Infrastructure
{
    public class @Handler<TCommand, TEntity> : Reaction<TCommand, TEntity>
        where TCommand : Command
    {
        private readonly Func<(TCommand command, TEntity state), IEnumerable<Message>> _handler;

        public @Handler(Func<(TCommand command, TEntity state), IEnumerable<Message>> handler)
        {
            _handler = handler;
        }
        public (Type eventType, Func<TEntity, Message, (TEntity state, IEnumerable<Message>)> react) Content()
        {
            return (
                        typeof(TCommand),
                         (s, m) =>
                         {
                             var messages = _handler(((TCommand)m, s));
                             return (s, messages);
                         }
                    );
        }
    }

    public class @Behavior<TEvent, TEntity> : Reaction<TEvent, TEntity>
       where TEvent : Event
    {
        private readonly Func<(TEvent @event, TEntity state), TEntity> _behavior;

        public @Behavior(Func<(TEvent @event, TEntity state), TEntity> behavior)
        {
            _behavior = behavior;
        }
        public (Type eventType, Func<TEntity, Message, (TEntity state, IEnumerable<Message>)> react) Content()
        {
            return (
                        typeof(TEvent),
                         (s, m) =>
                         {
                             var entity = _behavior(((TEvent)m, s));
                             return (entity, new List<Message> { m });
                         }
            );
        }
    }
}
