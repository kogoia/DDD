namespace DDD.CQRS.ES
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
