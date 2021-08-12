using System;
using System.Collections.Generic;
using System.Text;


namespace Ex03GatageLogic {
    public class Garage
    {
        private CreateVehicles m_createVehicles = new CreateVehicles();
        private List<GarageVehicleInformation> m_CurrentVehicelIn = new List<GarageVehicleInformation>();

        public bool AddVehicleToGarrage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            bool vehicleExsists = false;
            GarageVehicleInformation i_AddInformation = new GarageVehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone);

            foreach(GarageVehicleInformation vehicles in m_CurrentVehicelIn)
            {
                if (i_Vehicle.Licence.Equals(vehicles.Vehicle.Licence))
                {
                    vehicleExsists = true;
                    vehicles.GarageStatus = GarageStatus.InRepair;
                    break;
                }
            }

            if (vehicleExsists == false)
            {
                m_CurrentVehicelIn.Add(i_AddInformation);
            }
            return vehicleExsists;
        }

        public bool Refuel(string i_licence , string i_TypeOfFuel , string i_Amount)
        {

            bool isRefuelSuccessfully = false;
            TypeOfFuel typeOfFuel = (TypeOfFuel)Enum.Parse(typeof(TypeOfFuel), i_TypeOfFuel, true);
            float amount = float.Parse(i_Amount);

            foreach (GarageVehicleInformation vehicles in m_CurrentVehicelIn)
            {
                //Check is a fuel vehicle
                if (i_licence.Equals(vehicles.Vehicle.Licence))
                {
                    if (vehicles.Vehicle is IFuel)
                    { 
                        IFuel fuelACar = (IFuel)vehicles.Vehicle;
                        fuelACar.Refuel(typeOfFuel, amount);
                        isRefuelSuccessfully = true;
                    }
                    else
                    {
                        isRefuelSuccessfully = false;
                    }
                    break;
                }

            }
            return isRefuelSuccessfully;
        }

        public bool Recharge(string i_licence, float i_TimeToChargeInMin)
        {
            bool isChargeSuccessfully = false;

            foreach (GarageVehicleInformation vehicles in m_CurrentVehicelIn)
            {
                //Check is a fuel vehicle
                if (i_licence.Equals(vehicles.Vehicle.Licence))
                {
                    if (vehicles.Vehicle is ICharge)
                    {
                        ICharge chargeVehicle = (ICharge)vehicles.Vehicle;
                        chargeVehicle.Recharging(i_TimeToChargeInMin);
                        isChargeSuccessfully = true;
                    }
                    else
                    {
                        isChargeSuccessfully = false;
                    }
                    break;
                }
            }

            return isChargeSuccessfully;
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

        public bool ChangeVehicleStatus(string i_GarageStatus , string i_Licence)
        {
            bool succesfullyChangeStatus = false;
            //Add Exception Argumant
            GarageStatus garageStatus = (GarageStatus)Enum.Parse(typeof(GarageStatus), i_GarageStatus, true);

            foreach (GarageVehicleInformation info in m_CurrentVehicelIn)
            {
                if (info.Vehicle.Licence.Equals(i_Licence))
                {
                    info.GarageStatus = garageStatus;
                    succesfullyChangeStatus = true;
                }
            }
            return succesfullyChangeStatus;
        }

        public bool InflateWheel(string i_Licence)
        {
            bool succesfullyChangeStatus = false;

            foreach (GarageVehicleInformation info in m_CurrentVehicelIn)
            {
                if (info.Vehicle.Licence.Equals(i_Licence))
                {
                    info.Vehicle.SetWheels();
                    succesfullyChangeStatus = true;
                }
            }

            return succesfullyChangeStatus;
        }

        public Dictionary<string, GarageStatus> ListOfCarsByLicence()
        {
            Dictionary<string, GarageStatus> listOfLicence = new Dictionary<string, GarageStatus>();
            foreach (GarageVehicleInformation vehicles in m_CurrentVehicelIn)
            {
                if (!vehicles.Vehicle.Licence.Equals(listOfLicence.Keys))
                {
                    listOfLicence.Add(vehicles.Vehicle.Licence, vehicles.GarageStatus);
                }
            }

            return listOfLicence;
        }

        public bool AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser, Garage garage)
        {
            return m_createVehicles.AddVehicle(typeOfVehicle, valuesEnterByTheUser, garage);
        }

        public Dictionary<int,string> ListOfAllVehicles()
        {
            return m_createVehicles.ListOfAllVehicles();
        }

        public Dictionary<string, string> GetListOfValues(string type)
        {
            return m_createVehicles.GetListOfValues(type);
        }

        public string GetAllFuelTypes()
        {
            int count = 1;
            string types = string.Empty;
            foreach (TypeOfFuel typeOfFuel in Enum.GetValues(typeof(TypeOfFuel)))
            {
                types += string.Format("{0}. {1}\n", count, typeOfFuel);
                count++;
            }
            return types;
        }

        public int ParseNumberOfDoorsToInt(string i_NumberOfDoors)
        {
            int numberOfDoors = 0;

            if (!int.TryParse(i_NumberOfDoors, out numberOfDoors))
            {
                throw new FormatException("Error in adding vehicle - charging or fuel should be float value");
            }

            return numberOfDoors;
        }

        public void TryParseStringToFloat(string i_StringUserInput)
        {
            float floatUserInput = 0f;

            if (!float.TryParse(i_StringUserInput, out floatUserInput))
            {
                throw new FormatException("Error in parsing user input - should be float value");
            }
        }

        public void TryParseStringToInt(string i_StringUserInput)
        {
            int intUserInput = 0;

            if (!int.TryParse(i_StringUserInput, out intUserInput))
            {
                throw new FormatException("Error in parsing user input - should be integer value");
            }
		}
		
        public string GetAllGarageStatus()
        {
            int count = 1;
            string types = string.Empty;
            foreach (GarageStatus garageStatus in Enum.GetValues(typeof(GarageStatus)))
            {
                types += string.Format("{0}. {1}\n", count, garageStatus);
                count++;
            }
            return types;
        }
    }
}

