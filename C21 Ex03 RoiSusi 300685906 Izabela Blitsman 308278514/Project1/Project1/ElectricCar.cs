using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    
    public class ElectricCar : Car, ICharge
    {
        private Battery m_CarEnergyStatus = null;
        private readonly int m_NumberOfWheels = 4;
        private readonly float m_MaxCharghingTime = 2.8f;
        private readonly float m_MaxAirPresure = 30f;

        public ElectricCar()
        {
            //for Generics
        }

        public ElectricCar(string i_Model, string i_NumberLicense, float i_Energy, PaintColor i_PaintColor, int i_NumberOfDoors) :
                base(i_Model, i_NumberLicense, i_Energy, i_PaintColor, i_NumberOfDoors)
        {
            m_CarEnergyStatus = new Battery(i_Energy, m_MaxCharghingTime);
            m_WheelsCollection = new List<Wheels>(m_NumberOfWheels);
        }

        public Battery CarBatteryStatus
        {
            get { return this.m_CarEnergyStatus; }
        }

        public override void SetWheels()
        {
            foreach (Wheels wheels in m_WheelsCollection)
            {
                wheels.AddAirToWheel(m_MaxAirPresure);
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
                m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, m_MaxAirPresure));
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
            if (i_TimeCharge > m_MaxCharghingTime || i_TimeCharge < 0)
            {
                throw new ValueOutOfRangeException(new Exception(), 0, m_MaxCharghingTime);
            }
        }
    }
}
