using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public abstract class Motorcycler : Vehicle
    {
        protected TypeOfLicense m_TypeOfLicense = 0;
        protected int m_EngineCapacity = 0;

        public Motorcycler()
        {
            //for Generics
        }

        public Motorcycler(string i_Model, string i_NumberLicense, float i_Fuel , TypeOfLicense i_TypeOfLicense, int i_EngineCapacity) : 
            base(i_Model, i_NumberLicense, i_Fuel)
        {
            this.m_TypeOfLicense = i_TypeOfLicense;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public int EngineCapacity
        {
            get { return this.m_EngineCapacity; }
            set { this.m_EngineCapacity = value; }
        }

        public TypeOfLicense TypeOfLicense
        {
            get { return this.m_TypeOfLicense; }
            set { this.m_TypeOfLicense = value; }
        }

        public abstract override Dictionary<string, string> GetExpectation();

        public abstract override void SetWheels();

        public abstract override string ToString();

        protected string GetAllTypeOfLicense()
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
    }
}
