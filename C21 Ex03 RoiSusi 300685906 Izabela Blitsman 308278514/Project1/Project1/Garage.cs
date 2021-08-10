using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Garage
    {
        private List<GarageVehicleInformation> m_CurrentVehicelIn = new List<GarageVehicleInformation>();
        private Dictionary<int, string> listOfAllVehicles = new Dictionary<int, string>();

        public void AddVehicleToGarrage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            GarageVehicleInformation i_AddInformation = new GarageVehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone);

            m_CurrentVehicelIn.Add(i_AddInformation);
        }

        public Dictionary<int,string> ListOfAllVehicles()
        {
            int i = 1;
            foreach (Type type in typeof(Vehicle).Assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Vehicle)))
                {
                    listOfAllVehicles.Add(i, type.Name);
                    //System.Console.WriteLine(listOfAllVehicles.ToString());
                    //System.Console.WriteLine(i  + ". " + type.Name.ToString());
                    i++;

                }
            }
            return listOfAllVehicles;
        }

        public string PrintCarByLicense(string i_Licence)
        {
            string printInformaiton = string.Empty;
            foreach (GarageVehicleInformation info in m_CurrentVehicelIn)
            {
                if (info.Vehicle.Licence.Equals(i_Licence))
                {
                    printInformaiton = string.Format(info.ToString());
                }
            }

            

            return printInformaiton;
        }

        public void ArrangeByStatus(GarageStatus i_GarageStatus)
        {

        }

    }
}

