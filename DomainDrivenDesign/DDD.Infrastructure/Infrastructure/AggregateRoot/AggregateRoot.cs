using System.Collections.Generic;
using System.Linq;
using DDD.Infrastructure.Infrastructure.DiscriminatedUnion;
using DDD.Infrastructure.Infrastructure.EntityState;
using DDD.Infrastructure.Infrastructure.Event;
using DDD.Infrastructure.Infrastructure.EventStream;

namespace DDD.Infrastructure.Infrastructure.AggregateRoot
{
    public abstract class AggregateRoot<TEntity, TEventType> : IAggregateRoot<TEventType>
        //where TEntity : EntityState<TEntity>
        where TEventType : IUnion, IDomainEventType //, new()
    {
        //private readonly IEntityState<TEntity> _entityState;
        private readonly IApplicable<TEntity> _entity;
        private readonly IEventStream _eventStream;

        //protected AggregateRoot(EntityState<TEntity> entityState)
        //{
        //    _entityState = entityState;
            
        //}
        protected AggregateRoot(IApplicable<TEntity> entity, IEventStream eventStream)
        {
            _entity = entity;
            _eventStream = eventStream;
        }

        protected abstract IApplicable<TEntity> When(TEntity entity, TEventType evnt);

        //TODO: refactor this method
        public IAggregateRoot<TEventType> Apply(TEventType evnt)
        {
            
            var restoredEntity = _eventStream.Aggregate(_entity, (acc, next) => When(acc.Appled().Result(), (TEventType)next));

            var entity = restoredEntity == null ? _entity : new Applied<TEntity>(restoredEntity.Appled().Result());

            var applied = entity.Appled();
            return new FakeAggregateRoot<TEntity, TEventType>(
                        When,
                        When(applied.Result(), evnt), 
                        applied
                            .Events()
                            .Concat(new [] { (IDomainEvent)evnt.Content() })
                    );
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            // TODO: maybe we need cache 
            return _entity.Appled().Events();
        }

        //public IEventTypes EventTypes()
        //{
        //    return new TEventType().EventTypes();
        //}
    }

    public class EmptyApplicable<TEntity> : IApplicable<TEntity>
        where TEntity : class
    {
        public IAppliedEventResult<TEntity> Appled()
        {
            return new AppliedEventEmptyResult<TEntity>();
        }
    }
}
