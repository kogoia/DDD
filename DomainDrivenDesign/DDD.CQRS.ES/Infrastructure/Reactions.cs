using System.Collections.Generic;
using System.Linq;

namespace DDD.CQRS.ES.Infrastructure
{
    public class Reactions<TEntity>
    {
        private readonly Reaction<Message, TEntity>[] _reactions;

        public Reactions(
                params Reaction<Message, TEntity>[] reactions
            )
        {
            _reactions = reactions;
        }

        public (TEntity state, IEnumerable<Message> messages) React(Message message, TEntity state)
        {
            return _reactions
                        .First(r => r.Content().eventType.Name == message.GetType().Name)
                        .Content()
                        .react(state, message);
        }
    }
}
