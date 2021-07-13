using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    //Hanterar garaget
    public class GarageHandler : IGarageHandler
    {
        private int capacity;
        //private Garage<Vehicle> garage;
        private IGarage<Vehicle> garage;

        public GarageHandler(int capacity)
        {
            this.capacity = capacity;
            garage = new Garage<Vehicle>(capacity);

        }

        public string Park(Vehicle vehicle)
        {
            //Inte fler fordon är capaciteten

            return garage.Park(vehicle) ? $"The vehicle {vehicle.RegNr} is parked in the garage!" : "Something failed";

        }


        public List<Vehicle> GetAll()
        {
            return garage.ToList();
        }

        public bool Remove(Vehicle v)
        {
            return garage.Remove(v);
        }

        public bool Add(Vehicle v)
        {
            return garage.Add(v);
        }
    }
}
