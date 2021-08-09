using System;
using System.Collections.Generic;
using System.Text;



namespace Project1
{
    public class OperationsVehicles
    {
        public void AddVehicle(string typeOfCar)
        {
            switch (typeOfCar)
            {
                case "1":
                    {
                        Vehicle vehicle = new ElectricCar("roi", "3333", 4, 5);
                        break;
                    }
            }
        }
    }
}
