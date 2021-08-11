using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricMotorcycle : Vehicle, ICharge
    {
        Battery m_MotorcycleEnergyStatus = null;
        private readonly int m_NumberOfWheels = 2;
        private readonly float m_MaxCharghingTime = 1.6f;
        private readonly float m_MaxAirPresure = 28f;
        private TypeOfLicense m_TypeOfLicense = 0;
        private int m_EngineCapacity = 0;

        public ElectricMotorcycle()
        {
            //for Generics
        }
        public ElectricMotorcycle(string i_Moudle, string i_NumberLicense, float i_Energy, TypeOfLicense i_TypeOfLicense, int i_EngineCapacity) :
            base(i_Moudle, i_NumberLicense, i_Energy)
        {
            m_MotorcycleEnergyStatus = new Battery(i_Energy,m_MaxCharghingTime);
            this.m_TypeOfLicense = i_TypeOfLicense;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License number : {1}\n" +
                "Battary left : {2}\n" +
                "Wheels :\n" +
                "Type of licence : {3}\n" +
                "Engine capacity  : {4}\n" +
                "{5}", m_Model, m_LicenseNumber, m_Energy, m_TypeOfLicense, m_EngineCapacity, m_MotorcycleEnergyStatus.ToString());
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

        public string GetAllTypeOfLicense()
        {
            int count = 1;
            string colors = string.Empty;
            foreach (TypeOfLicense typeOfLicense in Enum.GetValues(typeof(TypeOfLicense)))
            {
                colors += string.Format("{0}. {1}\n", count, typeOfLicense);
                count++;
            }
            return colors;
        }

        public void Recharging(float i_TimeInMinutes)
        {
            m_Energy = m_MotorcycleEnergyStatus.Recharging(i_TimeInMinutes);
        }
    }
}

