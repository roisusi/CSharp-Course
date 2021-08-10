using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricMotorcycle : Vehicle
    {
        private TypeOfLicense m_License;
        private int m_EngineCapacity = 0;

        public ElectricMotorcycle(string i_Moudle, string i_NumberLicense, float i_Energy) :
            base(i_Moudle, i_NumberLicense, i_Energy)
        {

        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}

