using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Fuel
    {
        private TypeOfFuel m_TypeOfFuel = 0;
        private float m_CurrentAmountOfFuel = 0f;
        private float m_MaxFuelCapacity = 0f;

        public Fuel(TypeOfFuel i_TypeOfFuel, float i_MaxFuelCapacity , float i_CurrentAmountOfFuel)
        {
            this.m_TypeOfFuel = i_TypeOfFuel;
            this.m_MaxFuelCapacity = i_MaxFuelCapacity;
            this.m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
        }

        public float CurrentAmountOfFuel
        {
            get { return this.m_CurrentAmountOfFuel; }
            set { m_CurrentAmountOfFuel = value; }
        }

        public TypeOfFuel TypeOfFuel
        {
            get { return this.m_TypeOfFuel; }
            set { m_TypeOfFuel = value; }
        }

        public float MaxFuelCapacity
        {
            get { return this.m_MaxFuelCapacity; }
            set { m_MaxFuelCapacity = value; }
        }

        public float Refuel(TypeOfFuel i_TypeOfFuel , float i_LiterToAdd)
        {
            if (m_CurrentAmountOfFuel + i_LiterToAdd <= m_MaxFuelCapacity)
            {
                CurrentAmountOfFuel = m_CurrentAmountOfFuel + i_LiterToAdd;
                return CurrentAmountOfFuel;
            }

            else 
            {
                throw new ValueOutOfRangeException(new Exception(), 0, MaxFuelCapacity);
            }
        }
    }
}
