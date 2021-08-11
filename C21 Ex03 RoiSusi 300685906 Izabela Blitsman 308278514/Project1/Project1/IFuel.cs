using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public interface IFuel
    {
        void Refuel(TypeOfFuel i_TypeOfFuel, float i_Amount);
    }
}
