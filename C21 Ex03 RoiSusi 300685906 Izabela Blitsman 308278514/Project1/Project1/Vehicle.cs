using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Vehicle
    {
        protected string m_Model = string.Empty;
        protected string m_LicenseNumber = string.Empty;
        protected float m_Energy = 0;
        protected Wheels[] m_WheelsCollection = null;

        public Vehicle(string i_Moudle, string i_LicenseNumber, float i_Energy, int i_NumberOfWheels)
        {
            this.m_Model = i_Moudle;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Energy = i_Energy;
            this.m_WheelsCollection = new Wheels[i_NumberOfWheels];
        }

        public string GetLicence()
        {
            return this.m_LicenseNumber;
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format("Vehicle details:\n" +
                "Model : {0}\n" +
                "License Number : {1}\n" +
                "Energy Level : {2}\n" +
                "Wheels :\n", m_Model, m_LicenseNumber, m_Energy);
            return vehicleInformation;
        }

        public void AddWheels()
        {

        }


        public void printWheells<T>(List<T> i_List)
        {
            foreach (T items in i_List)
            {
                System.Console.WriteLine(i_List.ToString());
            }
        }

    }   
}
