using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricMotorcycle : Motorcycler, ICharge
    {
        private Battery m_MotorcycleEnergyStatus = null;
        private readonly int m_NumberOfWheels = 2;
        private readonly float m_MaxCharghingTime = 1.6f;
        private readonly float m_MaxAirPresure = 28f;

        public ElectricMotorcycle()
        {
            //for Generics
        }

        public ElectricMotorcycle(string i_Moudle, string i_NumberLicense, float i_Energy, TypeOfLicense i_TypeOfLicense, int i_EngineCapacity) :
            base(i_TypeOfLicense, i_EngineCapacity)
        {
            m_MotorcycleEnergyStatus = new Battery(i_Energy,m_MaxCharghingTime);
            m_WheelsCollection = new List<Wheels>(m_NumberOfWheels);
        }

        public Battery MotorcycleBatteryStatus
        {
            get { return this.m_MotorcycleEnergyStatus; }
        }

        public override void SetWheels()
        {
            foreach (Wheels wheels in m_WheelsCollection)
            {
                wheels.AirPressure = m_MaxAirPresure;
            }
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License number : {1}\n" +
                "Battary left : {2}\n" +
                "Wheels : {3}\n" +
                "Type of licence : {4}\n" +
                "Engine capacity  : {5}\n", m_Model, m_LicenseNumber, m_Energy, PrintWheels(), m_TypeOfLicense, m_EngineCapacity );
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
            listOfProperties.Add("8", "Enter your current air presure of your wheels:\n");
            listOfProperties.Add("9", "Enter the name of the wheels manufacture:\n");
            return listOfProperties;
        }

        public void InsertWheelInformation(string i_NameOfWhellManufacture, float i_CurrentPresure)
        {
            for (int i = 0; i < m_NumberOfWheels; i++)
            {
                m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, m_MaxAirPresure));
            }
        }

        public void Recharging(float i_TimeInMinutes)
        {
            float timeInHours = i_TimeInMinutes / 60;

            CheckChargingTimeInRange(timeInHours);

            m_Energy = m_MotorcycleEnergyStatus.Recharging(timeInHours);
        }

        public void CheckChargingTimeInRange(float i_TimeCharge)
        {
            if (i_TimeCharge > m_MaxCharghingTime || i_TimeCharge < 0)
            {
                throw new ValueOutOfRangeException(new Exception(), 0, m_MaxCharghingTime);
            }
        }
    }
}

