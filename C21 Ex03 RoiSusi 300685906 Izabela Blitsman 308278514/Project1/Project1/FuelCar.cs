using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class FuelCar : Vehicle
{
    private Fuel m_CarFuelStatus = null;
    private readonly float m_MaxFuelCapacity = 50f;
    private readonly TypeOfFuel m_TypeOfFuel = TypeOfFuel.Octan95;
    private PaintColor m_PaintColor = 0;
    private int m_NumberOfDoors = 0;

    public FuelCar(string i_Moudle, string i_NumberLicense, float i_Fuel, PaintColor i_PaintColor, int i_NumberOfDoors) :
        base(i_Moudle, i_NumberLicense, i_Fuel)
    {
        m_CarFuelStatus = new Fuel(m_TypeOfFuel, m_MaxFuelCapacity, i_Fuel);
        this.m_PaintColor = i_PaintColor;
        this.m_NumberOfDoors = i_NumberOfDoors;
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
        vehicleInformation = string.Format("Vehicle details:\n" +
            "Model : {0}\n" +
            "License Number : {1}\n" +
            "Fuel in Tank : {2}\n" +
            "Wheels :\n" +
            "Color : {3}\n" +
            "Number of doors : {4}\n" +
            "{5}", m_Model, m_LicenseNumber, m_Energy, m_PaintColor, m_NumberOfDoors, m_CarFuelStatus.ToString());
        return vehicleInformation;
    }
}

