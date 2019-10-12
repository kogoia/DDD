using DDD.CQRS.ES.Infrastructure;
using DDD.CQRS.ES.VehicleDomain.Commands;
using DDD.CQRS.ES.VehicleDomain.Events;
using DDD.CQRS.ES.VehicleDomain.State;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DDD.CQRS.ES
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            new Aggregate<Vehicle>(
                new Reactions<Vehicle>(
                    new @Handler<StockVehicle, Vehicle>((c, s) => new List<Message> { new VehicleStocked() }),
                    new @Handler<StockVehicle, Vehicle>(StockVehicle),
                    new @Handler<DispatchVehicle, Vehicle>((c, s) => new List<Message> { new VehicleDispatched() })
                ),
                new Reactions<Vehicle>(
                    new @Behavior<VehicleStocked, Vehicle>((e, s) => new Vehicle()),
                    new @Behavior<VehicleDispatched, Vehicle>((e, s) => new Vehicle())
                )
            ).Handle(new StockVehicle("1"));
        }
        public interface EntityStore<TEntity>
        {
            public TEntity LookUp(object entityId);
        }

        public class EventStore<TEntity> : EntityStore<TEntity>
        {
            public TEntity LookUp(object entityId)
            {
                throw new NotImplementedException();
            }
        }

        public class CurrentState<TEntity> : EntityStore<TEntity>
        {
            public TEntity LookUp(object entityId)
            {
                throw new NotImplementedException();
            }
        }
        public static IEnumerable<Message> StockVehicle(StockVehicle command, Vehicle state)
        {
            yield return new VehicleStocked();
        }
    }
}
