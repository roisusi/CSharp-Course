using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace C21_Ex02
{
    class MatrixCliUi
    {
        private int m_Width = 0;
        private int m_Height = 0;
        private string [,] m_MatrixBorad;
        private string [,] m_PlayerInput;
        private List<string> m_CurrentHeightGame;

        public MatrixCliUi(int i_Width, int i_Height)
        {
            this.m_Width = i_Width;
            this.m_Height = i_Height;
            m_MatrixBorad = new string[this.m_Height, this.m_Width];
            m_PlayerInput = new string[this.m_Height, this.m_Width];
            m_CurrentHeightGame = new List<string>(this.m_Height);
        }

        public void InitiateNewGame()
        {
            for (int i = 0; i < m_PlayerInput.GetLength(0); i++)
            {
                for (int j = 0; j < m_PlayerInput.GetLength(1); j++)
                {
                    m_PlayerInput[i, j] = " ";
                }
            }
        }

        public string[,] PrintGameMatrixBoard()
        {
            for (int i = 0; i < m_MatrixBorad.GetLength(0); i++)
            {
                for (int j = 0; j < m_MatrixBorad.GetLength(1) ; j++)
                {
                    m_MatrixBorad[i, j] = "| ";
                    System.Console.Write("{0}{1} ", m_MatrixBorad[i,j] , m_PlayerInput[i,j]);
                }

                System.Console.WriteLine("|");

                for (int h = 0; h < m_MatrixBorad.GetLength(1); h++)
                {
                    System.Console.Write("====");
                }
                System.Console.WriteLine("=");
            }

            System.Console.WriteLine();
            return m_MatrixBorad;
        }

        public void AddCoin(int i_width, int i_height, string i_coin)
        {
            m_PlayerInput[i_width, i_height] = i_coin;
        }

        public string GetIndex(int i_width, int i_height)
        {
            return m_PlayerInput[i_width, i_height];
        }

        public List<string> GetColumnPlayerInput(int i_height)
        {
            for (int width = 0; width < m_PlayerInput.GetLength(0); width++)
            {
                m_CurrentHeightGame.Add(m_PlayerInput[width, i_height]);
            }
            return m_CurrentHeightGame;
        }
    }
}
