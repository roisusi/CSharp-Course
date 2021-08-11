﻿using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Project1
{
    public class Truck : Vehicle, IFuel
    {
        private Fuel m_TruckFuelStatus = null;
        private readonly float m_MaxFuelCapacity = 110f;
        private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Soler;
        private readonly int m_NumberOfWheels = 16;
        private readonly float m_MaxAirPresure = 26f;
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

        public bool LoadWithDangerousMaterials
        {
            get { return this.m_IsLoadWithDangerousMaterials; }
            set { this.m_IsLoadWithDangerousMaterials = value; }
        }

        public float AmountOfLoad
        {
            get { return this.m_AmountOfLoad; }
            set { this.m_AmountOfLoad = value; }
        }

        public Fuel TruckFuelStatus
        {
            get { return this.m_TruckFuelStatus; }
        }

        public override string ToString()
        {
            string vehicleInformation = string.Empty;
            vehicleInformation = string.Format(
                "Model : {0}\n" +
                "License number : {1}\n" +
                "Tank fuel left : {2}\n" +
                "Wheels : {3}\n" +
                "Load with dangerous cargo ? {4}\n" +
                "Cargo capacity : {5}\n" +
                "Type Of Fuel: { 6}\n", m_Model, m_LicenseNumber, m_Energy, PrintWheels(), ChageLoadWithDangerousMaterialsToString() , m_AmountOfLoad, m_TypeOfFuel);
            return vehicleInformation;
        }

        public override Dictionary<string, string> GetExpectation()
        {
            Dictionary<string, string> listOfProperties = new Dictionary<string, string>();
            listOfProperties.Add("1", "Name");
            listOfProperties.Add("2", "Phone number");
            listOfProperties.Add("3", "Model");
            listOfProperties.Add("4", "Licence number");
            listOfProperties.Add("5", "Tank fuel left");
            listOfProperties.Add("6", "Is cargo load with dangerous matirials ? (Yes/No):\n");
            listOfProperties.Add("7", "Cargo capacity");
            listOfProperties.Add("8", "Enter your current air presure of your wheels:\n");
            listOfProperties.Add("9", "Enter the name of the wheels manufacture:\n");
            return listOfProperties;
        }

        public void InsertWheelInformation(string i_NameOfWhellManufacture, float i_CurrentPresure)
        {
            for (int i = 0; i < m_NumberOfWheels; i++)
            {
                m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, m_MaxAirPresure));
            }
        }

        public string ChageLoadWithDangerousMaterialsToString()
        {
            string yesOrNo = string.Empty;
            if (m_IsLoadWithDangerousMaterials == true)
            {
                yesOrNo = "Yes";
            }
            else
            {
                yesOrNo = "No";
            }

            return yesOrNo;
        }

        public void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount)
        {
            CheckFuelType(i_TypeOfFuel);

            CheckFuelAmountInRange(i_Amount);

            m_Energy = m_TruckFuelStatus.Refuel(i_TypeOfFuel, i_Amount);
        }

        public void CheckFuelType(TypeOfFuel i_TypeOfFuel)
        {
            if (i_TypeOfFuel != m_TypeOfFuel)
            {
                throw new ArgumentException("Invalid fuel type for car - should be Octan95");
            }
        }

        public void CheckFuelAmountInRange(float i_Amount)
        {
            if (i_Amount > m_MaxFuelCapacity || i_Amount < 0)
            {
                throw new ValueOutOfRangeException(new Exception(), 0, m_MaxFuelCapacity);
            }
        }
    }
}

