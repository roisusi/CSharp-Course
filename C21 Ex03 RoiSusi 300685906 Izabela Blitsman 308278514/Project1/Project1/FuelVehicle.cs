using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class FuelVehicle
    {
        private TypeOfFuel m_TypeOfFuel;
        private float m_CurrentAmountOfFuel = 0f;
        private float m_MaxFuelCapacity = 0f;

        public FuelVehicle(TypeOfFuel i_TypeOfFuel, float i_MaxFuelCapacity , float i_CurrentAmountOfFuel)
        {
            this.m_TypeOfFuel = i_TypeOfFuel;
            this.m_MaxFuelCapacity = i_MaxFuelCapacity;
            this.m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
        }

        public float GetCurrentAmountOfFuel()
        {
            return this.m_CurrentAmountOfFuel;
        }

        public void SetCurrentAmountOfFuel(float i_AmountOfFuel)
        {
            this.m_CurrentAmountOfFuel = i_AmountOfFuel;
        }

        public bool Refuel(float i_LiterToAdd)
        {
            if (m_CurrentAmountOfFuel + i_LiterToAdd <= m_MaxFuelCapacity)
            {
                SetCurrentAmountOfFuel(m_CurrentAmountOfFuel + i_LiterToAdd);
                return true;
            }

            return false;
        }
    }
}
