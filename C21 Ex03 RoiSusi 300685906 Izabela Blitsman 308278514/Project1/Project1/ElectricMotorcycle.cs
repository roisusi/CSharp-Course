using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GatageLogic
{
    public class ElectricMotorcycle : Motorcycler, ICharge
    {
        private Battery m_MotorcycleEnergyStatus = null;
        private readonly int r_NumberOfWheels = 2;
        private readonly float r_MaxCharghingTime = 1.6f;
        private readonly float r_MaxAirPresure = 28f;

        public ElectricMotorcycle()
        {
            //for Generics
        }

        public ElectricMotorcycle(string i_Model, string i_NumberLicense, float i_Energy, TypeOfLicense i_TypeOfLicense, int i_EngineCapacity) :
            base(i_Model, i_NumberLicense, i_Energy, i_TypeOfLicense, i_EngineCapacity)
        {
            if (i_Energy > r_MaxCharghingTime || i_Energy < 0)
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxCharghingTime, 0);
            }

            m_MotorcycleEnergyStatus = new Battery(i_Energy,r_MaxCharghingTime);
            m_WheelsCollection = new List<Wheels>(r_NumberOfWheels);
        }

        public Battery MotorcycleBatteryStatus
        {
            get { return this.m_MotorcycleEnergyStatus; }
        }

        public int NumberOfWheels
        {
            get { return r_NumberOfWheels; }
        }

        public float MaxCharghingTime
        {
            get { return r_MaxCharghingTime; }
        }

        public float MaxAirPresure
        {
            get { return r_MaxAirPresure; }
        }

        public override void SetWheels()
        {
            foreach (Wheels wheels in m_WheelsCollection)
            {
                wheels.AirPressure = r_MaxAirPresure;
            }
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License number : {1}\n" +
                "Battary left : {2}\n" +
                "Wheels : \n{3}" +
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
            for (int i = 0; i < r_NumberOfWheels; i++)
            {
                
                if (i_CurrentPresure <= r_MaxAirPresure && i_CurrentPresure >= 0)
                {
                    m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, r_MaxAirPresure));
                }

                else
                {
                    throw new ValueOutOfRangeException(new Exception(), r_MaxAirPresure, 0);
                }
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
            if (i_TimeCharge > r_MaxCharghingTime || i_TimeCharge < 0)
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxCharghingTime, 0);
            }
        }
    }
}

