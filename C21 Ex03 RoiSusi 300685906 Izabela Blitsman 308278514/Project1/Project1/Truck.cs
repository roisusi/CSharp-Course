using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Project1
{
    public class Truck : Vehicle
    {
        private Fuel m_TruckFuelStatus = null;
        private readonly float m_MaxFuelCapacity = 50f;
        private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Octan95;
        private readonly int m_NumberOfWheels = 4;
        private readonly float m_MaxAirPresure = 30f;
        private bool m_IsLoadWithDangerousMaterials = false;
        private float m_AmountOfLoad = 0f;

        public Truck()
        {
            //for Generics
        }
        public Truck(string i_Moudle, string i_NumberLicense, float i_Fuel, bool i_IsLoadWithDangerousMaterials, float i_AmountOfLoad) :
            base(i_Moudle, i_NumberLicense, i_Fuel)
        {
            m_TruckFuelStatus = new Fuel(m_TypeOfFuel, m_MaxFuelCapacity, i_Fuel);
            this.m_IsLoadWithDangerousMaterials = i_IsLoadWithDangerousMaterials;
            this.m_AmountOfLoad = i_AmountOfLoad;
        }


        //TODO
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        //TODO
        public override Dictionary<string, string> GetExpectation()
        {
            Dictionary<string, string> listOfProperties = new Dictionary<string, string>();

            return listOfProperties;
        }
    }
}

