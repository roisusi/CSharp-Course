using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class FuelMotorcycle : Vehicle , IFuel
{
    private Fuel m_MotorcycleFuelStatus = null;
    private readonly float m_MaxFuelCapacity = 5.5f;
    private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Octan98;
    private readonly int m_NumberOfWheels = 2;
    private readonly float m_MaxAirPresure = 28f;
    private TypeOfLicense m_TypeOfLicense = 0;
    private int m_EngineCapacity = 0;

    public FuelMotorcycle()
    {
        //for Generics
    }

    public FuelMotorcycle(string i_Moudle, string i_NumberLicense, float i_Fuel, TypeOfLicense i_TypeOfLicense,int i_EngineCapacity) :
        base(i_Moudle, i_NumberLicense, i_Fuel)
    {
        m_MotorcycleFuelStatus = new Fuel(m_TypeOfFuel, m_MaxFuelCapacity, i_Fuel);
        this.m_TypeOfLicense = i_TypeOfLicense;
        this.m_EngineCapacity = i_EngineCapacity;
    }

    public int EngineCapacity
    {
        get { return this.m_EngineCapacity; }
        set { this.m_EngineCapacity = value; }
    }

    public TypeOfLicense TypeOfLicense
    {
        get { return this.m_TypeOfLicense; }
        set { this.m_TypeOfLicense = value; }
    }

    public Fuel MotorcycleFuelStatus
    {
        get { return this.m_MotorcycleFuelStatus; }
        set { this.m_MotorcycleFuelStatus = value; }
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
            "Type Of Fuel : {6}", m_Model, m_LicenseNumber, m_Energy, PrintWheels(), m_TypeOfLicense, m_EngineCapacity, m_TypeOfFuel);
        return vehicleInformation;
    }

    public void InsertWheelInformation(string i_NameOfWhellManufacture, float i_CurrentPresure)
    {
        for (int i = 0; i < m_NumberOfWheels; i++)
        {
            m_WheelsCollection.Add(new Wheels(i_NameOfWhellManufacture, i_CurrentPresure, m_MaxAirPresure));
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

    public string GetAllTypeOfLicense()
    {
        int count = 1;
        string colors = string.Empty;
        foreach (TypeOfLicense typeOfLicense in Enum.GetValues(typeof(TypeOfLicense)))
        {
            colors += string.Format("{0}. {1}\n", count, typeOfLicense);
            count++;
        }
        return colors;
    }

    public void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount)
    {
        m_Energy = m_MotorcycleFuelStatus.Refuel(i_TypeOfFuel, i_Amount);
    }
}

