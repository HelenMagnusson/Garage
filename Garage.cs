using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage<T> : IGarage<T> where T : Vehicle
    {
        //private Array Vehicles; //= new Array[1];
        //private int capacity;
        private T[] vehicles;


        public int Capacity { get; set; }
 

        // public Vehicle[] Vehicles { get => vehicles; set => vehicles = value; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
        }

        public bool Park(T vehicle)
        {
            //Finns det plats?
            //if (vehicles.Length <= Capacity)
            //{
                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (vehicles[i] == null)
                    {
                        vehicles[i] = vehicle;
                        return true;
                        //break;
                    }
                }
            //}
            if (vehicles.Length < Capacity)
            {
                this.Add(vehicle);
            }
            return true;
        }
        public bool Add(T vehicle)
        {
            //if(Capacity <= vehicles.Length) { return false; }
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return true;
                    //break;
                }

            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Vad ska returneras?
            foreach (var item in vehicles)
            {
                //if (item is Car) yield return item;
                if (item != null)
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // uses the strongly typed IEnumerable<T> implementation
            return this.GetEnumerator();
        }
        //public bool Remove(T item) => list.Remove(item);
        public bool Remove(T vehicle)
        {
            try
            {
                if (vehicles.Length >= 1 && vehicles != null)
                {
                    vehicles = vehicles.Where(v => v != vehicle).ToArray();
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }


    }

}
