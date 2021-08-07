using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class RegularMotorcycle : Motorcycle
    {
        private FuelVehicle m_MotorcycleFuelStatus;
        private readonly float m_TankLiter = 5.5f;

        public RegularMotorcycle(FuelVehicle i_CarFuelStatus)
        {
            m_MotorcycleFuelStatus = new FuelVehicle(TypeOfFuel.Octan98, m_TankLiter);
        }
    }
}
