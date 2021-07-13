using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Garage
{
    internal class PgmManager : IUI
    {
        private IGarageHandler handler;
        private int capacity;

        //UI
        //private UI ui = new UI();
        int index = 0;
        internal void Run()
        {
            CreateGarage();
            Initmenue();

        }

        public void Initmenue()
        {
            while (true)
            {
                Console.WriteLine("\nPlease navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Populate garage with some vehicles"
                    + "\n2. List all the parked Vehicles"
                    + "\n3. List the vehicletypes and how many of each"
                    + "\n4. Add a vehicle to the garage"
                    + "\n5. Remove a vehicle from the garage by index"
                    + "\n6. Instanciate a new garage"
                    + "\n7. Find a specific vehicle by Regnr"
                    + "\n8. Search"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        SeedAndPark();
                        break;
                    case '2':
                        ListParkedV();
                        break;
                    case '3':
                        ListVehicleTypes();
                        break;
                    case '4':
                        Addvehicle();
                        break;
                    case '5':
                        RemoveVehicle();
                        break;
                    case '6':
                        CreateGarage();
                        break;
                    case '7':
                        Find();
                        break;
                    case '8':
                        Search();
                        break;
                    case '9':

                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
        private void CreateGarage()
        {
            ShowMessage("Number of spaces in the garage?");
            capacity = int.Parse(Console.ReadLine()); //VAlidate
            handler = new GarageHandler(capacity);
            Console.WriteLine($"The Garage is created with {capacity} parking spaces");

        }

        private void SeedAndPark()
        {
            //vehicles.ForEach(v => handler.Park(v));

            var vehicles = new List<Vehicle>()
            {
                new Bus("rte554", "red", 4, "Scania", 10),
                new Motorcycle("hgh555", "blue", 2, "Honda", "95"),
                new Car("GHJ898", "Orange", 4, "Volvo", true, false),
                new Car("GRT258", "Yellow", 4, "Opel", true, false)
            };

            int i = 0;
            foreach (var v in vehicles)
            {
                i += 1;
                if (i <= capacity)
                {

                    var result = handler.Park(v);
                    //Console.WriteLine(result);
                    ShowMessage(result);

                }

            }
        }

        private void Search()
        {
            Console.WriteLine("Enter some text for searching among the vehicles in the garage");
            string input = Console.ReadLine();
            List<Vehicle> vehicles = handler.GetAll();
            //vehicles= vechicles.Where(s => s == input);
            //int index = vehicles.Select((item, i) => new { Item = item, Index = i })
            //    .First(x => x.Item == input).Index;
        }

        private void Find()
        {

            Console.WriteLine("Enter regnr to find the vehicle in the garage");
            string input = Console.ReadLine();
            input = input.ToLower();
            List<Vehicle> vehicles = handler.GetAll();
            foreach (var item in vehicles)
            {
                if (item.RegNr.ToLower() == input)
                { //yield return item;
                    Console.WriteLine("\nThis is the car you were looking for:");
                    Console.WriteLine(item.ToString());
                }
            }
        }


        private void RemoveVehicle()
        {
            Console.WriteLine("Enter the index of the vehicle you want to remove, you can see the index in the list above");
            var str = Console.ReadLine();
            bool isParsable = Int32.TryParse(str, out index);
            var vehicles = handler.GetAll();
            if (isParsable && index != 0)
            {
                if (vehicles.Count == 0)
                { Console.WriteLine("Thera are no vehicles left to remove in the garage!"); }
                else
                {
                    if (index - 1 <= vehicles.Count)
                    {
                        var b = handler.Remove(vehicles[index - 1]);
                        if (b == true)
                        { Console.WriteLine("The vehicle is removed from the garage"); }
                        else { Console.WriteLine("Something went wrong, the vehicle could not be removed"); }
                    }
                    else { Console.WriteLine("You must enter a valid number."); }
                }
            }
            else
                Console.WriteLine("You must enter a valid number.");
        }

        private void Addvehicle()
        {
            VehicleMenue();

        }

        private void ListVehicleTypes()
        {
            Console.WriteLine("\nList of parked vehicleTypes");
            var vehicles = handler.GetAll();
            int c = 0;
            int b = 0;
            int bo = 0;
            int a = 0;
            int m = 0;
            foreach (var item in vehicles)
            {

                if (item == null) { break; }
                else
                {
                    if (item is Car)
                    { c += 1; }
                    if (item is Bus)
                    { b += 1; }
                    if (item is Boat)
                    { bo += 1; }
                    if (item is Airplane)
                    { a += 1; }
                    if (item is Motorcycle)
                    { m += 1; }
                }
            }
            Console.WriteLine($"Cars:{c} Buses:{b} Boats:{bo} Airplanes:{a} Motorcycles:{m}");
        }

        private void ListParkedV()
        {
            //Console.WriteLine("\nList of parked vehicles");
            ShowMessage("\nList of parked vehicles");
            var vehicles = handler.GetAll();
            var i = 0;
            foreach (var item in vehicles)
            {
                i = i + 1;
                if (item == null) { break; }
                //Console.WriteLine(item.ToString());
                ShowMessage(i + ". " + item.ToString());
            }
        }

        public void ShowMessage(string s)
        {
            Console.WriteLine(s);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }
        private void VehicleMenue()

        {
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("Choose wich vehicle you want to add. Enter the number \n(1, 2, 3, 4, 5, 0) of your choice"
                       + "\n1. Airplane"
                       + "\n2. Boat"
                       + "\n3. Bus"
                       + "\n4. Car"
                       + "\n5. Motorcycle"
                       + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        Airplane();
                        break;
                    case '2':
                        Boat();
                        break;
                    case '3':
                        Bus();
                        break;
                    case '4':
                        Car();
                        break;
                    case '5':
                        Motorcycle();
                        break;
                    case '0':
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }

        private void Motorcycle()
        {
            Console.WriteLine("Enter regnr");
            string reg = Console.ReadLine();
            Console.WriteLine("Enter Color");
            string col = Console.ReadLine();
            Console.WriteLine("Enter numer of wheels");
            int wheels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter brand");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter fueltype");
            string fueltype = Console.ReadLine();
            Motorcycle m = new Motorcycle(reg, col, wheels, brand, fueltype);
            if (handler.Add(m) == true)
            { Console.WriteLine("The motorcycle is added to the garage"); }
            else { Console.WriteLine("The motorcycle couldn´t be added to the garage, not enough parkingspaces"); }
        }

        private void Car()
        {

            Console.WriteLine("Enter regnr");
            string reg = Console.ReadLine();
            Console.WriteLine("Enter Color");
            string col = Console.ReadLine();
            Console.WriteLine("Enter numer of wheels");
            int wheels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter brand");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter true for backseat");
            bool backseat = Boolean.Parse(Console.ReadLine());
            Console.WriteLine("Enter true for Folding roof");
            bool roof = Boolean.Parse(Console.ReadLine());
            Car c = new Car(reg, col, wheels, brand, backseat, roof);
            if (handler.Add(c) == true)
            { Console.WriteLine("The car is added to the garage"); }
            else { Console.WriteLine("The car couldn´t be added to the garage, not enough parkingspaces"); }
        }

        private void Bus()
        {
            Console.WriteLine("Enter regnr");
            string reg = Console.ReadLine();
            Console.WriteLine("Enter Color");
            string col = Console.ReadLine();
            Console.WriteLine("Enter number of wheels");
            int wheels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter brand");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter length");
            int length = Convert.ToInt32(Boolean.Parse(Console.ReadLine()));
            Bus b = new Bus(reg, col, wheels, brand, length);
            if (handler.Add(b) == true)
            { Console.WriteLine("The bus is added to the garage"); }
            else { Console.WriteLine("The bus couldn´t be added to the garage, not enough parkingspaces"); }
        }

        private void Boat()
        {
            Console.WriteLine("Enter regnr");
            string reg = Console.ReadLine();
            Console.WriteLine("Enter Color");
            string col = Console.ReadLine();
            Console.WriteLine("Enter numer of wheels");
            int wheels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter brand");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter type");
            string type = Console.ReadLine();
            Boat b = new Boat(reg, col, wheels, brand, type);
            if (handler.Add(b) == true)
            { Console.WriteLine("The boat is added to the garage"); }
            else { Console.WriteLine("The boat couldn´t be added to the garage, not enough parkingspaces"); }
        }

        private void Airplane()
        {
            Console.WriteLine("Enter regnr");
            string reg = Console.ReadLine();
            Console.WriteLine("Enter Color");
            string col = Console.ReadLine();
            Console.WriteLine("Enter numer of wheels");
            int wheels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter brand");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter nr of seats");
            int seats = Convert.ToInt32(Console.ReadLine());
            Airplane a = new Airplane(reg, col, wheels, brand, seats);
            if (handler.Add(a) == true)
            { Console.WriteLine("The plane is added to the garage"); }
            else { Console.WriteLine("The plane couldn´t be added to the garage, not enough parkingspaces"); }
        }


    }



}