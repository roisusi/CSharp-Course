using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class FuelCar : Car , IFuel
{
    private Fuel m_CarFuelStatus = null;
    private readonly float m_MaxFuelCapacity = 50f;
    private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Octan95;
    private readonly int m_NumberOfWheels = 4;
    private readonly float m_MaxAirPresure = 30f;

    public FuelCar()
    {
        // for Generic
    }
    public FuelCar(string i_Moudle, string i_NumberLicense, float i_Fuel, PaintColor i_PaintColor, int i_NumberOfDoors) :
        base(i_PaintColor, i_NumberOfDoors)
    {
        m_CarFuelStatus = new Fuel(m_TypeOfFuel, m_MaxFuelCapacity, i_Fuel);
        m_WheelsCollection = new List<Wheels>(m_NumberOfWheels);
    }

    public override void SetWheels()
    {
        foreach (Wheels wheels in m_WheelsCollection)
        {
            wheels.AddAirToWheel(m_MaxAirPresure);
        }
    }

    public Fuel CarFuelStatus
    {
        get { return this.m_CarFuelStatus; }
    }

    public override string ToString()
    {
        string vehicleInformation = string.Empty;
        vehicleInformation = string.Format(
            "Model : {0}\n" +
            "License number : {1}\n" +
            "Tank fuel left : {2}\n" +
            "Wheels : \n{3}" +
            "Color : {4}\n" +
            "Number of doors : {5}\n" +
            "Type Of Fuel : {6}\n", m_Model, m_LicenseNumber, m_Energy, PrintWheels(), m_PaintColor, m_NumberOfDoors , m_TypeOfFuel);
        return vehicleInformation;
    }

    public void InsertWheelInformation(string i_NameOfWhellManufacture , float i_CurrentPresure)
    {
        for (int i=0 ; i < m_NumberOfWheels ; i++)
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
        listOfProperties.Add("6", "Choose color:\n" + GetAllPaintColor());
        listOfProperties.Add("7", "How many doors you have:\n" + GetAllDoors());
        listOfProperties.Add("8", "Enter your current air presure of your wheels:\n");
        listOfProperties.Add("9", "Enter the name of the wheels manufacture:\n");

        return listOfProperties;
    }

    public void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount)
    {
        CheckFuelType(i_TypeOfFuel);

        CheckFuelAmountInRange(i_Amount);

        m_Energy = m_CarFuelStatus.Refuel(i_TypeOfFuel, i_Amount);
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

