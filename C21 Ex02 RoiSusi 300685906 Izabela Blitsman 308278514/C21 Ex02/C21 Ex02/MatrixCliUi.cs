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
        private string[,] m_playerInput;

        public MatrixCliUi(int width, int height)
        {
            this.m_width = width;
            this.m_height = height;
            m_maxrixBorad = new string[this.m_height, this.m_width];
            m_playerInput = new string[this.m_height, this.m_width];
        }

        public void initiateNewGame()
        {
            for (int i = 0; i < m_playerInput.GetLength(0); i++)
            {
                for (int j = 0; j < m_playerInput.GetLength(1); j++)
                {
                    m_playerInput[i, j] = " ";
                }
            }
        }

        public string[,] PrintGameMatrix()
        {
            for (int i = 0; i < m_maxrixBorad.GetLength(0); i++)
            {
                for (int j = 0; j < m_maxrixBorad.GetLength(1) ; j++)
                {
                    m_maxrixBorad[i, j] = "| ";
                    System.Console.Write("{0}{1} ", m_maxrixBorad[i, j] , m_playerInput[i,j]);
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

        public void addCoin(int width, int height, string coin)
        {
            m_playerInput[width, height] = coin;
        }
    }
}
