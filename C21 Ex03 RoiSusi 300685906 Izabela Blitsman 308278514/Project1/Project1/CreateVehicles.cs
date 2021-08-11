using System;
using System.Collections.Generic;
using System.Text;


//Section 3
namespace Project1
{
    public class CreateVehicles
    {
        private Dictionary<int, string> listOfAllVehicles = new Dictionary<int, string>();

        public Dictionary<string, string> GetListOfValues(string type)
        {
            Dictionary<string, string> listOfValues = new Dictionary<string, string>();
            //Add here any new Class and it will Appear in the UI
            switch (type)
            {
                case "FuelCar":
                    {
                        listOfValues.Clear();
                        Vehicle fuelCar = new FuelCar();
                        listOfValues = fuelCar.GetExpectation();
                        break;
                    }
                case "ElectricCar":
                    {
                        listOfValues.Clear();
                        Vehicle electricCar = new ElectricCar();
                        listOfValues = electricCar.GetExpectation();
                        break;
                    }
                case "ElectricMotorcycle":
                    {
                        listOfValues.Clear();
                        Vehicle electricMotorcycle = new ElectricMotorcycle();
                        listOfValues = electricMotorcycle.GetExpectation();
                        break;
                    }
                case "FuelMotorcycle":
                    {
                        listOfValues.Clear();
                        Vehicle fuelMotorcycle = new FuelMotorcycle();
                        listOfValues = fuelMotorcycle.GetExpectation();
                        break;
                    }
                case "Truck":
                    {
                        listOfValues.Clear();
                        Vehicle truck = new Truck();
                        listOfValues = truck.GetExpectation();
                        break;
                    }
            }
            return listOfValues;
        }

        public void AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser, Garage garageOperation)
        {
            //Garage garageOperation = garage;

            //Add here any new Class to Create it
            switch (typeOfVehicle)
            {
                case "ElectricCar":
                    {
                        string i_firstName = valuesEnterByTheUser[0];
                        string i_Phone = valuesEnterByTheUser[1];
                        string i_Model = valuesEnterByTheUser[2];
                        string i_Licence = valuesEnterByTheUser[3];
                        string i_EnergyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        PaintColor i_PaintColor = (PaintColor)Enum.Parse(typeof(PaintColor), valuesEnterByTheUser[5], true);
                        string i_NumberOfDoors = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float EnergyOrFuel = float.Parse(i_EnergyOrFuel);
                        int NumberOfDoors = int.Parse(i_NumberOfDoors);

                        Vehicle electricCar = new ElectricCar(i_Model, i_Licence, EnergyOrFuel, i_PaintColor, NumberOfDoors);
                        garageOperation.AddVehicleToGarrage(electricCar, i_firstName, i_Phone);
                        break;
                    }
                case "FuelCar":
                    {
                        string i_firstName = valuesEnterByTheUser[0];
                        string i_Phone = valuesEnterByTheUser[1];
                        string i_Model = valuesEnterByTheUser[2];
                        string i_Licence = valuesEnterByTheUser[3];
                        string i_EnergyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        PaintColor i_PaintColor = (PaintColor)Enum.Parse(typeof(PaintColor), valuesEnterByTheUser[5], true);
                        string i_NumberOfDoors = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float EnergyOrFuel = float.Parse(i_EnergyOrFuel);
                        int NumberOfDoors = int.Parse(i_NumberOfDoors);

                        Vehicle electricCar = new FuelCar(i_Model, i_Licence, EnergyOrFuel, i_PaintColor, NumberOfDoors);
                        garageOperation.AddVehicleToGarrage(electricCar, i_firstName, i_Phone);
                        break;
                    }

                case "FuelMotorcycle":
                    {

                        string i_firstName = valuesEnterByTheUser[0];
                        string i_Phone = valuesEnterByTheUser[1];
                        string i_Model = valuesEnterByTheUser[2];
                        string i_Licence = valuesEnterByTheUser[3];
                        string i_EnergyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        TypeOfLicense i_TypeOfLicense = (TypeOfLicense)Enum.Parse(typeof(TypeOfLicense), valuesEnterByTheUser[5], true);
                        string i_EngineCapacity = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float EnergyOrFuel = float.Parse(i_EnergyOrFuel);
                        int EngineCapacity = int.Parse(i_EngineCapacity);

                        Vehicle fuelMotorcycle = new FuelMotorcycle(i_Model, i_Licence, EnergyOrFuel, i_TypeOfLicense, EngineCapacity);
                        garageOperation.AddVehicleToGarrage(fuelMotorcycle, i_firstName, i_Phone);
                        break;
                    }

                case "ElectricMotorcycle":
                    {

                        string i_firstName = valuesEnterByTheUser[0];
                        string i_Phone = valuesEnterByTheUser[1];
                        string i_Model = valuesEnterByTheUser[2];
                        string i_Licence = valuesEnterByTheUser[3];
                        string i_EnergyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        TypeOfLicense i_TypeOfLicense = (TypeOfLicense)Enum.Parse(typeof(TypeOfLicense), valuesEnterByTheUser[5], true);
                        string i_EngineCapacity = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float EnergyOrFuel = float.Parse(i_EnergyOrFuel);
                        int EngineCapacity = int.Parse(i_EngineCapacity);

                        Vehicle electricCar = new ElectricMotorcycle(i_Model, i_Licence, EnergyOrFuel, i_TypeOfLicense, EngineCapacity);
                        garageOperation.AddVehicleToGarrage(electricCar, i_firstName, i_Phone);
                        break;
                    }
            }


        }

        public Dictionary<int, string> ListOfAllVehicles()
        {
            int i = 1;
            foreach (Type type in typeof(Vehicle).Assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Vehicle)))
                {
                    listOfAllVehicles.Add(i, type.Name);
                    i++;
                }
            }
            return listOfAllVehicles;
        }
    }
}
