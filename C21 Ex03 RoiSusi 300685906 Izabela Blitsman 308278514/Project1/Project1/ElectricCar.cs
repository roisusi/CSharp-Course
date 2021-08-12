using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GatageLogic
{
    
    public class ElectricCar : Car, ICharge
    {
        private Battery m_CarEnergyStatus = null;
        private readonly int r_NumberOfWheels = 4;
        private readonly float r_MaxChargingTime = 2.8f;
        private readonly float r_MaxAirPresure = 30f;

        public ElectricCar()
        {
            //for Generics
        }

        public ElectricCar(string i_Model, string i_NumberLicense, float i_Energy, PaintColor i_PaintColor, int i_NumberOfDoors) :
                base(i_Model, i_NumberLicense, i_Energy, i_PaintColor, i_NumberOfDoors)
        {
            if (i_Energy > r_MaxChargingTime)
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxChargingTime, 0);
            }

            m_CarEnergyStatus = new Battery(i_Energy, r_MaxChargingTime);
            m_WheelsCollection = new List<Wheels>(r_NumberOfWheels);
        }

        public Battery CarBatteryStatus
        {
            get { return this.m_CarEnergyStatus; }
        }

        public int NumberOfWheels
        {
            get { return r_NumberOfWheels; }
        }

        public float MaxChargingTime
        {
            get { return r_MaxChargingTime; }
        }

        public float MaxAirPresure
        {
            get { return r_MaxAirPresure; }
        }

        public override void SetWheels()
        {
            foreach (Wheels wheels in m_WheelsCollection)
            {
                wheels.AddAirToWheel(r_MaxAirPresure);
            }
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License number : {1}\n" +
                "Energy level : {2}\n" +
                "Wheels : \n{3}" +
                "Color : {4}\n" +
                "Number of doors : {5}\n", m_Model, m_LicenseNumber, m_Energy, PrintWheels() ,m_PaintColor,m_NumberOfDoors);
            return vehicleInformation;
        }

        public void InsertWheelInformation(string i_NameOfWhellManufacture, float i_CurrentPresure)
        {
            for (int i = 0; i < m_NumberOfWheels; i++)
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

        public override Dictionary<string, string> GetExpectation()
        {
            Dictionary<string, string> listOfProperties = new Dictionary<string, string>();
            listOfProperties.Add("1", "Name");
            listOfProperties.Add("2", "Phone number");
            listOfProperties.Add("3", "Car model");
            listOfProperties.Add("4", "Licence number");
            listOfProperties.Add("5", "Battery left");
            listOfProperties.Add("6", "Choose color:\n" + GetAllPaintColor());
            listOfProperties.Add("7", "How many doors you have:\n" + GetAllDoors());
            listOfProperties.Add("8", "Enter your current air presure of your wheels:\n");
            listOfProperties.Add("9", "Enter the name of the wheels manufacture:\n");

            return listOfProperties;
        }

        public void Recharging(float i_TimeInMinutes)
        {
            float timeInHours = i_TimeInMinutes / 60;

            CheckChargingTimeInRange(timeInHours);

            m_Energy = m_CarEnergyStatus.Recharging(timeInHours);
        }

        public void CheckChargingTimeInRange(float i_TimeCharge)
        {
            if (i_TimeCharge > r_MaxChargingTime || i_TimeCharge < 0)
            {
                throw new ValueOutOfRangeException(new Exception(), r_MaxChargingTime, 0);
            }
        }
    }
}
