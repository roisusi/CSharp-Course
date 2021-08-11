using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class FuelCar : Vehicle , IFuel
{
    private Fuel m_CarFuelStatus = null;
    private readonly float m_MaxFuelCapacity = 50f;
    private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Octan95;
    private readonly int m_NumberOfWheels = 4;
    private readonly float m_MaxAirPresure = 30f;
    private string m_NameOfWhellManufacture = string.Empty;
    private PaintColor m_PaintColor = 0;
    private int m_NumberOfDoors = 0;

    public FuelCar()
    {
        // for Generic
    }
    public FuelCar(string i_Moudle, string i_NumberLicense, float i_Fuel, string i_NameOfWhellManufacture, PaintColor i_PaintColor, int i_NumberOfDoors) :
        base(i_Moudle, i_NumberLicense, i_Fuel)
    {
        m_CarFuelStatus = new Fuel(m_TypeOfFuel, m_MaxFuelCapacity, i_Fuel);
        this.m_PaintColor = i_PaintColor;
        this.m_NumberOfDoors = i_NumberOfDoors;
        this.m_NameOfWhellManufacture = i_NameOfWhellManufacture;
        m_WheelsCollection = new List<Wheels>(m_NumberOfWheels);
    }

    public int NumberOfDoors
    {
        get { return this.m_NumberOfDoors; }
        set { this.m_NumberOfDoors = value; }
    }

    public PaintColor PaintColor
    {
        get { return this.m_PaintColor; }
        set { this.m_PaintColor = value; }
    }

    public Fuel CarFuelStatus
    {
        get { return this.m_CarFuelStatus; }
        set { this.m_CarFuelStatus = value; }
    }

    public override string ToString()
    {
        string vehicleInformation = string.Empty;
        vehicleInformation = string.Format(
            "Model : {0}\n" +
            "License number : {1}\n" +
            "Tank fuel left : {2}\n" +
            "Wheels {3}:\n" +
            "Color : {4}\n" +
            "Number of doors : {5}\n" +
            "Type Of Fuel : {6}", m_Model, m_LicenseNumber, m_Energy, m_PaintColor, m_NameOfWhellManufacture, m_NumberOfDoors , m_TypeOfFuel);
        return vehicleInformation;
    }

    public void InsertWheelInformation()
    {
        for (int i=0 ; i < m_NumberOfWheels ; i++)
        {
            m_WheelsCollection.Add(new Wheels(m_NameOfWhellManufacture, m_MaxAirPresure, m_MaxAirPresure));
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
        listOfProperties.Add("6", "Choose color:\n" + GetAllPaintColor());
        listOfProperties.Add("7", "How many doors you have:\n" + GetAllDoors());
        listOfProperties.Add("8", "Enter you current air presure of your wheels:\n" + GetAllDoors());
        return listOfProperties;
    }

    public string GetAllPaintColor()
    {
        int count = 1;
        string colors = string.Empty;
        foreach (PaintColor paintColor in Enum.GetValues(typeof(PaintColor)))
        {
            colors += string.Format("{0}. {1}\n", count, paintColor);
            count++;
        }
        return colors;
    }

    public string GetAllDoors()
    {
        int count = 1;
        string colors = string.Empty;
        for (int i = 2; i < 6 ; i++) 
        {
            colors += string.Format("{0}. {1} Doors\n", count, i);
            count++;
        }
        return colors;
    }

    public void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount)
    {
        m_Energy = m_CarFuelStatus.Refuel(i_TypeOfFuel, i_Amount);
    }

}

