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
            Func<(int a, int b), int> sum = (t) => t.a + t.b;
            new Aggregate<Vehicle>(
                c => c
                        .Handle<StockVehicle>(t => new List<Message> { new VehicleStocked() })
                        .Handle<DispatchVehicle>(t => new List<Message> { new VehicleDispatched() }),
                e => e
                        .Behave<VehicleStocked>(t => new Vehicle())
                        .Behave<VehicleDispatched>(t => new Vehicle())
            );
            

            new Aggregate<Vehicle>(
                new Handlers<Vehicle>(
                    new @Handler<StockVehicle, Vehicle>(t => new List<Message> { new VehicleStocked() }),
                    new @Handler<StockVehicle, Vehicle>(StockVehicle),
                    new @Handler<DispatchVehicle, Vehicle>(t => new List<Message> { new VehicleDispatched() })
                ),
                new Behaviors<Vehicle>(
                    new @Behavior<VehicleStocked, Vehicle>(t => new Vehicle()),
                    new @Behavior<VehicleDispatched, Vehicle>(t => new Vehicle())
                )
            ).Handle(new StockVehicle("1"));

            //new Aggregate<Vehicle>(
            //    new CurrentState<Vehicle>(
            //        new Store(
            //            new EventStore()
            //        )
            //    )
            //)
            //.Handlers(ctx => ctx
            //                    .On<StockVehicle>(ctx => ctx
            //                                                .Validate((c, s) => new ValidatedStockVehicleCommand(c))
            //                                                .Can((c, s) => CanStockVehicle(s))
            //                                                .Handle((c, s) => new Event[] { new VehicleStocked() })
            //                    )
            //                    .On<DispatchVehicle>(ctx => ctx
            //                                                .Validate((c, s) => new ValidatedDispatchVehicleCommand(c))
            //                                                .Can((c, s) => CanDispatchVehicle(s))
            //                                                .Handle((c, s) => new Event[] { new VehicleDispatched() })
            //                    )
            //)
            //.Behaviors(ctx => ctx
            //                    .Behave<VehicleStocked>((e, s) => new Vehicle(s.VIN, VehicleState.Stocked))
            //                    .Behave<VehicleDispatched>((e, s) => new Vehicle(s.VIN, VehicleState.Dispatched))
            //)
            //.Handle(new StockVehicle("1"));



            //new Aggregate<Vehicle>(
            //    new Handlers<Vehicle>(
            //        new On<StockVehicle>(
            //            new Validate((c, s) => new ValidatedStockVehicleCommand(c)),
            //            new Can((c, s) => CanStockVehicle(s)),
            //            new Handle((c, s) => new Event[] { new VehicleStocked() })
            //        ),
            //        new On<DispatchVehicle>(
            //            new Validate((c, s) => new ValidatedDispatchVehicleCommand(c)),
            //            new Can((c, s) => CanDispatchVehicle(s)),
            //            new Handle((c, s) => new Event[] { new VehicleDispatched() })
            //        )
            //    )
            //    new Behaviors(
            //        new Behave<VehicleStocked>((e, s) => new Vehicle(s.VIN, VehicleState.Stocked))
            //        new Behave<VehicleDispatched>((e, s) => new Vehicle(s.VIN, VehicleState.Dispatched))
            //    ),
            //    new CurrentState<Vehicle>(
            //        new Store(
            //            new EventStore()
            //        )
            //    )
            //)
            //.Handle(new StockVehicle("1"));

            // ############# 3
            //new Aggregate<Vehicle>(
            //    new Handlers<Vehicle>(
            //        new On<StockVehicle>(
            //            new Validate((c, s)                 => new ValidatedStockVehicleCommand(c)),
            //            new Can((c, s)                      => new CanStockVehicle(s)),
            //            new Handle((c, s)                   => new VehicleStockScenarion(c, s))
            //        ),
            //        new On<DispatchVehicle>(                
            //            new Validate((c, s)                 => new ValidatedDispatchVehicleCommand(c)),
            //            new Can((c, s)                      => new CanDispatchVehicle(s)),
            //            new Handle((c, s)                   => new DispatchVehicleScenarion(c, s))
            //        )
            //    ),
            //    new Behaviors(
            //        new Behave<VehicleStocked>((e, s)       => new VehicleStockedReducer(e, s)),
            //        new Behave<VehicleDispatched>((e, s)    => new VehicleDispatchedReducer(e, s))
            //    ),
            //    new CurrentState<Vehicle>(
            //        new Store(
            //            new EventStore()
            //        )
            //    )
            //)
            //.Handle(new StockVehicle("1"));

            // ################ 4
            //new Aggregate<Vehicle>(
            //    new Handlers<Vehicle>(
            //        new On<StockVehicle>(
            //            new ValidateStockVehicleCommand(),
            //            new CanStockVehicle(),
            //            new HandleVehicleStockCommand()
            //        ),
            //        new On<DispatchVehicle>(
            //            new ValidatedDispatchVehicleCommand(),
            //            new CanDispatchVehicle(),
            //            new HandleDispatchVehicleCommand()
            //        )
            //    ),
            //    new Behaviors(
            //        new BehaveOnVehicleStockedEvent(),
            //        new BehaveVehicleDispatchedEvent()
            //    ),
            //    new CurrentState<Vehicle>(
            //        new Store(
            //            new EventStore()
            //        )
            //    )
            //)
            //.Handle(new StockVehicle("1"));

            //new Aggregate<Vehicle>(
            //    new CurrentState<Vehicle>(
            //        new Store(
            //            new EventStore()
            //        )
            //    ),
            //    new Handlers<Vehicle>(
            //        new HandleStockVehicle(
            //            new CanStockVehicle(
            //                new ValidateVehicleStockCommand()
            //            )
            //        ),
            //        new HandleDispatchVehicleCommand(
            //            new CanDispatchVehicle(
            //                new ValidatedDispatchVehicleCommand()
            //            )
            //        )
            //    ),
            //    new BehaveOnVehicleStockedEvent(),
            //    new BehaveVehicleDispatchedEvent()
            //)
            //.Handle(new StockVehicle("1"));
            
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
        public static IEnumerable<Message> StockVehicle((StockVehicle command, Vehicle state) t)
        {
            yield return new VehicleStocked();
        }
    }
}
