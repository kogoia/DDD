namespace DDD.CQRS.ES
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
