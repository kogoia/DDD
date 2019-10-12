namespace DDD.CQRS.ES
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

        public (TEntity state, Message[] messages) React(Message message, TEntity state)
        {
            return _reactions
                        .First(r => r.Content().eventType.Name == message.GetType().Name)
                        .Content()
                        .react(state, message);
        }
    }
}
