using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace C21_Ex02
{
    public class Player
    {
        private string m_Name;
        private int m_Score = 0;
        private char m_Coin;
        private bool m_Machine;
        private bool m_Turn; 

        public Player(string i_Name, char i_Coin, bool i_Machine, bool i_Turn)
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

        public void SetName(string i_setName)
        {
            this.m_Name = i_setName;
        }

        public int GetScore()
        {
            return this.m_Score;
        }

        public void SetScore(int i_score)
        {
            this.m_Score = i_score;
        }

        public char GetCoin()
        {
            return this.m_Coin;
        }

        public void SetCoin(char i_Coin)
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
