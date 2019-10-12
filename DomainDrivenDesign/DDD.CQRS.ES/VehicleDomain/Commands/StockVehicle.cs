namespace DDD.CQRS.ES
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
