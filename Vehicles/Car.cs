using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Car : Vehicle
    {
        public bool BackSeat { get; set; }
        public bool FoldingRoof { get; set; }

        public Car(string regNr, string color, int nrOfWheels, string brand, bool backSeat, bool foldingRoof) : base(regNr, color, nrOfWheels, brand)
        {
            BackSeat = backSeat;
            FoldingRoof = foldingRoof;
        }

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + " BackSeat: " + BackSeat + " FoldingRoof: " + FoldingRoof + " VehicleType: Car";
        }
    }
}
