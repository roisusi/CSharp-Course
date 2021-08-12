﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GatageLogic
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

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { this.m_AirPressure = value; }
        }

        public string Manufacture
        {
            get { return m_Manufacture; }
            set { this.m_Manufacture = value; }
        }

        public float MaxAirPressureFromManufacture
        {
            get { return m_MaxAirPressureFromManufacture; }
            set { this.m_MaxAirPressureFromManufacture = value; }
        }

        public bool AddAirToWheel(float i_AmountAirToAdd)
        {
            if (m_AirPressure + i_AmountAirToAdd <= m_MaxAirPressureFromManufacture)
            {
                AirPressure = m_AirPressure + i_AmountAirToAdd;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string wheelsInformation = string.Format("Manufacture : {0}\n" +
                                                     "   Air Presure : {1}\n", m_Manufacture, m_AirPressure);
            
            return wheelsInformation;
        }

    }
}
