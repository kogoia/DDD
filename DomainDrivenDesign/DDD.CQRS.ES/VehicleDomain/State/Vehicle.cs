namespace DDD.CQRS.ES.VehicleDomain.State
{
    public class Vehicle 
    {
        public string VIN { get; }
        public VehicleState State { get; }
    }

    public enum VehicleState
    {
        GIT,
        Stocked,
        Dispatched
    }
}
