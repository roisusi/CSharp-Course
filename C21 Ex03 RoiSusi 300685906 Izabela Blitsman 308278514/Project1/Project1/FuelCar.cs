﻿using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class RegularCar : Vehicle
{
    private FuelVehicle m_CarFuelStatus = null;
    private readonly float m_TankLiter = 55f;
    private PaintColor m_PaintColor;
    private int m_NumberOfDoors;
    private float m_CurrentFuel = 0f;
    public RegularCar(string i_Moudle, string i_NumberLicense, float i_Energy, int i_NumberOfWheels) :
        base(i_Moudle, i_NumberLicense, i_Energy, i_NumberOfWheels)
    {

    }


    //public RegularCar(FuelVehicle i_CarFuelStatus , float i_CurrentFuel)
    //{
    //    m_CarFuelStatus = new FuelVehicle(TypeOfFuel.Octan95, m_TankLiter , i_CurrentFuel);
    //    m_CurrentFuel = i_CurrentFuel;
    //}

    //public bool ReFuel()
    //{
    //    return m_CarFuelStatus.Refuel(m_CurrentFuel);
    //}
}

