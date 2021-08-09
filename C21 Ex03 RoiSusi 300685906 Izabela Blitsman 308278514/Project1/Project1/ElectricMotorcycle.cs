using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricMotorcycle : Vehicle
    {
        private TypeOfLicense m_License;
        private int m_EngineCapacity = 0;

        public ElectricMotorcycle(string i_Moudle, string i_NumberLicense, float i_Energy, int i_NumberOfWheels) :
            base(i_Moudle, i_NumberLicense, i_Energy, i_NumberOfWheels)
        {

        }
    }
}

