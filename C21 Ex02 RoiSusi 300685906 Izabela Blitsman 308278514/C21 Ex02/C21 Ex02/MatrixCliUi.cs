using System.Collections.Generic;

namespace C21_Ex02
{
    class MatrixCliUi
    {
        private int m_Width = 0;
        private int m_Height = 0;
        private char [,] m_PlayerInput;
        private List<char> m_CurrentHeightGame;

        public MatrixCliUi(int i_Width, int i_Height)
        {
            this.m_Width = i_Width;
            this.m_Height = i_Height;
            m_PlayerInput = new char[this.m_Width, this.m_Height];
            m_CurrentHeightGame = new List<char>(this.m_Height);
        }

        public void PrintGameMatrixBoard()
        {
            for (int i = 0; i < m_PlayerInput.GetLength(1); i++)
            {
                System.Console.Write("  {0} ", i+1);
            }

            System.Console.WriteLine();

            for (int i = 0; i < m_PlayerInput.GetLength(0); i++)
            {
                
                for (int j = 0; j < m_PlayerInput.GetLength(1) ; j++)
                {
                    System.Console.Write("| {0} ", m_PlayerInput[i,j]);
                }

                System.Console.WriteLine("|");

                for (int h = 0; h < m_PlayerInput.GetLength(1); h++)
                {
                    System.Console.Write("====");
                }
                System.Console.WriteLine("=");
            }

            System.Console.WriteLine();

        }

        public void AddCoin(int i_Width, int i_Height, char i_Coin)
        {
            m_PlayerInput[i_Width, i_Height] = i_Coin;
        }

        public char GetIndex(int i_Width, int i_Height)
        {
            return m_PlayerInput[i_Width, i_Height];
        }

        public List<char> GetColumnPlayerInput(int i_Height)
        {
            m_CurrentHeightGame.Clear();

            for (int width = 0; width < m_PlayerInput.GetLength(0); width++)
            {
                if (!m_PlayerInput[width, i_Height].Equals('\0'))
                {
                    m_CurrentHeightGame.Add(m_PlayerInput[width, i_Height]);
                }
            }
            return m_CurrentHeightGame;
        }

        public char[,] GetCurrentPlayerBoardMatrix()
        {
            return m_PlayerInput;
        }

        public void ClearGame()
        {
            m_PlayerInput = new char[m_Width, m_Height];
        }
    }
}
