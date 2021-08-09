using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElectricCar : Vehicle
    {
        private PaintColor m_PaintColor;
        private int m_NumberOfDoors;

        public ElectricCar(string i_Moudle, string i_NumberLicense, float i_Energy, int i_NumberOfWheels) :
                base(i_Moudle, i_NumberLicense, i_Energy, i_NumberOfWheels)
        {

        }

        public override string ToString()
        {

            return base.ToString();

        }

    }
}
