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
                        Console.WriteLine("\nInvalid selection! Try again.");
                        break;
                }
            } while (selection != 'Q');

            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nWelcome to your vehicle inventory");
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
                            Console.WriteLine("Back to main menu...");
                            break;
                        default:
                            Console.WriteLine("Invalid selection! Try again.");
                            break;
                    }
                } while (displaySelection != "Q");
            }
            else
            {
                Console.WriteLine("\nYour inventory is empty. Please add a vehicle first.");
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
                        Console.WriteLine("\nInvalid Selection! Try again.");
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
                        Console.WriteLine("\nInvalid selection! Try again.");
                        break;
                }
            } while (hatchSelection != 'Y' && hatchSelection != 'N');
            Console.Write("\nMiles per Gallon: ");
            mpg = Convert.ToInt32(Console.ReadLine());

            Car carToAdd = new Car(vin, year, make, model, color, mpg, type, hatch);
            vehicles.Add(carToAdd);

            Console.WriteLine("************************");
            Console.WriteLine("Car added.");
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
                        Console.WriteLine("Invalid selection! Try again.");
                        break;
                }
            } while (towSelection != 'Y' || towSelection != 'N');

            Truck truckToAdd = new Truck(vin, year, make, model, color, mpg, tow, wheels);
            vehicles.Add(truckToAdd);
            Console.WriteLine("Truck added.");
            Console.WriteLine(truckToAdd.ToString());

        }

        static void HandleRemove()
        {
            int index = -1;
            string vinToDelete = "";
            do
            {
                HandleRecent();
                Console.Write("Enter the vin# of the vehicle you want to delete: ");
                vinToDelete = Console.ReadLine();
                index = vehicles.FindIndex(v => v.VinNumber == vinToDelete);
                switch (index)
                {
                    case -1:
                        Console.WriteLine("Vehicle not found. Try again.");
                        break;
                    default:
                        vehicles.RemoveAt(index);
                        Console.WriteLine("Vehicle removed.");
                        break;
                }
            } while (index == -1);
        }

    }
}
