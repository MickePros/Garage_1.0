using Garage_1._0.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage_1._0.User
{
    internal class UI : IUI
    {
        public static void ShowMainMenu()
        {
            bool keepAlive = true;

            do
            {
                Console.WriteLine(
                    "\nChoose an action using numbers on your keyboard." +
                    $"\n1: List all vehicles in the garage." +
                    $"\n2: List vehicle types and amount of each." +
                    $"\n3: Add/Remove vehicle." +
                    $"\n4: Advanced search for vehicles." +
                    $"\n5: Search vehicle by license." +
                    $"\n6: Create new garage and assign capacity." +
                    $"\n7: Exit application.");

                string input = CheckUserInput();

                switch (input[0])
                {
                    case '1':
                        Console.Clear();
                        GarageHandler.ListVehicles();
                        break;
                    case '2':
                        Console.Clear();
                        GarageHandler.ListVehicleTypes();
                        break;
                    case '3':
                        Console.Clear();
                        AddRemoveVehicle();
                        break;
                    case '4':
                        Console.Clear();
                        GarageHandler.SearchByPropery();
                        break;
                    case '5':
                        Console.Clear();
                        Console.Write($"What license number does the vehicle have? ");
                        string license = CheckUserInput().ToUpper();
                        GarageHandler.SearchByLicense(license);
                        break;
                    case '6':
                        Console.Clear();
                        NewGarage();
                        break;
                    case '7':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        PrintErrorMessage("Use 1-7 to select from the menu.");
                        break;
                }
            } while (keepAlive);
        }

        internal static void AddRemoveVehicle()
        {
            bool keepAlive = true;
            do
            {
                Console.WriteLine("Would you like to [ADD] or [REMOVE] a vehicle to/from the garage? Otherwise use [BACK] to return to main menu.");
                string input = CheckUserInput();
                switch (input)
                {
                    case "add":
                        Console.Clear();
                        //Check if garage has space.
                        Console.WriteLine("Tell me about the vehicle you would like to add.");
                        Console.Write($"What license number does the vehicle have? ");
                        string license = CheckUserInput().ToUpper();
                        //Check if already added to garage.
                        Console.Write("What type of vehicle is it? We accept [CAR], [BUS], [BOAT] or [AIRPLANE]: ");
                        string type = CheckUserInput();
                        Console.Write($"What color is the {type}? ");
                        string color = CheckUserInput();
                        Console.Write($"How many wheels does the {type} have? ");
                        uint wheels = AskForNumber();
                        switch (type)
                        {
                            case "car":
                                Console.Write($"What fuel does the {type} use? example: Petrol, Diesel or Electric. ");
                                string fuelType = CheckUserInput();
                                Vehicle.Car car = GarageHandler.CreateCar(license, color, wheels, fuelType);
                                GarageHandler.AddVehicle(car);
                                break;
                            case "bus":
                                Console.Write($"How many seats does the {type} have? ");
                                uint seats = AskForNumber();
                                break;
                            case "boat":
                                Console.Write($"How long is the {type}? ");
                                double length = AskForDouble();
                                break;
                            case "airplane":
                                Console.Write($"How many engines does the {type} have? ");
                                uint engines = AskForNumber();
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

        internal static void NewGarage()
        {
            Console.Write($"How large is the new garage? ");
            uint size = AskForNumber();
            GarageHandler.NewGarage(size);
        }

        internal static string CheckUserInput()
        {
            string input = "";
            bool valid = false;
            do
            {
                input = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(input))
                    return input;
                PrintErrorMessage("Input can not be empty, try again.");
            } while (!valid);
            return input;
        }

        internal static uint AskForNumber() {
            uint number = 0;
            bool valid = false;
            do
            {
                valid = uint.TryParse(Console.ReadLine(), out number);
                if (!valid) PrintErrorMessage("Please input a number 0 or higher");
            } while (!valid);
            return number;
        }
        internal static double AskForDouble()
        {
            double number = 0;
            bool valid = false;
            do
            {
                valid = double.TryParse(Console.ReadLine(), out number);
                if (!valid || number < 0) PrintErrorMessage("Please input a number 0.0 or higher");
            } while (!valid);
            return number;
        }

        public static void PrintConfirmationMessage( string message ) { Console.WriteLine( message ); }

        public static void PrintErrorMessage( string error ) { Console.WriteLine( error ); }
    }
}
