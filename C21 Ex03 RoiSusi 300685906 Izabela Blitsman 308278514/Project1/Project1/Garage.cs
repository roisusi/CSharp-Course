using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Garage
    {
        private List<GarageVehicleInformation> m_CurrentVehicelIn = new List<GarageVehicleInformation>();
        private Dictionary<int, string> listOfAllVehicles = new Dictionary<int, string>();
        

        public void AddVehicleToGarrage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            GarageVehicleInformation i_AddInformation = new GarageVehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone);

            m_CurrentVehicelIn.Add(i_AddInformation);
        }

        public Dictionary<int,string> ListOfAllVehicles()
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

        public string PrintCarByLicense(string i_Licence)
        {
            string printInformaiton = string.Empty;
            foreach (GarageVehicleInformation info in m_CurrentVehicelIn)
            {
                if (info.Vehicle.Licence.Equals(i_Licence))
                {
                    printInformaiton = string.Format(info.ToString());
                }
            }

            return printInformaiton;
        }

        public void ArrangeByStatus(GarageStatus i_GarageStatus)
        {

        }

        public Dictionary<string, string> GetListOfValues(string type)
        {
            Dictionary<string, string> listOfValues = new Dictionary<string,string>();

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

        public void AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser)
        {
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
                        AddVehicleToGarrage(electricCar, i_firstName, i_Phone);
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
                        AddVehicleToGarrage(electricCar, i_firstName, i_Phone);
                        break;
                    }
            }


        }

    }
}

