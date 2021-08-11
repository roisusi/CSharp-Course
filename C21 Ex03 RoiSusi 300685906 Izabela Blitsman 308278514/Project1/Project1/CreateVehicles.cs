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

        public bool AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser, Garage garageOperation)
        {
            //Add here any new Class to Create it
            bool addedSuccessfully = false;
            switch (typeOfVehicle)
            {
                case "ElectricCar":
                    {
                        string firstName = valuesEnterByTheUser[0];
                        string phone = valuesEnterByTheUser[1];
                        string model = valuesEnterByTheUser[2];
                        string licence = valuesEnterByTheUser[3];
                        string energyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        PaintColor paintColor = (PaintColor)Enum.Parse(typeof(PaintColor), valuesEnterByTheUser[5], true);
                        string numberOfDoors = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float energyOrFuelToFloat = float.Parse(energyOrFuel);
                        int numberOfDoorsToInt = int.Parse(numberOfDoors);

                        Vehicle electricCar = new ElectricCar(model, licence, energyOrFuelToFloat, paintColor, numberOfDoorsToInt);
                        addedSuccessfully = garageOperation.AddVehicleToGarrage(electricCar, firstName, phone);
                        break;
                    }
                case "FuelCar":
                    {
                        string firstName = valuesEnterByTheUser[0];
                        string phone = valuesEnterByTheUser[1];
                        string model = valuesEnterByTheUser[2];
                        string licence = valuesEnterByTheUser[3];
                        string energyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        PaintColor paintColor = (PaintColor)Enum.Parse(typeof(PaintColor), valuesEnterByTheUser[5], true);
                        string numberOfDoors = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float energyOrFuelToFloat = float.Parse(energyOrFuel);
                        int numberOfDoorsToInt = int.Parse(numberOfDoors);

                        Vehicle fuelCar = new FuelCar(model, licence, energyOrFuelToFloat, paintColor, numberOfDoorsToInt);
                        addedSuccessfully = garageOperation.AddVehicleToGarrage(fuelCar, firstName, phone);
                        break;
                    }

                case "FuelMotorcycle":
                    {

                        string firstName = valuesEnterByTheUser[0];
                        string phone = valuesEnterByTheUser[1];
                        string model = valuesEnterByTheUser[2];
                        string licence = valuesEnterByTheUser[3];
                        string energyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        TypeOfLicense typeOfLicense = (TypeOfLicense)Enum.Parse(typeof(TypeOfLicense), valuesEnterByTheUser[5], true);
                        string engineCapacity = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float energyOrFuelToFloat = float.Parse(energyOrFuel);
                        int engineCapacityToInt = int.Parse(engineCapacity);

                        Vehicle fuelMotorcycle = new FuelMotorcycle(model, licence, energyOrFuelToFloat, typeOfLicense, engineCapacityToInt);
                        addedSuccessfully = garageOperation.AddVehicleToGarrage(fuelMotorcycle, firstName, phone);
                        break;
                    }

                case "ElectricMotorcycle":
                    {

                        string firstName = valuesEnterByTheUser[0];
                        string phone = valuesEnterByTheUser[1];
                        string model = valuesEnterByTheUser[2];
                        string licence = valuesEnterByTheUser[3];
                        string energyOrFuel = valuesEnterByTheUser[4];
                        //Catch here Exception
                        TypeOfLicense typeOfLicense = (TypeOfLicense)Enum.Parse(typeof(TypeOfLicense), valuesEnterByTheUser[5], true);
                        string engineCapacity = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float energyOrFuelToFloat = float.Parse(energyOrFuel);
                        int engineCapacityToInt = int.Parse(engineCapacity);

                        Vehicle electricCar = new ElectricMotorcycle(model, licence, energyOrFuelToFloat, typeOfLicense, engineCapacityToInt);
                        addedSuccessfully = garageOperation.AddVehicleToGarrage(electricCar, firstName, phone);
                        break;
                    }

                case "Truck":
                    {

                        string firstName = valuesEnterByTheUser[0];
                        string phone = valuesEnterByTheUser[1];
                        string model = valuesEnterByTheUser[2];
                        string licence = valuesEnterByTheUser[3];
                        string energyOrFuel = valuesEnterByTheUser[4];

                        //Catch here Exception if yes or no
                        string dengerousLoadString = valuesEnterByTheUser[5];
                        bool dengerousLoad = false;
                        if (dengerousLoadString.ToLower().Equals("yes"))
                        {
                            dengerousLoad = true;
                        }
                        else if (dengerousLoadString.ToLower().Equals("no"))
                        {
                            dengerousLoad = false;
                        }
                        else
                        {
                            //Todo here
                        }
                        string engineCapacity = valuesEnterByTheUser[6];

                        //parse need try here of function "Format Exception"
                        float energyOrFuelToFloat = float.Parse(energyOrFuel);
                        float amountOfloadToFloat = float.Parse(engineCapacity);

                        Vehicle truck = new Truck(model, licence, energyOrFuelToFloat, dengerousLoad, amountOfloadToFloat);
                        addedSuccessfully = garageOperation.AddVehicleToGarrage(truck, firstName, phone);
                        break;
                    }
            }

            return addedSuccessfully;
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
