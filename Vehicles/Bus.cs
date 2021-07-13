using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Bus : Vehicle
    {
        public int Length { get; set; }
        public Bus(string regNr, string color, int nrOfWheels, string brand, int length) : base(regNr, color, nrOfWheels, brand)
        {
            Length = length;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + " Length: " + Length + " VehicleType: Bus";
        }
        
    }
}
