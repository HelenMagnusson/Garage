namespace Garage
{
    public interface IVehicle
    {
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }
        public string Brand { get; set; }
    }
}