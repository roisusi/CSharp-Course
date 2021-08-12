using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GatageLogic
{
    public interface IFuel
    {
        void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount);
    }
}
