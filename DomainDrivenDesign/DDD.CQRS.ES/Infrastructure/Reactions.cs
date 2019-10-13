using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.CQRS.ES.Infrastructure
{
    public class Handlers<TEntity> : Reactions<TEntity>
    {
        public Handlers(params Reaction<Message, TEntity>[] reactions)
            : this(reactions.ToList())
        {

        }
        public Handlers()
            : this(new List<Reaction<Message, TEntity>>())
        {

        }
        public Handlers(List<Reaction<Message, TEntity>> reactions) : base(reactions)
        {
        }

        public Handlers<TEntity> Handle<TCommand>(Func<(TCommand command, TEntity state), IEnumerable<Message>> handler)
            where TCommand : Command
        {
            _reactions.Add(new @Handler<TCommand, TEntity>(handler));
            return this;
        }
    }

    public class Behaviors<TEntity> : Reactions<TEntity>
    {
        public Behaviors(params Reaction<Message, TEntity>[] reactions)
            : this(reactions.ToList())
        {

        }
        public Behaviors()
            : this(new List<Reaction<Message, TEntity>>())
        {

        }
        public Behaviors(List<Reaction<Message, TEntity>> reactions) : base(reactions)
        {
        }

        public Behaviors<TEntity> Behave<TEvent>(Func<(TEvent @event, TEntity state), TEntity> behavior)
            where TEvent : Event
        {
            _reactions.Add(new @Behavior<TEvent, TEntity>(behavior));
            return this;
        }
    }


    public abstract class Reactions<TEntity>
    {
        protected readonly List<Reaction<Message, TEntity>> _reactions;
        public Reactions(List<Reaction<Message, TEntity>> reactions)
        {
            _reactions = reactions;
        }
        public Reactions(
                params Reaction<Message, TEntity>[] reactions
            ) : this(reactions.ToList())
        { }
        public (TEntity state, IEnumerable<Message> messages) React(Message message, TEntity state)
        {
            return _reactions
                        .First(r => r.Content().eventType.Name == message.GetType().Name)
                        .Content()
                        .react(state, message);
        }
    }
}
