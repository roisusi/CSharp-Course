using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Wheels
    {
        private string m_Manufacture = string.Empty;
        private float m_AirPressure = 0f;
        private float m_MaxAirPressureFromManufacture = 0f;

        public Wheels(string i_Manufacture, float i_AirPressure, float i_MaxAirPressureFromManufacture)
        {
            this.m_Manufacture = i_Manufacture;
            this.m_AirPressure = i_AirPressure;
            this.m_MaxAirPressureFromManufacture = i_MaxAirPressureFromManufacture;
        }

        public float GetAirPressure()
        {
            return m_AirPressure;
        }

        public void SetAirPressure(float i_AirPressure)
        {
            this.m_AirPressure = i_AirPressure;
        }

        public bool AddAirToWheel(float i_AmountAirToAdd)
        {
            if (m_AirPressure + i_AmountAirToAdd <= m_MaxAirPressureFromManufacture)
            {
                SetAirPressure(m_AirPressure + i_AmountAirToAdd);
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            string wheelsInformation = string.Format("Air Presure : {0}\n" +
                                                     "Manufacture : {1}" , m_AirPressure, m_Manufacture);

            return wheelsInformation;
        }


    }
}
