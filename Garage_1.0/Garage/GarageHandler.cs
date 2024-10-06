using Garage_1._0.User;
using Garage_1._0.Vehicle;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage_1._0.Garage
{
    internal class GarageHandler : IHandler
    {
        private static Garage.Garage<Vehicle.Vehicle> garage = null!;

        internal static void ListVehicles()
        {
            if (!GarageExist()) { return; }
            garage.ListVehicles();
        }

        internal static void ListVehicleTypes()
        {
            if (!GarageExist()) { return; }
            garage.ListTypes();
        }

        internal static void AddVehicle(Vehicle.Vehicle vehicle)
        {
            if (!GarageExist()) { return; }
            garage.AddVehicle(vehicle);
        }

        internal static void RemoveVehicle(string license)
        {
            if (!GarageExist()) { return; }
            garage.RemoveVehicle(license);
        }

        internal static void NewGarage(uint size)
        {
            garage = new Garage.Garage<Vehicle.Vehicle>(size);
            User.UI.PrintConfirmationMessage($"New garage created with capacity: {garage.Capacity}");
        }

        internal static void SearchByLicense(string license)
        {
            if (!GarageExist()) { return; }
            if (garage.CheckLicense(license))
            {
                User.UI.PrintConfirmationMessage($"Vehicle with license {license} is currently in the garage.");
            }
            else
            {
                User.UI.PrintErrorMessage($"No vehicle matching license {license} could be found in the garage.");
            }
        }

        internal static void SearchByPropery(string input)
        {
            if (!GarageExist()) { return; }
            string[] search = input.Split(new char[] { ',' }, StringSplitOptions.None);
            if (search.Length != 4)
            {
                User.UI.PrintErrorMessage("Use the format [TYPE],[LICENSE],[COLOR],[WHEELS] and leave empty if no value.");
                return;
            }
            string type = search[0];
            string license = search[1];
            string color = search[2];
            if (!string.IsNullOrEmpty(search[3]) && !uint.TryParse(search[3], out uint wheels))
            {
                User.UI.PrintErrorMessage("Wheels has to be a valid number or left empty.");
                return;
            }
            uint.TryParse(search[3], out wheels);
            garage.SearchByProperty(type, license, color, wheels);
        }

        internal static bool GarageExist()
        {
            if (garage == null)
            {
                User.UI.PrintErrorMessage("You need to create a new garage first.");
                return false;
            }
            return true;
        }

        internal static Car CreateCar(string license, string color, uint wheels, string fuelType)
        {
            return new Vehicle.Car(license, color, wheels, fuelType);
        }

        internal static Bus CreateBus(string license, string color, uint wheels, uint seats)
        {
            return new Vehicle.Bus(license, color, wheels, seats);
        }

        internal static Boat CreateBoat(string license, string color, uint wheels, double length)
        {
            return new Vehicle.Boat(license, color, wheels, length);
        }

        internal static Airplane CreateAirplane(string license, string color, uint wheels, uint engines)
        {
            return new Vehicle.Airplane(license, color, wheels, engines);
        }

        internal static bool CheckLicense(string license)
        {
            return garage.CheckLicense(license);
        }
    }
}
