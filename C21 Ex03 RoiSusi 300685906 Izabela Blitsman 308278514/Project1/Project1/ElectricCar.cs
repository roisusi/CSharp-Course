using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    
    public class ElectricCar : Vehicle, ICharge
    {
        Battery m_CarEnergyStatus = null;
        private readonly int m_NumberOfWheels = 4;
        private readonly float m_MaxCharghingTime = 2.8f;
        private readonly float m_MaxAirPresure = 30f;
        private PaintColor m_PaintColor = 0;
        private int m_NumberOfDoors = 0;

        public ElectricCar()
        {
            //for Generics
        }

        public ElectricCar(string i_Model, string i_NumberLicense, float i_Energy, PaintColor i_PaintColor, int i_NumberOfDoors) :
                base(i_Model, i_NumberLicense, i_Energy)
        {
            m_CarEnergyStatus = new Battery(i_Energy, m_MaxCharghingTime);
            this.m_PaintColor = i_PaintColor;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

        public int NumberOfDoors
        {
            get { return this.m_NumberOfDoors; }
            set { this.m_NumberOfDoors = value; }
        }

        public PaintColor PaintColor
        {
            get { return this.m_PaintColor; }
            set { this.m_PaintColor = value; }
        }

        public int NumberOfWheels
        {
            get { return this.m_NumberOfWheels; }
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License number : {1}\n" +
                "Energy level : {2}\n" +
                "Wheels : {3}\n" +
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

        public string GetAllPaintColor()
        {
            int count = 1;
            string colors = string.Empty;
            foreach (PaintColor paintColor in Enum.GetValues(typeof(PaintColor)))
            {
                colors += string.Format("{0}. {1}\n", count, paintColor);
                count++;
            }
            return colors;
        }

        public string GetAllDoors()
        {
            int count = 1;
            string colors = string.Empty;
            for (int i = 2; i < 6; i++)
            {
                colors += string.Format("{0}. {1} Doors\n", count, i);
                count++;
            }
            return colors;
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
