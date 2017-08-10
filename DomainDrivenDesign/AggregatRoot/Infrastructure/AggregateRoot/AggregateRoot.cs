using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using AggregatRoot.Infrastructure.DiscriminatedUnion;
using AggregatRoot.Infrastructure.Event;

namespace AggregatRoot.Infrastructure.AggregateRoot
{
    public abstract class AggregateRoot<TEntity, TEventType> : IAggregateRoot<TEventType>
        where TEventType : IUnion, IDomainEventType
    {
        private readonly IApplicable<TEntity> _entity;
        private readonly IEventStream _eventStream;

        protected AggregateRoot(IApplicable<TEntity> entity, IEventStream eventStream)
        {
            _entity = entity;
            _eventStream = eventStream;
        }

        protected abstract IApplicable<TEntity> When(TEntity entity, TEventType evnt);
        public IAggregateRoot<TEventType> Apply(TEventType evnt)
        {
            var entity1 = _eventStream.Aggregate(_entity, (acc, next) =>
            {
                var result = When(acc.Apply().Result(), (TEventType)next);
                return result;
            });

            IApplicable<TEntity> entity = entity1 == null ? _entity : new Applied<TEntity>(entity1.Apply().Result());

            var applied = entity.Apply();
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
            return _entity.Apply().Events();
        }

    }

    public class EmptyApplicable<TEntity> : IApplicable<TEntity>
        where TEntity : class
    {
        public IAppliedEventResult<TEntity> Apply()
        {
            return new AppliedEventEmptyResult<TEntity>();
        }
    }
}
