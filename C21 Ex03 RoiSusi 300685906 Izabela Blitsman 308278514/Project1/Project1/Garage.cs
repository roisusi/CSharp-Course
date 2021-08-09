using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Garage
    {
        private List<GarageVehicleInformation> m_CurrentVehicelIn = new List<GarageVehicleInformation>();

        public void AddVehicleToGarrage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            GarageVehicleInformation i_AddInformation = new GarageVehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone);

            m_CurrentVehicelIn.Add(i_AddInformation);
        }

        public string Print()
        {
            string printInformaiton = string.Empty;
            foreach (GarageVehicleInformation info in m_CurrentVehicelIn)
            {
                printInformaiton += string.Format(info.ToString());
            }
            return printInformaiton;
        }

        public string PrintByLicense(string i_Licence)
        {
            string printInformaiton = string.Empty;
            foreach (GarageVehicleInformation info in m_CurrentVehicelIn)
            {
                if (i_Licence.Equals(i_Licence))
                {
                    printInformaiton = string.Format("{0}", info.OwnerName);
                }
                else
                {
                    printInformaiton = string.Format("Not Found");

                }
            }
            return printInformaiton;
        }

    }
}

