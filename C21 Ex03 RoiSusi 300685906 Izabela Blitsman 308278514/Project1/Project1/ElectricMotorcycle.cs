using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricMotorcycle : Vehicle
    {
        //Todo Charging
        private readonly int m_NumberOfWheels = 2;
        private readonly float m_MaxCharghingTime = 1.6f;
        private readonly float m_MaxAirPresure = 28f;
        private TypeOfLicense m_License;
        private int m_EngineCapacity = 0;

        public ElectricMotorcycle()
        {
            //for Generics
        }
        public ElectricMotorcycle(string i_Moudle, string i_NumberLicense, float i_Energy) :
            base(i_Moudle, i_NumberLicense, i_Energy)
        {

        }

        //TODO
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        //TODO
        public override Dictionary<string, string> GetExpectation()
        {
            Dictionary<string, string> listOfProperties = new Dictionary<string, string>();
            return listOfProperties;
        }
    }
}

