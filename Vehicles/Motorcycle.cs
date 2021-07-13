using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public string FuelType { get; set; }

 
        public Motorcycle(string regNr, string color, int nrOfWheels, string brand, string fuelType) : base(regNr, color, nrOfWheels, brand)
        {
            FuelType = fuelType ?? throw new ArgumentNullException(nameof(fuelType));

        }
        public override string ToString()
        {
            return base.ToString() + " FuelType: " + FuelType + " VehicleType: Mootorcycle";
        }
    }
}
