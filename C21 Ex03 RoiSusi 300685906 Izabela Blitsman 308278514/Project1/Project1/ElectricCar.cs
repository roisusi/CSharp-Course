using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricCar : Vehicle
    {
        private PaintColor m_PaintColor = 0;
        private int m_NumberOfDoors = 0;
        private readonly int m_NumberOfWheels = 4;

        public ElectricCar(string i_Moudle, string i_NumberLicense, float i_Energy, PaintColor i_PaintColor, int i_NumberOfDoors) :
                base(i_Moudle, i_NumberLicense, i_Energy)
        {
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
            vehicleInformation = string.Format("Vehicle details:\n" +
                "Model : {0}\n" +
                "License Number : {1}\n" +
                "Energy Level : {2}\n" +
                "Wheels :\n" +
                "Color : {3}\n" +
                "Number of doors : {4}\n", m_Model, m_LicenseNumber, m_Energy, m_PaintColor,m_NumberOfDoors);
            return vehicleInformation;
        }

    }
}
