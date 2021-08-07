using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class RegularCar : Car
    {
        private FuelVehicle m_CarFuelStatus;
        private readonly float m_TankLiter = 55f;

        public RegularCar(FuelVehicle i_CarFuelStatus)
        {
            m_CarFuelStatus = new FuelVehicle(TypeOfFuel.Octan95, m_TankLiter);
        }

        public bool ReFuel()
    }
}
