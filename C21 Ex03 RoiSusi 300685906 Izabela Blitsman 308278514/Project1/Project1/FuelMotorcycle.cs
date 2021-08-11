using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class FuelMotorcycle : Vehicle
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

    public override string ToString()
    {
        string vehicleInformation = string.Empty;
        vehicleInformation = string.Format("Vehicle details:\n" +
            "Model : {0}\n" +
            "License Number : {1}\n" +
            "Tank Fuel left : {2}\n" +
            "Wheels :\n" +
            "Type of Licence : {3}\n" +
            "Engine Capacity  : {4}\n" +
            "{5}", m_Model, m_LicenseNumber, m_Energy, m_TypeOfLicense, m_EngineCapacity, m_MotorcycleFuelStatus.ToString());
        return vehicleInformation;
    }


    public override Dictionary<string, string> GetExpectation()
    {
        Dictionary<string, string> listOfProperties = new Dictionary<string, string>();
        listOfProperties.Add("1", "Name");
        listOfProperties.Add("2", "Phone Number");
        listOfProperties.Add("3", "Model");
        listOfProperties.Add("4", "Licence Number");
        listOfProperties.Add("5", "Tank Fuel left");
        listOfProperties.Add("6", "Type of Licence:\n" + GetAllTypeOfLicense());
        listOfProperties.Add("7", "Engine Capacity");
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
}

