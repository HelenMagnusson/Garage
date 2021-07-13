using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{ 
    public interface IGarage<T> : IEnumerable<T>
    {
        public bool Add(T v);
        public bool Remove(T v);
        public bool Park(T v);
        //public IEnumerable<T> GetAllVehicles();

    }
}
