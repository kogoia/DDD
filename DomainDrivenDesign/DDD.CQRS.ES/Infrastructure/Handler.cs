using System;
using System.Collections.Generic;

namespace DDD.CQRS.ES.Infrastructure
{
    public class @Can<TCommand, TEntity> : Reaction<TCommand, TEntity>
    {
        public @Can(Func<TCommand, TEntity, bool> check)
        {

        }
        public (Type eventType, Func<TEntity, Message, (TEntity state, IEnumerable<Message>)> react) Content()
        {
            throw new NotImplementedException();
        }
    }
    public class @Handler<TCommand, TEntity> : Reaction<TCommand, TEntity>
        where TCommand : Command
    {
        private readonly Func<TCommand, TEntity, IEnumerable<Message>> _handler;

        public @Handler(Func<TCommand, TEntity, IEnumerable<Message>> handler)
        {
            _handler = handler;
        }
        public (Type eventType, Func<TEntity, Message, (TEntity state, IEnumerable<Message>)> react) Content()
        {
            return (
                        typeof(TCommand),
                         (s, m) =>
                         {
                             var messages = _handler((TCommand)m, s);
                             return (s, messages);
                         }
                    );
        }
    }
}
