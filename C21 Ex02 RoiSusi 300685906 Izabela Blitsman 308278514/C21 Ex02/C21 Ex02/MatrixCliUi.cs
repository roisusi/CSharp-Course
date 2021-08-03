using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace C21_Ex02
{
    class MatrixCliUi
    {
        private int m_width = 0;
        private int m_height = 0;
        private string [,] m_maxrixBorad;
        private char [,] m_playerInput;
        private List<char> m_currentHeightGame;

        public MatrixCliUi(int width, int height)
        {
            this.m_width = width;
            this.m_height = height;
            m_maxrixBorad = new string[this.m_height, this.m_width];
            m_playerInput = new char[this.m_height, this.m_width];
            m_currentHeightGame = new List<char>(this.m_height);
        }

        public void InitiateNewGame()
        {
            for (int i = 0; i < m_playerInput.GetLength(0); i++)
            {
                for (int j = 0; j < m_playerInput.GetLength(1); j++)
                {
                    m_playerInput[i, j] = ' ';
                }
            }
        }

        public string[,] PrintGameMatrixBoard()
        {
            for (int i = 0; i < m_maxrixBorad.GetLength(0); i++)
            {
                System.Console.Write("  {0} ", i+1);
            }

            System.Console.WriteLine();

            for (int i = 0; i < m_maxrixBorad.GetLength(0); i++)
            {
                
                for (int j = 0; j < m_maxrixBorad.GetLength(1) ; j++)
                {
                    m_maxrixBorad[i, j] = "| ";
                    System.Console.Write("{0}{1} ", m_maxrixBorad[i,j] , m_playerInput[i,j]);
                }

                System.Console.WriteLine("|");

                for (int h = 0; h < m_maxrixBorad.GetLength(1); h++)
                {
                    System.Console.Write("====");
                }
                System.Console.WriteLine("=");
            }

            System.Console.WriteLine();
            return m_maxrixBorad;
        }

        public void AddCoin(int i_width, int i_height, char i_coin)
        {
            m_playerInput[i_width, i_height] = i_coin;
        }

        public char GetIndex(int i_width, int i_height)
        {
            return m_playerInput[i_width, i_height];
        }

        public List<char> GetColumnPlayerInput(int i_height)
        {
            for (int width = 0; width < m_playerInput.GetLength(0); width++)
            {
                if (!m_playerInput[width, i_height].Equals('\0'))
                {
                    m_currentHeightGame.Add(m_playerInput[width, i_height]);
                }
            }
            return m_currentHeightGame;
        }

        public char[,] GetCurrentPlayerBoardMatrix()
        {
            return m_playerInput;
        }
    }
}
