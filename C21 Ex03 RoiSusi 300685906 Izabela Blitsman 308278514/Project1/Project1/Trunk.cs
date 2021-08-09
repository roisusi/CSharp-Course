namespace Project1
{
    public class Trunk : Vehicle
    {
        private bool IsLoadWithDangerousMaterials = false;
        private float AmountOfLoad = 0f;

        public Trunk(string i_Moudle, string i_NumberLicense, float i_Energy, int i_NumberOfWheels) :
            base(i_Moudle, i_NumberLicense, i_Energy, i_NumberOfWheels)
        {

        }
    }
}

