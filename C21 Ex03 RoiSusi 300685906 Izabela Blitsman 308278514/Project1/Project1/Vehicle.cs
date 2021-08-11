using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public abstract class Vehicle
    {
        protected string m_Model = string.Empty;
        protected string m_LicenseNumber = string.Empty;
        protected float m_Energy = 0;
        protected List<Wheels> m_WheelsCollection = null;

        public Vehicle()
        {
            // For Generics
        }

        public Vehicle(string i_Moudle, string i_LicenseNumber, float i_Energy)
        {
            this.m_Model = i_Moudle;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Energy = i_Energy;
            //this.m_WheelsCollection = new List<Wheels>(i_NumberOfWheels);
        }

        public string Model
        {
            get { return this.m_Model; }

            set { this.m_Model = value; }
        }

        public string Licence
        {
            get { return this.m_LicenseNumber; }

            set{ this.m_LicenseNumber = value; }
        }

        public float Energy
        {
            get { return this.m_Energy; }

            set { this.m_Energy = value; }
        }

        public abstract override string ToString();
 
        public void AddWheels()
        {

        }

        public abstract Dictionary<string,string> GetExpectation();


    }   
}
