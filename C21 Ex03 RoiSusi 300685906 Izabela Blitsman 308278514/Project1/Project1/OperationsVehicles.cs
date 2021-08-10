using System;
using System.Collections.Generic;
using System.Text;



namespace Project1
{
    public class OperationsVehicles
    {
        Garage garageOperation = new Garage();


        public void AddElectircCar(string i_Model , string i_Licence , string i_EnergyOrFuel, string i_firstName, string i_Phone,PaintColor i_PaintColor,string i_NumberOfDoors)
        {
            //parse need try here of function "Format Exception"
            float EnergyOrFuel = float.Parse(i_EnergyOrFuel);
            int NumberOfDoors = int.Parse(i_NumberOfDoors);

            Vehicle electricCar = new ElectricCar(i_Model, i_Licence, EnergyOrFuel, i_PaintColor , NumberOfDoors);
            garageOperation.AddVehicleToGarrage(electricCar , i_firstName, i_Phone);


        }

        public void AddFuelCar(string i_Model, string i_Licence, string i_EnergyOrFuel, string i_firstName, string i_Phone, PaintColor i_PaintColor, string i_NumberOfDoors)
        {
            //parse need try here of function "Format Exception"
            float EnergyOrFuel = float.Parse(i_EnergyOrFuel);
            int NumberOfDoors = int.Parse(i_NumberOfDoors);

            Vehicle fuelCar = new FuelCar(i_Model, i_Licence, EnergyOrFuel, i_PaintColor, NumberOfDoors);
            garageOperation.AddVehicleToGarrage(fuelCar, i_firstName, i_Phone);

        }

        public string PrintCarInformation(string Licence)
        {
            return garageOperation.PrintCarByLicense(Licence);
        }

        public Dictionary<int, string> ListOfAllVehicles()
        {
            return garageOperation.ListOfAllVehicles();
        }


    }
}
