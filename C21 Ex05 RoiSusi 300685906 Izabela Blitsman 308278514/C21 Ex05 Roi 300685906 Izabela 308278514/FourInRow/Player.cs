
namespace C21_Ex02
{
    public class Player
    {
        private string m_Name;
        private int m_Score = 0;
        private string m_Coin;
        private bool m_Machine;
        private bool m_Turn; 

        public Player(string i_Name, string i_Coin, bool i_Machine, bool i_Turn)
        {
            this.m_Name = i_Name;
            this.m_Coin = i_Coin;
            this.m_Machine = i_Machine;
            this.m_Turn = i_Turn;
        }

        public string GetName()
        {
            return this.m_Name;
        }

        public void SetName(string i_SetName)
        {
            this.m_Name = i_SetName;
        }

        public int GetScore()
        {
            return this.m_Score;
        }

        public void SetScore(int i_Score)
        {
            this.m_Score = i_Score;
        }

        public string GetCoin()
        {
            return this.m_Coin;
        }

        public void SetCoin(string i_Coin)
        {
            this.m_Coin = i_Coin;
        }

        public bool GetMachine()
        {
            return this.m_Machine;
        }

        public void SetMachine(bool i_Machine)
        {
            this.m_Machine = i_Machine;
        }

        public bool GetTurn()
        {
            return this.m_Turn;
        }

        public void SetTurn(bool i_Turn)
        {
            this.m_Turn = i_Turn;
        }
    }
}
