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
                    $"\n3: Add/Remove vehicle using licenseplate." +
                    $"\n4: Advanced search for vehicles." +
                    $"\n5: Search vehicle by licenseplate." +
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
                        GarageHandler.AddRemoveVehicle();
                        break;
                    case '4':
                        Console.Clear();
                        GarageHandler.SearchByPropery();
                        break;
                    case '5':
                        Console.Clear();
                        GarageHandler.SearchByLicense();
                        break;
                    case '6':
                        Console.Clear();
                        GarageHandler.NewGarage();
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
