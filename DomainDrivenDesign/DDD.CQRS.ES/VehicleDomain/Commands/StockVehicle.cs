using DDD.CQRS.ES.Infrastructure;

namespace DDD.CQRS.ES.VehicleDomain.Commands
{
    public class StockVehicle : Command
    {
        public StockVehicle(string VIN) : base(VIN)
        {
            this.VIN = VIN;
        }

        public string VIN { get; }
    }
}
