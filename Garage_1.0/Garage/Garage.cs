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

namespace Garage_1._0.Garage
{
    internal class Garage<T> where T : Vehicle.Vehicle
    {
        private Vehicle.Vehicle[] vehicles;
        private uint nextSlot;

        public uint Capacity { get; set; }

        public Garage(uint size)
        {
            Capacity = size;
            nextSlot = 0;
            vehicles = new Vehicle.Vehicle[size];

            //Seed
            vehicles[0] = new Vehicle.Car("ABC123", "RED", 4, "GAS");
            vehicles[1] = new Vehicle.Car("DEF456", "BLUE", 4, "ELECTRIC");
            vehicles[5] = new Vehicle.Boat("GHI789", "WHITE", 0, 5.5);
        }

        internal IEnumerable<Vehicle.Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public bool AddVehicle(Vehicle.Vehicle vehicle)
        {
            if (nextSlot < Capacity)
            {
                vehicles[nextSlot] = vehicle;
                nextSlot++;
                User.UI.PrintConfirmationMessage($"{vehicle.GetType().Name} has been added to the garage");
            }
            else
            {
                User.UI.PrintErrorMessage("Garage is currently full");
            }

            return true;
        }

        public bool CheckLicense(string license)
        {
            IEnumerable<Vehicle.Vehicle> vehiclesEnumerable = GetVehicles();
            foreach (Vehicle.Vehicle vehicle in vehiclesEnumerable)
            {
                if (vehicle.License == license)
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
    }
}
