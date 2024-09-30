using Garage_1._0.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

                string input = Console.ReadLine();
                if (!CheckUserInput(input)){
                    continue;
                }

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

        private static bool CheckUserInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                PrintErrorMessage("Input can not be empty.");
                return false;
            }
            return true;
        }

        private static void PrintConfirmationMessage( string message ) { Console.WriteLine( message ); }

        private static void PrintErrorMessage( string error ) { Console.WriteLine( error ); }
    }
}
