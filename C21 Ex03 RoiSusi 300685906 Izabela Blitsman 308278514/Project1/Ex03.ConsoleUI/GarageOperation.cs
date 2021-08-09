using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Ex03.ConsoleUI
{
    public class GarageOperation
    {
        public static void InvokeGarage()
        {
            OperationsVehicles garage = new OperationsVehicles();
            string getInputFromUser = string.Empty;
            string welcome = string.Empty;
            bool loopForVehileSelection = true;
            List<string> typeOfVehicles = new List<string>();
            AddNamesOfVehivle(ref typeOfVehicles);




            System.Console.WriteLine(ChooseCar());
            getInputFromUser = System.Console.ReadLine();

            while (loopForVehileSelection)
            {
                switch (getInputFromUser)
                {
                    case "1":
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("Dont Worry we'll get your {0} Fixed", typeOfVehicles[0]);
                            System.Console.WriteLine(AddInformation());
                            loopForVehileSelection = false;
                            break;
                        }
                    case "2":
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("Dont Worry we'll get your {0} Fixed", typeOfVehicles[1]);
                            System.Console.WriteLine(AddInformation());
                            loopForVehileSelection = false;
                            break;
                        }
                    case "3":
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("Dont Worry we'll get your {0} Fixed", typeOfVehicles[2]);
                            System.Console.WriteLine(AddInformation());
                            loopForVehileSelection = false;
                            break;
                        }
                    case "4":
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("Dont Worry we'll get your {0} Fixed", typeOfVehicles[3]);
                            System.Console.WriteLine(AddInformation());
                            loopForVehileSelection = false;
                            break;
                        }
                    case "5":
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("Dont Worry we'll get your {0} Fixed", typeOfVehicles[5]);
                            System.Console.WriteLine(AddInformation());
                            loopForVehileSelection = false;
                            break;
                        }
                    case "Q":
                    default:
                        {
                            System.Console.WriteLine("Please Select 1-5 or Q to Exit");
                            loopForVehileSelection = false;
                            break;
                        }

                }
            }
        }


        public static string ChooseCar()
        {
            string welcome = string.Format("Hello and Welcome to The Garage\n" +
                            "Please Choose the vehicle you want to enter the garage:\n" +
                            "1. Fuel Car\n" +
                            "2. Electric Car\n" +
                            "3. Fuel Motorcycle\n" +
                            "4. Elelctirc Motorcyler\n" +
                            "5. Trunk\n" +
                            "For exit please press \'Q\'\n");

            return welcome;
        }

        public static string AddInformation()
        {
            string information = string.Format("Please add the following information\n" +
                "1. Name\n" +
                "2. Licence Number\n" +
                "3. Fuel left in the Tank\n" +
                "4. Air presure of the wheels\n");
            return information;
        }

        public static void AddNamesOfVehivle(ref List<string> typeOfVehicles)
        {
            typeOfVehicles.Add("Fuel Car");
            typeOfVehicles.Add("Electric Car");
            typeOfVehicles.Add("Fuel Motorcycler");
            typeOfVehicles.Add("Electirc Motorcycler");
            typeOfVehicles.Add("Trunk");

        }


    }
}
