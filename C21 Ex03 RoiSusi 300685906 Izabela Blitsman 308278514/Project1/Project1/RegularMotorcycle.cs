using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class RegularMotorcycle : Vehicle
    {
        private FuelVehicle m_MotorcycleFuelStatus;
        private readonly float m_TankLiter = 5.5f;
        private TypeOfLicense m_License;
        private int m_EngineCapacity = 0;

        public RegularMotorcycle(FuelVehicle i_CarFuelStatus)
        {
            m_MotorcycleFuelStatus = new FuelVehicle(TypeOfFuel.Octan98, m_TankLiter);
        }
    }
}
