using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class Garage : Vehicle
    {
        private string m_OwnerName = string.Empty;
        private string m_m_OwnerPhone = string.Empty;
        private GarageStatus m_GarageStatus = GarageStatus.InRepair;
    }
}
