using System;
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
                    new @Handler<StockVehicle, Vehicle>((c, s) => new Message[] { new VehicleStocked() }),
                    new @Handler<DispatchVehicle, Vehicle>((c, s) => new Message[] { new VehicleDispatched() })
                ),
                new Reactions<Vehicle>(
                    new @Behavior<VehicleStocked, Vehicle>((e, s) => new Vehicle()),
                    new @Behavior<VehicleDispatched, Vehicle>((e, s) => new Vehicle())
                )
            ).Handle(new StockVehicle("1"));
        }
    }
}
