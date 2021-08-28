
namespace C21_Ex02
{
    public class Player
    {
        private string m_Name;
        private int m_Score = 0;
        private string m_Coin;
        private bool m_Turn; 

        public Player(string i_Name, string i_Coin, bool i_Turn)
        {
            this.m_Name = i_Name;
            this.m_Coin = i_Coin;
            this.m_Turn = i_Turn;
        }

        public string Name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }

        public int Score
        {
            get { return this.m_Score; }
            set { this.m_Score = value; }
        }

        public string Coin
        {
            get { return this.m_Coin; }
            set { this.m_Coin = value; }
        }

        public bool Turn
        {
            get { return this.m_Turn; }
            set { this.m_Turn = value; }
        }
    }
}
