using SQLite;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace VehiclePractice
{
    class Program
    {
        public static List<Vehicle> vehicles = new List<Vehicle>();
        public static char selection;
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to your vehicle inventory");
            do
            {
                DisplayMenu();
                selection = GetSelection();
                switch(selection)
                {
                    case 'D':
                        Console.Clear();
                        HandleDisplay();
                        break;
                    case 'A':
                        Console.Clear();
                        HandleAdd();
                        break;
                    case 'R':
                        Console.Clear();
                        HandleRemove();
                        break;
                    case 'Q':
                        Console.WriteLine("\nGoodbye.");
                        break;
                    default:
                        Console.Clear();
                        Color("\nInvalid selection! Try again.", ConsoleColor.Red);
                        break;
                }
            } while (selection != 'Q');

            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please select from one of the folowing options:");
            Console.WriteLine("\nD - Display vehicles");
            Console.WriteLine("A - Add a vehicle");
            Console.WriteLine("R - Remove a vehicle");
            Console.WriteLine("Q - Quit");
            Console.Write("Enter your selection: ");
        }

        static char GetSelection()
        {
            char selection = Console.ReadKey().KeyChar;
            return char.ToUpper(selection);
        }

        static void HandleDisplay()
        {
            if(vehicles.Count > 0)
            {
                string displaySelection = "";
                do
                {
                    Console.WriteLine("How would you like to sort your vehicles?");
                    Console.WriteLine("R - Recently Added");
                    Console.WriteLine("Y - Year");
                    Console.WriteLine("MA - Make");
                    Console.WriteLine("MO - Model");
                    Console.WriteLine("C - Color");
                    Console.WriteLine("MPG - Miles per Gallon");
                    Console.WriteLine("Q - Go back");
                    Console.Write("Enter your selection: ");
                    displaySelection = Console.ReadLine().ToUpper();
                    switch (displaySelection)
                    {
                        case "R":
                            HandleRecent();
                            break;
                        case "Y":
                            SortBy(v => v.Year);
                            break;
                        case "MA":
                            SortBy(v => v.Make);
                            break;
                        case "MO":
                            SortBy(v => v.Model);
                            break;
                        case "C":
                            SortBy(v => v.Color);
                            break;
                        case "MPG":
                            SortBy(v => v.MPG);
                            break;
                        case "Q":
                            Console.Clear();
                            Color("Back to main menu...", ConsoleColor.Yellow);
                            break;
                        default:
                            Console.Clear();
                            Color("Invalid selection! Try again.", ConsoleColor.Red);
                            break;
                    }
                } while (displaySelection != "Q");
            }
            else
            {
                Color("\nYour inventory is empty. Please add a vehicle first.", ConsoleColor.Yellow);
            }
        }

        static void HandleRecent()
        {
            foreach(Vehicle v in vehicles)
            {
                Console.WriteLine(v.ToString());
                Console.WriteLine("------------------------------");
            }
        }

        static void SortBy(Func<Vehicle, IComparable> getProp)
        {
            List<Vehicle> sortedList = vehicles.OrderBy(v => getProp(v)).ToList();
            Console.Clear();
            Console.WriteLine("Here are your vehicles:");
            Console.WriteLine("-----------------------------");
            foreach(Vehicle v in sortedList)
            {
                Console.WriteLine(v.ToString());
                Console.WriteLine("------------------------------");
            }
        }

        static void HandleAdd()
        {
            char typeSelection;
            do
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Pick from the options below:");
                Console.WriteLine("C - Add a car");
                Console.WriteLine("T - Add a truck");
                Console.WriteLine("Q - Go back");
                Console.Write("Enter your selection: ");
                typeSelection = char.ToUpper(Console.ReadKey().KeyChar);
                switch(typeSelection)
                {
                    case 'C':
                        HandleAddCar();
                        break;
                    case 'T':
                        HandleAddTruck();
                        break;
                    case 'Q':
                        Console.WriteLine("\nBack to main menu...");
                        break;
                    default:
                        Color("\nInvalid Selection! Try again.", ConsoleColor.Red);
                        break;
                }
            } while(typeSelection != 'C' && typeSelection != 'T' && typeSelection != 'Q');
        }

        static void HandleAddCar()
        {
            string vin, make, model, color, type;
            int year, mpg;
            bool hatch = false;
            char hatchSelection;
            Console.WriteLine("\nPlease enter the following information for the car:");
            Console.Write("\nVin #: ");
            vin = Console.ReadLine();
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Make: ");
            make = Console.ReadLine();
            Console.Write("Model: ");
            model = Console.ReadLine();
            Console.Write("Color: ");
            color = Console.ReadLine();
            Console.Write("Type (Sedan, SUV, Crossover etc.): ");
            type = Console.ReadLine();
            do
            {
                Console.Write("Hatchback? (enter \'Y\' or \'N\'): ");
                hatchSelection = char.ToUpper(Console.ReadKey().KeyChar);
                switch(hatchSelection)
                {
                    case 'Y':
                        hatch = true;
                        break;
                    case 'N':
                        hatch = false;
                        break;
                    default:
                        Color("\nInvalid selection! Try again.", ConsoleColor.Red);
                        break;
                }
            } while (hatchSelection != 'Y' && hatchSelection != 'N');
            Console.Write("\nMiles per Gallon: ");
            mpg = Convert.ToInt32(Console.ReadLine());

            Car carToAdd = new Car(vin, year, make, model, color, mpg, type, hatch);
            vehicles.Add(carToAdd);

            Console.Clear();
            Console.WriteLine("\n************************");
            Color("Car added!", ConsoleColor.Cyan);
            Console.WriteLine(carToAdd.ToString());
            Console.WriteLine("************************");


        }

        static void HandleAddTruck()
        {
            string vin, make, model, color;
            int year, mpg, wheels;
            bool tow = false;
            char towSelection;
            Console.WriteLine("\nPlease tner the following information for the car:");
            Console.Write("\nVin #: ");
            vin = Console.ReadLine();
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Make: ");
            make = Console.ReadLine();
            Console.Write("Model: ");
            model = Console.ReadLine();
            Console.Write("Color: ");
            color = Console.ReadLine();
            Console.Write("Miles per Gallon: ");
            mpg = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nuumber of wheels: ");
            wheels = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Tow package? (enter \'Y\' or \'N\': )");
                towSelection = char.ToUpper(Console.ReadKey().KeyChar);
                switch (towSelection)
                {
                    case 'Y':
                        tow = true;
                        break;
                    case 'N':
                        tow = false;
                        break;
                    default:
                        Color("Invalid selection! Try again.", ConsoleColor.Red);
                        break;
                }
            } while (towSelection != 'Y' && towSelection != 'N');

            Truck truckToAdd = new Truck(vin, year, make, model, color, mpg, tow, wheels);
            vehicles.Add(truckToAdd);
            Console.WriteLine("************************");
            Color("Truck added.", ConsoleColor.Cyan);
            Console.WriteLine(truckToAdd.ToString());
            Console.WriteLine("************************");

        }

        static void HandleRemove()
        {
            if(vehicles.Count > 0)
            {
                int index = -1;
                string vinToDelete = "";
                do
                {
                    Console.WriteLine();
                    HandleRecent();
                    Console.Write("Enter the vin# of the vehicle you want to delete: ");
                    vinToDelete = Console.ReadLine();
                    index = vehicles.FindIndex(v => v.VinNumber == vinToDelete);
                    switch (index)
                    {
                        case -1:
                            Console.Clear();
                            Color("\nVehicle not found. Try again.", ConsoleColor.Red);
                            break;
                        default:
                            vehicles.RemoveAt(index);
                            Console.WriteLine("Vehicle removed.");
                            break;
                    }
                } while (index == -1);
            }
            else
            {
                Color("\nThere are no vehicles in your collection", ConsoleColor.Yellow);
            }
        }

        static void Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }
}
