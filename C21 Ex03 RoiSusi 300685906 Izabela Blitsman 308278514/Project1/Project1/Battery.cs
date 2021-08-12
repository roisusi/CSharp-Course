using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GatageLogic
{
    public class Battery
    {
        private float m_CurrentBattary= 0f;
        private float m_MaxTimeChargeInHours = 0f;

        public Battery(float i_CurrentBattary, float i_MaxTimeChargeInHours)
        {
            this.m_CurrentBattary = i_CurrentBattary;
            this.m_MaxTimeChargeInHours = i_MaxTimeChargeInHours;
        }

        public float CurrentBattary
        {
            get { return this.m_CurrentBattary; }
            set { m_CurrentBattary = value; }
        }

        public float MaxTimeChargeInHours
        {
            get { return this.m_MaxTimeChargeInHours; }
            set { m_MaxTimeChargeInHours = value; }
        }

        public bool Charging(float i_CurrentBattary, float i_MaxTimeChargeInHours)
        {
            bool canCharge = false;
            if (i_MaxTimeChargeInHours - i_CurrentBattary >= 0)
            {
                canCharge = true;
            }
            return canCharge;
        }

        public float Recharging(float i_TimeToCharge)
        {

            if (m_CurrentBattary + i_TimeToCharge <= m_MaxTimeChargeInHours)
            {
                CurrentBattary = m_CurrentBattary + i_TimeToCharge;
                return CurrentBattary;
            }

            else 
            {
                throw new ValueOutOfRangeException(new Exception(), m_MaxTimeChargeInHours, 0);
            }
        }

        public override string ToString()
        {
            string fuelInformation = string.Format("Current Car Battary : {0}\n" +
                                                   "Max Charge Time : {1}\n",
                                                   m_CurrentBattary, m_MaxTimeChargeInHours);
            return fuelInformation;
        }
    }
}
