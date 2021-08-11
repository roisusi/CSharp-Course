using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Project1
{
    public class Truck : Vehicle
    {
        private Fuel m_TruckFuelStatus = null;
        private readonly float m_MaxFuelCapacity = 50f;
        private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Octan95;
        private readonly int m_NumberOfWheels = 4;
        private readonly float m_MaxAirPresure = 30f;
        private bool m_IsLoadWithDangerousMaterials = false;
        private float m_AmountOfLoad = 0f;

        public Truck()
        {
            //for Generics
        }
        public Truck(string i_Moudle, string i_NumberLicense, float i_Fuel, bool i_IsLoadWithDangerousMaterials, float i_AmountOfLoad) :
            base(i_Moudle, i_NumberLicense, i_Fuel)
        {
            m_TruckFuelStatus = new Fuel(m_TypeOfFuel, m_MaxFuelCapacity, i_Fuel);
            this.m_IsLoadWithDangerousMaterials = i_IsLoadWithDangerousMaterials;
            this.m_AmountOfLoad = i_AmountOfLoad;
        }


        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License Number : {1}\n" +
                "Tank Fuel left : {2}\n" +
                "Wheels :\n" +
                "Load with dangerous cargo ? {3}\n" +
                "Cargo capacity  : {4}\n" +
                "{5}", m_Model, m_LicenseNumber, m_Energy, m_TypeOfLicense, m_EngineCapacity, m_MotorcycleFuelStatus.ToString());
            return vehicleInformation;
        }

        public override Dictionary<string, string> GetExpectation()
        {
            Dictionary<string, string> listOfProperties = new Dictionary<string, string>();
            listOfProperties.Add("1", "Name");
            listOfProperties.Add("2", "Phone Number");
            listOfProperties.Add("3", "Model");
            listOfProperties.Add("4", "Licence Number");
            listOfProperties.Add("5", "Tank Fuel left");
            listOfProperties.Add("6", "Type of Licence:\n" + GetAllTypeOfLicense());
            listOfProperties.Add("7", "Engine Capacity");
            return listOfProperties;
        }
    }
}

