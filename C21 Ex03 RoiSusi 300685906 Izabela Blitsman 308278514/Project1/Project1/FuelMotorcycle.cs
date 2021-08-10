using System;
using System.Collections.Generic;
using System.Text;
using Project1;

public class FuelMotorcycle : Vehicle
{
    private Fuel m_MotorcycleFuelStatus;
    private readonly float m_TankLiter = 5.5f;
    private TypeOfLicense m_License;
    private int m_EngineCapacity = 0;
    public FuelMotorcycle(string i_Moudle, string i_NumberLicense, float i_Energy) :
        base(i_Moudle, i_NumberLicense, i_Energy
        )
    {

    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}

