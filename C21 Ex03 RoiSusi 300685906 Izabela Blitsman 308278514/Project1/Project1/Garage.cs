﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Garage
    {
        private CreateVehicles createVehicles = new CreateVehicles();
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

        public void ArrangeByStatus(GarageStatus i_GarageStatus)
        {

        }

        public bool AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser, Garage garage)
        {
            return createVehicles.AddVehicle(typeOfVehicle, valuesEnterByTheUser, garage);
        }

        public Dictionary<int,string> ListOfAllVehicles()
        {
            return createVehicles.ListOfAllVehicles();
        }

        public Dictionary<string, string> GetListOfValues(string type)
        {
            return createVehicles.GetListOfValues(type);
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

        private int ParseNumberOfDoorsToInt(string i_NumberOfDoors)
        {
            int numberOfDoors = 0;

            if (!int.TryParse(i_NumberOfDoors, out numberOfDoors))
            {
                throw new FormatException("Error in adding vehicle - charging or fuel should be float value");
            }

            return numberOfDoors;
        }

        private void TryParseStringToFloat(string i_StringUserInput)
        {
            float floatUserInput = 0f;

            if (!float.TryParse(i_StringUserInput, out floatUserInput))
            {
                throw new FormatException("Error in parsing user input - should be float value");
            }
        }

        private void TryParseStringToInt(string i_StringUserInput)
        {
            int intUserInput = 0;

            if (!int.TryParse(i_StringUserInput, out intUserInput))
            {
                throw new FormatException("Error in parsing user input - should be integer value");
            }
        }
    }
}

