using DDD.CQRS.ES.VehicleDomain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using static DDD.CQRS.ES.Program;

namespace DDD.CQRS.ES.Infrastructure
{
  
    public class Aggregate<TEntity>
        where TEntity : new()
    {
        private readonly Reactions<TEntity> _handlers;
        private readonly Reactions<TEntity> _behaviors;
        public Aggregate(Func<Handlers<TEntity>, Reactions<TEntity>> commands, Func<Behaviors<TEntity>, Reactions<TEntity>> events)
            : this(commands(new Handlers<TEntity>()), events(new Behaviors<TEntity>()))
        {

        }
        public Aggregate(
                Reactions<TEntity> handlers,
                Reactions<TEntity> behaviors 
            )
        {
            _handlers = handlers;
            _behaviors = behaviors;
        }
        
        public TEntity Handle(Command command)
        {
            var seed = new TEntity();
            return 
                _handlers
                    .React(command, seed)
                    .messages
                    .Aggregate(seed, (prevState, evnt) => _behaviors.React(evnt, prevState).state);
        }
    }
}
