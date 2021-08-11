using System;
using System.Collections.Generic;
using System.Text;


namespace Project1 {
    public class Garage
    {
        private CreateVehicles createVehicles = new CreateVehicles();
        private List<GarageVehicleInformation> m_CurrentVehicelIn = new List<GarageVehicleInformation>();

        public bool AddVehicleToGarrage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            bool vehicleExsists = false;
            GarageVehicleInformation i_AddInformation = new GarageVehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone);

            foreach(GarageVehicleInformation vehicles in m_CurrentVehicelIn)
            {
                if (i_Vehicle.Licence.Equals(vehicles.Vehicle.Licence))
                {
                    vehicleExsists = true;
                    vehicles.GarageStatus = GarageStatus.InRepair;
                }
            }

            if (vehicleExsists == false)
            {
                m_CurrentVehicelIn.Add(i_AddInformation);
            }

            return vehicleExsists;

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

        public bool AddVehicle(string typeOfVehicle, List<string> valuesEnterByTheUser, Garage garage)
        {
            return createVehicles.AddVehicle(typeOfVehicle, valuesEnterByTheUser, garage);
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

