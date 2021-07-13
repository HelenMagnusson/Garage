using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Vehicle
    {
        public string  RegNr { get; set; }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }
        public string Brand { get; set; }

        protected Vehicle(string regNr, string color, int nrOfWheels, string brand)
        {
            RegNr = regNr ?? throw new ArgumentNullException(nameof(regNr));
            Color = color ?? throw new ArgumentNullException(nameof(color));
            NrOfWheels = nrOfWheels;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        }

        public override string ToString() 
        {
            return $" Regnr: {RegNr} Color: {Color} Wheels: {NrOfWheels} Brand: {Brand}";
        }
    }
}
