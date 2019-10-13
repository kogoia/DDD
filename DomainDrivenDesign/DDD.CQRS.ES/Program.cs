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
    partial class Program
    {
        static void Main(string[] args)
        {
            new Aggregate<Vehicle>(
                c => c
                        .Handle<StockVehicle>(t => new List<Message> { new VehicleStocked() })
                        .Handle<DispatchVehicle>(t => new List<Message> { new VehicleDispatched() }),
                e => e
                        .Behave<VehicleStocked>(t => new Vehicle())
                        .Behave<VehicleDispatched>(t => new Vehicle())
            );
        }
    }
}
