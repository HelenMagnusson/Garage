using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Airplane : Vehicle
    {
        public int NrOfSeats { get; set; }

        public Airplane(string regNr, string color, int nrOfWheels, string brand, int nrOfSeats) : base(regNr, color, nrOfWheels, brand)
        {
            NrOfSeats = nrOfSeats;
        }
        public override string ToString()
        {
            return base.ToString() + " NrOfSeats: " + NrOfSeats + " VehicleType: Airplane";
        }
    }
}
