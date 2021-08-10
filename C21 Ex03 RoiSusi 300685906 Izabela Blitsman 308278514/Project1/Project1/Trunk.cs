using System;
using System.Collections.Generic;
using System.Text;
using Project1;

namespace Project1
{
    public class Trunk : Vehicle
    {
        private bool IsLoadWithDangerousMaterials = false;
        private float AmountOfLoad = 0f;

        public Trunk(string i_Moudle, string i_NumberLicense, float i_Energy) :
            base(i_Moudle, i_NumberLicense, i_Energy)
        {

        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}

