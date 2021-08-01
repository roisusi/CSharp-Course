using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace C21_Ex02
{
    class Player
    {
        private string m_name;
        private int m_score =0;
        private char m_coin;

        public Player(string i_name,char i_coin)
        {
            this.m_name = i_name;
            this.m_coin = i_coin;
        }

        public string GetName()
        {
            return this.m_name;
        }

        public void SetName(string i_setName)
        {
            this.m_name = i_setName;
        }

        public int GetScore()
        {
            return this.m_score;
        }

        public void SetScore(int i_score)
        {
            this.m_score = i_score;
        }

        public char GetCoin()
        {
            return this.m_coin;
        }

        public void SetCoin(char i_coin)
        {
            this.m_coin = i_coin;
        }
    }
}
