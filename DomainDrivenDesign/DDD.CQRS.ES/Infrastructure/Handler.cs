using System;

namespace DDD.CQRS.ES
{
    public class @Handler<TCommand, TEntity> : Reaction<TCommand, TEntity>
        where TCommand : Command
    {
        private readonly Func<TCommand, TEntity, Message[]> _handler;

        public @Handler(Func<TCommand, TEntity, Message[]> handler)
        {
            _handler = handler;
        }
        public (Type eventType, Func<TEntity, Message, (TEntity state, Message[])> react) Content()
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
