namespace Project1
{
    public class GarageVehicleInformation
    {
        private string m_OwnerName = string.Empty;
        private string m_OwnerPhone = string.Empty;
        private GarageStatus m_GarageStatus = GarageStatus.InRepair;
        private Vehicle m_Vehicle = null;

        public GarageVehicleInformation(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            this.m_Vehicle = i_Vehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }

            set { this.m_OwnerName = value; }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
            set { this.m_OwnerPhone = value; }
        }

        public GarageStatus GarageStatus
        {
            get { return m_GarageStatus; }
            set { this.m_GarageStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public override string ToString()
        {
            string CustomerDetailsInGarrage = string.Empty;
            CustomerDetailsInGarrage = string.Format("Here is the vehicle details in the garage : \n" +
                "Name : {0}\n" +
                "Phone : {1}\n" +
                "{2}" +
                "Status : {3}\n", m_OwnerName, m_OwnerPhone, m_Vehicle.ToString(), m_GarageStatus);

            return CustomerDetailsInGarrage;
        }
    }
}

