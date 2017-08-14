using System;
using System.Linq;

namespace DDD.Infrastructure.Infrastructure.Event
{

    public abstract class Appliable<TEvent, TEntity> : IApplicable<TEntity>
        where TEvent: IDomainEvent
    {
        private readonly TEvent _event;
        private readonly IApplicable<TEntity> _entity;
        protected Appliable(TEvent evnt, TEntity entity)
            : this(evnt, new Applied<TEntity>(entity))
        { }
        protected Appliable(TEvent evnt, IApplicable<TEntity> entity)
        {
            _event = evnt;
            _entity = entity;
        }
        protected abstract TEntity When(TEvent evnt, TEntity entity);
        public IAppliedEventResult<TEntity> Appled()
        {
            return new PreparedAppliedEventResult<TEvent>(_event)
                        .Result(When, _entity);
        }

        
    }

    public class PreparedAppliedEventResult<TEvent>
    {
        private readonly IDomainEvent _event;

        public PreparedAppliedEventResult(IDomainEvent evnt)
        {
            _event = evnt;
        }

        public AppliedEventResult<TEntity> Result<TEntity>(
                Func<TEvent, TEntity, TEntity> whenFunc,
                IApplicable<TEntity> entity
            )
        {
            var applied = entity.Appled();
            return new AppliedEventResult<TEntity>(
                whenFunc((TEvent)_event, applied.Result()),
                applied
                    .Events()
                    .Concat(new [] { _event })
            );
        }
    }
}
