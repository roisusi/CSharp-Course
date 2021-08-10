using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Ex03.ConsoleUI
{
    public class GarageOperation
    {

        private static OperationsVehicles garage = new OperationsVehicles();

        public static void InvokeGarage()
        {
            WelcomeMenu();
        }

        public static string WelcomeMenu()
        {
            System.Console.Clear();
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
            System.Console.WriteLine(welcome);
            getInputFromUser = System.Console.ReadLine();

            while (loopForVehileSelection)
            {
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
                    case "8":
                        {
                            
                            loopForVehileSelection = false;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Please Select 1-7 or Q to Exit");
                            loopForVehileSelection = false;
                            break;
                        }

                }
            }

            return welcome;
        }

        public static void ChooseCar()
        {
            System.Console.Clear();
            Dictionary<int, string> listOfVehicles = ListOfAllVehicles();
            bool loopForVehileSelection = true;
            string getInputFromUser = string.Empty;
            while (loopForVehileSelection)
            {
                
                
                //string chooseCar = string.Format("Please Choose the vehicle you want to enter the garage:\n" +
                //            "1. Fuel Car\n" +
                //            "2. Electric Car\n" +
                //            "3. Fuel Motorcycle\n" +
                //            "4. Elelctirc Motorcyler\n" +
                //            "5. Trunk\n" +
                //            "Please press \'Q\' to return to Menu \n");
                System.Console.WriteLine(chooseCar);
                getInputFromUser = System.Console.ReadLine();


                switch (getInputFromUser)
                {
                    case "1":
                        {
                            AddVehicle("FuelCar");
                            System.Console.WriteLine("Car was add successfully");
                            break;
                        }
                    case "2":
                        {
                            AddVehicle("ElectricCar");
                            System.Console.WriteLine("Car was add successfully");
                            break;
                        }
                    case "3":
                        {
                            loopForVehileSelection = false;
                            break;
                        }
                    case "4":
                        {
                            
                            loopForVehileSelection = false;
                            break;
                        }
                    case "5":
                        {
                            loopForVehileSelection = false;

                            break;
                        }
                    case "Q":
                        {
                            WelcomeMenu();
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Please Select 1-5 or Q to Exit");
                            loopForVehileSelection = true;
                            break;
                        }

                }
            }

        }

        public static void AddVehicle(string i_Type)
        {
            string model = string.Empty; ;
            string LicenceNumber = string.Empty;
            string fuelOrEnergey = string.Empty;
            string firstName = string.Empty;
            string phoneNumber = string.Empty;
            PaintColor getPaintFromUser = 0;
            string getPaintColorFromUser = string.Empty;
            string numberOfDoors = string.Empty;

            System.Console.WriteLine("Please add the following information");

            System.Console.WriteLine("Car Model");
            model = System.Console.ReadLine();

            System.Console.WriteLine("Licence Number");
            LicenceNumber = System.Console.ReadLine();

            System.Console.WriteLine("Fuel or Battery left");
            fuelOrEnergey = System.Console.ReadLine();

            System.Console.WriteLine("First Name");
            firstName = System.Console.ReadLine();

            System.Console.WriteLine("Phone Number");
            phoneNumber = System.Console.ReadLine();

            //System.Console.WriteLine("Air presure of the wheels");

            if (i_Type.Equals("ElectricCar") || i_Type.Equals("FuelCar"))
            {
                System.Console.WriteLine("Color of the Car\n" +
                                            "1. Yellow\n" +
                                            "2. White\n" +
                                            "3. Black\n" +
                                            "4. Blue");
                getPaintColorFromUser = System.Console.ReadLine();
                getPaintFromUser = ChoosePaintColor(getPaintColorFromUser);

                System.Console.WriteLine("Color of the Car\n" +
                                            "1. 2\n" +
                                            "2. 3\n" +
                                            "3. 4\n" +
                                            "4. 5");
                numberOfDoors = System.Console.ReadLine();
            }

            if (i_Type.Equals("ElectricCar"))
            {
                garage.AddElectircCar(model, LicenceNumber, fuelOrEnergey, firstName, phoneNumber, getPaintFromUser, numberOfDoors);
            }

            if (i_Type.Equals("FuelCar"))
            {
                garage.AddFuelCar(model, LicenceNumber, fuelOrEnergey, firstName, phoneNumber, getPaintFromUser, numberOfDoors);
            }

        }

        public static PaintColor ChoosePaintColor(string getPaintColorFromUser)
        {
            PaintColor sendPaintColor = 0;
            foreach (PaintColor paintColor in Enum.GetValues(typeof(PaintColor)))
            {
                if (((int)paintColor).ToString().Equals(getPaintColorFromUser))
                {
                    sendPaintColor = paintColor;
                }
            }
            return sendPaintColor;
        }

        public static void SearchACar()
        {
            string inputFromUser = string.Empty;
            string getInfo = string.Empty;
            System.Console.WriteLine("Please enter licence number or Q to return to Menu");
            inputFromUser = System.Console.ReadLine();
            
            getInfo = garage.PrintCarInformation(inputFromUser);
            if (!inputFromUser.Equals("Q"))
            {
                if (getInfo.Equals(string.Empty))
                {
                    System.Console.WriteLine("Not Found");
                }
                else
                {
                    System.Console.WriteLine(getInfo);
                }
            }
            else
            {
                WelcomeMenu();
            }
        }

    }
}
