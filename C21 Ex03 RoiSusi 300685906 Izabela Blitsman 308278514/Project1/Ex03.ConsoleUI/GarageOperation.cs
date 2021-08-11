using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Ex03.ConsoleUI
{
    public class GarageOperation
    {

        private static Garage garageOperation = new Garage();
        private static Dictionary<int, string> listOfVehicles = garageOperation.ListOfAllVehicles();

        public static void InvokeGarage()
        {
            WelcomeMenu();
        }

        public static string WelcomeMenu()
        {
            bool orderByGarageStatus = false;
            string getInputFromUser = string.Empty;
            bool loopForVehileSelection = true;
            string welcome = string.Format("Hello and Welcome to The Garage\n" +
                            "Please select option from the Menu:\n" +
                            "1. Add a vehicle\n" +
                            "2. List of Cars\n" +
                            "3. Fuel Motorcycle\n" +
                            "4. Elelctirc Motorcyler\n" +
                            "5. Trunk\n" +
                            "6. Charge the battery\n" +
                            "7. Search for a car\n" +
                            "For exit please press \'Q\'\n");

            while (loopForVehileSelection)
            {
                System.Console.Clear();
                System.Console.WriteLine(welcome);
                getInputFromUser = System.Console.ReadLine();
                switch (getInputFromUser)
                {
                    case "1":
                        {
                            ChooseCar();
                            break;
                        }
                    case "2":
                        {
                            break;
                        }
                    case "3":
                        {
                            break;
                        }
                    case "4":
                        {
                            break;
                        }
                    case "5":
                        {
                            break;
                        }
                    case "6":
                        {
                            break;
                        }
                    case "7":
                        {
                            SearchACar();
                            break;
                        }
                    case "Q":
                        {
                            System.Console.WriteLine("Thank you and have a nice day");
                            loopForVehileSelection = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Please Select 1-7 or Q to Exit");
                            break;
                        }

                }
            }

            return welcome;
        }

        public static void ChooseCar()
        {
            System.Console.Clear();
            Dictionary<string, string> listOfParameters = new Dictionary<string, string>();
            List<string> valuesEnterByTheUser = new List<string>();
            string getInputFromUser = string.Empty;
            string chooseCarList = string.Empty;
            string informationOfVehicles = string.Empty;
            string carType = string.Empty;
            int correntInput = 0;
            System.Console.WriteLine("Please choose the vehicle you want to enter the garage:");
            foreach (int str in listOfVehicles.Keys)
            {
                chooseCarList = string.Format("{0}. {1}" , str , listOfVehicles[str]);
                System.Console.WriteLine(chooseCarList);
            }

            while (correntInput == 0)
            {
                getInputFromUser = System.Console.ReadLine();

                foreach (int str in listOfVehicles.Keys)
                {
                    int.TryParse(getInputFromUser, out correntInput);
                    if (str.Equals(correntInput))
                    {
                        listOfVehicles.TryGetValue(str, out carType);
                        listOfParameters = garageOperation.GetListOfValues(carType);
                    }
                }
            }

            System.Console.Clear();
            System.Console.WriteLine("Please enter the above infomration");

            foreach (string keys in listOfParameters.Keys)
            {
                informationOfVehicles = string.Format("{0}. {1}", keys, listOfParameters[keys]);
                System.Console.WriteLine(informationOfVehicles);
                getInputFromUser = System.Console.ReadLine();
                valuesEnterByTheUser.Add(getInputFromUser);
            }

            //Add Exceptions ??

            if (garageOperation.AddVehicle(carType, valuesEnterByTheUser, garageOperation) == false)
            {
                System.Console.WriteLine("Vehicle has add seccessfully press enter to return to menu");
            }
            else
            {
                System.Console.WriteLine("Vehicle already exists changed the vehicle to status InRepair");
            }
            System.Console.ReadLine();

        }

        public static void SearchACar()
        {
            string inputFromUser = string.Empty;
            string getInfo = string.Empty;
            System.Console.WriteLine("Please enter licence number or Q to return to Menu");
            inputFromUser = System.Console.ReadLine();
            
            getInfo = garageOperation.PrintCarByLicense(inputFromUser);
            if (!inputFromUser.Equals("Q"))
            {
                if (getInfo.Equals(string.Empty))
                {
                    System.Console.WriteLine("Not Found");
                    System.Console.WriteLine("Press enter to return to menu");
                    System.Console.ReadLine();
                }
                else
                {
                    System.Console.WriteLine(getInfo);
                    System.Console.WriteLine("Press enter to return to menu");
                    System.Console.ReadLine();
                }
            }
            else
            {
                WelcomeMenu();
            }
        }

    }
}
