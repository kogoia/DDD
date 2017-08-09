using System;
using AggregatRoot.Infrastructure;
using System.Collections.Generic;
using AggregatRoot.Domain.Tab;
using AggregatRoot.Events;
using AggregatRoot.Events.Handlers;

namespace AggregatRoot
{
    public interface IAggregateRoot<in TEntityEvent>
    {
        IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt);
        IEnumerable<IDomainEvent> UncommitedEvents();
    }

    public class TabAggregateRoot : AggregateRoot<Tab, TabEvent>
    {
        public TabAggregateRoot(IApplicable<Tab> entity) : base(entity)
        {
        }

        protected override IApplicable<Tab> Apply(Tab tab, TabEvent evnt)
        {
            return evnt
                .Match<IApplicable<Tab>>(
                    toe => new AppliedTabOpendEvent(toe, tab),
                    tce => new AppliedTabClosedEvent(tce, tab),
                    tcre => new CreatedTab(tcre)
                );
        }

        //public IAggregateRoot<TabEvent> Apply(TabEvent evnt)
        //{
        //    return new TabAggregateRoot(
        //        evnt
        //            .Match<IApplicable<Tab>>(
        //                toe => new AppliedTabOpendEvent(toe, _tab),
        //                tce => new AppliedTabClosedEvent(tce, _tab),
        //                tcre => new CreatedTab(tcre)
        //            )
        //    );
        //}
    }


    public abstract class AggregateRoot<TEntity, TEntityEvent> : IAggregateRoot<TEntityEvent>
    {
        private readonly IApplicable<TEntity> _entity;

        protected AggregateRoot(IApplicable<TEntity> entity)
        {
            _entity = entity;
        }

        protected abstract IApplicable<TEntity> Apply(TEntity entity, TEntityEvent evnt);
        public IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt)
        {
            return new FakeAggregateRoot<TEntity, TEntityEvent>(Apply, Apply(_entity.Apply().Result(), evnt));
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _entity.Apply().Event();
        }
    }

    public class FakeAggregateRoot<TEntity, TEntityEvent> : IAggregateRoot<TEntityEvent>
    {
        private readonly Func<TEntity, TEntityEvent, IApplicable<TEntity>> _f;
        private readonly IApplicable<TEntity> _entity;

        public FakeAggregateRoot(Func<TEntity, TEntityEvent, IApplicable<TEntity>> f, IApplicable<TEntity> entity)
        {
            _f = f;
            _entity = entity;
        }

        public IAggregateRoot<TEntityEvent> Apply(TEntityEvent evnt)
        {
            return new FakeAggregateRoot<TEntity, TEntityEvent>(_f, _f(_entity.Apply().Result(), evnt));
        }

        public IEnumerable<IDomainEvent> UncommitedEvents()
        {
            return _entity.Apply().Event();
        }
    }

}
