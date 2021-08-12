using System;
using System.Collections.Generic;
using System.Text;
using Ex03GatageLogic;

public class FuelMotorcycle : Motorcycler , IFuel
{
    private Fuel m_MotorcycleFuelStatus = null;
    private readonly float r_MaxFuelCapacity = 5.5f;
    private readonly TypeOfFuel r_TypeOfFuel = TypeOfFuel.Octan98;
    private readonly int r_NumberOfWheels = 2;
    private readonly float r_MaxAirPresure = 28f;

    public FuelMotorcycle()
    {
        //for Generics
    }

    public FuelMotorcycle(string i_Model, string i_NumberLicense, float i_Fuel, TypeOfLicense i_TypeOfLicense,int i_EngineCapacity) :
        base(i_Model, i_NumberLicense, i_Fuel, i_TypeOfLicense, i_EngineCapacity)
    {
        m_MotorcycleFuelStatus = new Fuel(r_TypeOfFuel, r_MaxFuelCapacity, i_Fuel);
        m_WheelsCollection = new List<Wheels>(r_NumberOfWheels);
    }

    public float MaxFuelCapacity
    {
        get { return r_MaxFuelCapacity; }
    }

    public TypeOfFuel TypeOfFuel
    {
        get { return r_TypeOfFuel; }
    }

    public int NumberOfWheels
    {
        get { return r_NumberOfWheels; }
    }

    public float MaxAirPresure
    {
        get { return r_MaxAirPresure; }
    }

    public Fuel MotorcycleFuelStatus
    {
        get { return this.m_MotorcycleFuelStatus; }
    }

    public override void SetWheels()
    {
        foreach (Wheels wheels in m_WheelsCollection)
        {
            wheels.AirPressure = r_MaxAirPresure;
        }
    }

    public override string ToString()
    {
        string vehicleInformation = string.Empty;
        vehicleInformation = string.Format(
            "Model : {0}\n" +
            "License number : {1}\n" +
            "Tank fuel left : {2}\n" +
            "Wheels : \n{3}" +
            "Type of licence : {4}\n" +
            "Engine capacity  : {5}\n" +
            "Type Of Fuel : {6}", m_Model, m_LicenseNumber, m_Energy, PrintWheels(), m_TypeOfLicense, m_EngineCapacity, r_TypeOfFuel);
        return vehicleInformation;
    }

    public void InsertWheelInformation(string i_NameOfWhellManufacture, float i_CurrentPresure)
    {
        for (int i = 0; i < r_NumberOfWheels; i++)
        {
            m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, r_MaxAirPresure));

            if (i_CurrentPresure <= r_MaxAirPresure && i_CurrentPresure >= 0)
            {
                m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, r_MaxAirPresure));
            }

            else
            {
                throw new ValueOutOfRangeException(new Exception(), 0, r_MaxAirPresure);
            }
        }
    }

    public override Dictionary<string, string> GetExpectation()
    {
        Dictionary<string, string> listOfProperties = new Dictionary<string, string>();
        listOfProperties.Add("1", "Name");
        listOfProperties.Add("2", "Phone number");
        listOfProperties.Add("3", "Model");
        listOfProperties.Add("4", "Licence number");
        listOfProperties.Add("5", "Tank fuel left");
        listOfProperties.Add("6", "Type of licence:\n" + GetAllTypeOfLicense());
        listOfProperties.Add("7", "Engine capacity");
        listOfProperties.Add("8", "Enter your current air presure of your wheels:\n");
        listOfProperties.Add("9", "Enter the name of the wheels manufacture:\n");
        return listOfProperties;
    }

    public void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount)
    {
        CheckFuelType(i_TypeOfFuel);

        CheckFuelAmountInRange(i_Amount);

        m_Energy = m_MotorcycleFuelStatus.Refuel(i_TypeOfFuel, i_Amount);
    }

    public void CheckFuelType(TypeOfFuel i_TypeOfFuel)
    {
        if (i_TypeOfFuel != r_TypeOfFuel)
        {
            throw new ArgumentException("Invalid fuel type for car - should be Octan95");
        }
    }

    public void CheckFuelAmountInRange(float i_Amount)
    {
        if (i_Amount > r_MaxFuelCapacity || i_Amount < 0)
        {
            throw new ValueOutOfRangeException(new Exception(), 0, r_MaxFuelCapacity);
        }
    }
}

