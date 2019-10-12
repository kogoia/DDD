using DDD.CQRS.ES.Infrastructure;

namespace DDD.CQRS.ES.VehicleDomain.Commands
{
    public class DispatchVehicle : Command
    {
        public DispatchVehicle(string VIN) : base(VIN)
        {
            this.VIN = VIN;
        }

        public string VIN { get; }
    }
}
