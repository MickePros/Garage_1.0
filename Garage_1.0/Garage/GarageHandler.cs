using Garage_1._0.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Garage
{
    internal class GarageHandler : IHandler
    {
        internal static void AddRemoveVehicle()
        {
            bool keepAlive = true;
            do
            {
                Console.WriteLine("Would you like to [ADD] or [REMOVE] a vehicle to/from the garage? Otherwise use [BACK] to return to main menu.");
                string input = UI.CheckUserInput();
                switch (input)
                {
                    case "add":
                        Console.Clear();
                        //Check if garage has space.
                        Console.WriteLine("Tell me about the vehicle you would like to add.");
                        Console.Write($"What license number does the {type} have? ");
                        string license = UI.CheckUserInput().ToUpper();
                        //Check if already added to garage.
                        Console.Write("What type of vehicle is it? We accept [CAR], [BUS], [BOAT] or [AIRPLANE]: ");
                        string type = UI.CheckUserInput();
                        Console.Write($"What color is the {type}? ");
                        string color = UI.CheckUserInput();
                        Console.Write($"How many wheels does the {type} have? ");
                        uint wheels = UI.AskForNumber();
                        switch (type)
                        {
                            case "car":
                                Console.Write($"What fuel does the {type} use? example: Petrol, Diesel or Electric. ");
                                string fuelType = UI.CheckUserInput();
                                break;
                            case "bus":
                                Console.Write($"How many seats does the {type} have? ");
                                uint seats = UI.AskForNumber();
                                break;
                            case "boat":
                                Console.Write($"How long is the {type}? ");
                                double length = UI.AskForDouble();
                                break;
                            case "airplane":
                                Console.Write($"How many engines does the {type} have? ");
                                uint engines = UI.AskForNumber();
                                break;
                        }
                        break;
                    case "remove":
                        Console.Clear();
                        Console.WriteLine("remove");
                        break;
                    case "back":
                        Console.Clear();
                        keepAlive = false;
                        Console.WriteLine("back");
                        break;
                    default:
                        Console.Clear();
                        UI.PrintErrorMessage("Only [ADD], [REMOVE] or [BACK] are accepted inputs.");
                        break;
                }
            } while (keepAlive);
        }

        internal static void ListVehicles()
        {
            throw new NotImplementedException();
        }

        internal static void ListVehicleTypes()
        {
            throw new NotImplementedException();
        }

        internal static void NewGarage()
        {
            throw new NotImplementedException();
        }

        internal static void SearchByLicense()
        {
            throw new NotImplementedException();
        }

        internal static void SearchByPropery()
        {
            throw new NotImplementedException();
        }
    }
}
