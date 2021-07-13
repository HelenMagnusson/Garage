using System.Collections.Generic;

namespace Garage
{
    public interface IGarageHandler
    {
        public List<Vehicle> GetAll();
        public string Park(Vehicle v);
        public bool Remove(Vehicle v);
        public bool Add(Vehicle v);
    }
}