namespace DDD.Infrastructure.Infrastructure.Event
{
    public interface IDomainEvent { }


    public interface IEventHandlers<TEventType>
        where TEventType : DomainEventType<>
    {
        
    }



}
