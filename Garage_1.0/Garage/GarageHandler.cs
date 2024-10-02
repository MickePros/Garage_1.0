using Garage_1._0.User;
using Garage_1._0.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Garage
{
    internal class GarageHandler : IHandler
    {
        private static Garage.Garage<Vehicle.Vehicle> garage = null!;

        internal static void ListVehicles()
        {
            if (garage == null)
            {
                User.UI.PrintErrorMessage("You need to create a new garage first.");
                return;
            }
            garage.ListVehicles();
        }

        internal static void ListVehicleTypes()
        {
            if (garage == null)
            {
                User.UI.PrintErrorMessage("You need to create a new garage first.");
                return;
            }
        }

        internal static void AddVehicle(Vehicle.Vehicle vehicle)
        {
            if (garage == null)
            {
                User.UI.PrintErrorMessage("You need to create a new garage first.");
                return;
            }
            garage.AddVehicle(vehicle);
        }

        internal static void NewGarage(uint size)
        {
            garage = new Garage.Garage<Vehicle.Vehicle>(size);
            User.UI.PrintConfirmationMessage($"New garage created with capacity: {garage.Capacity}");
        }

        internal static void SearchByLicense(string license)
        {
            if (garage == null)
            {
                User.UI.PrintErrorMessage("You need to create a new garage first.");
                return;
            }
            if (garage.CheckLicense(license))
            {
                User.UI.PrintConfirmationMessage($"Vehicle with license number {license} is currently in the garage.");
            }
            else
            {
                User.UI.PrintErrorMessage($"No vehicle matching license number {license} could be found in the garage.");
            }
        }

        internal static void SearchByPropery()
        {
            if (garage == null)
            {
                User.UI.PrintErrorMessage("You need to create a new garage first.");
                return;
            }
        }

        internal static Car CreateCar(string license, string color, uint wheels, string fuelType)
        {
            return new Vehicle.Car(license, color, wheels, fuelType);
        }
    }
}
