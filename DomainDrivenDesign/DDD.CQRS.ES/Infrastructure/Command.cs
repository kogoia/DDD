namespace DDD.CQRS.ES.Infrastructure
{
    public abstract class Command : Message 
    {
        public Command(object entitId)
        {
            EntitId = entitId;
        }

        public object EntitId { get; }
    }
}
