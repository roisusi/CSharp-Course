using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Garage
    {
        private CreateVehicles createVehicles = new CreateVehicles();
        private List<GarageVehicleInformation> m_CurrentVehicelIn = new List<GarageVehicleInformation>();

        public void AddVehicleToGarrage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            GarageVehicleInformation i_AddInformation = new GarageVehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone);


            m_CurrentVehicelIn.Add(i_AddInformation);
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

        public void AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser, Garage garage)
        {
            createVehicles.AddVehicle(typeOfVehicle, valuesEnterByTheUser, garage);
        }

        public Dictionary<int,string> ListOfAllVehicles()
        {
            return createVehicles.ListOfAllVehicles();
        }

        public Dictionary<string, string> GetListOfValues(string type)
        {
            return createVehicles.GetListOfValues(type);
        }

    }
}

