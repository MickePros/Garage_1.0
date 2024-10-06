using Garage_1._0.Vehicle;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage_1._0.Garage
{
    internal class Garage<T> where T : Vehicle.Vehicle
    {
        private Vehicle.Vehicle[] vehicles;

        public uint Capacity { get; set; }

        public Garage(uint size)
        {
            Capacity = size;
            vehicles = new Vehicle.Vehicle[size];

            //Seed
            vehicles[0] = new Vehicle.Car("ABC123", "RED", 4, "GAS");
            vehicles[5] = new Vehicle.Car("DEF456", "BLUE", 4, "ELECTRIC");
            vehicles[1] = new Vehicle.Boat("GHI789", "WHITE", 0, 5.5);
        }

        internal IEnumerable<Vehicle.Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public bool AddVehicle(Vehicle.Vehicle addVehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = addVehicle;
                    User.UI.PrintConfirmationMessage($"{addVehicle.GetType().Name} has been added to the garage.");
                    return true;
                }
            }
            User.UI.PrintErrorMessage("Garage is currently full");
            return false;
        }

        public bool RemoveVehicle(string license)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    if (vehicles[i].License == license)
                    {
                        vehicles[i] = null;
                        User.UI.PrintConfirmationMessage($"{license} has been removed from the garage.");
                        return true;
                    }
                }
            }
            User.UI.PrintErrorMessage($"{license} could not be found in the garage.");
            return false;
        }

        public bool CheckLicense(string license)
        {
            IEnumerable<Vehicle.Vehicle> vehiclesEnumerable = GetVehicles();
            foreach (Vehicle.Vehicle vehicle in vehiclesEnumerable)
            {
                if (vehicle.License == license.ToUpper())
                    return true;
            }
            return false;
        }

        public void ListVehicles()
        {
            IEnumerable<Vehicle.Vehicle> vehiclesEnumerable = GetVehicles();
            foreach (Vehicle.Vehicle vehicle in vehiclesEnumerable)
            {
                if (vehicle != null)
                    Console.WriteLine(vehicle.ToString());
            }
        }

        public void ListTypes()
        {
            string[] types = { "Car", "Bus", "Boat", "Airplane" };
            foreach (string type in types)
            {
                int result = vehicles.Where(v => v != null && v.GetType().Name == type).Count();
                Console.WriteLine($"Currently there are {result} of the type {type} in the garage");
            }
        }

        internal void SearchByProperty(string type, string license, string color, uint wheels)
        {
            var result = vehicles.Where(v => v != null
                && (string.IsNullOrEmpty(type) ? (true) : (v.GetType().Name == type))
                && (string.IsNullOrEmpty(license) ? (true) : (v.License == license.ToUpper()))
                && (string.IsNullOrEmpty(color) ? (true) : (v.Color == color.ToUpper()))
                && (wheels >= 0 ? (true) : (v.Wheels == wheels))
            );
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            return;
        }
    }
}
