using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Boat : Vehicle
    {
        public string Type { get; set; }
        public Boat(string regNr, string color, int nrOfWheels, string brand, string type) : base(regNr, color, nrOfWheels, brand)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public override string ToString()
        {
            return base.ToString() + " Type: " + Type + " VehicleType: Boat";
        }
    }
}
