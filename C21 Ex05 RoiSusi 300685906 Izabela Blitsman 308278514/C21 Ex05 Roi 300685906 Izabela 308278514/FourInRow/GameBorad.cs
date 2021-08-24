using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using C21_Ex02;

namespace FourInRow
{
    public class GameBorad : Form
    {
        private readonly int m_Rows = 0;
        private readonly int m_Columns = 0;
        private const int k_ButtonSize = 50;
        private readonly int r_FixLocationOfXByTheSizeOfTheMatrix = 0;
        private readonly int r_FixLocationOfYByTheSizeOfTheMatrix = 0;
        private string[,] m_PlayerInput = null;
        private List<string> m_CurrentHeightGame = null;

        Panel m_BoradPanel = new Panel();
        Panel m_ScorePanel = new Panel();
        Button[,] m_GameBoardMatrixCoins = null;
        List<Button> m_InsertCoinButton = null;
        Label m_Player1Name = new Label();
        Label m_Player2Name = new Label();
        Label m_Player1Score = new Label();
        Label m_Player2Score = new Label();
        FourInRowLogic m_fourInRow = new FourInRowLogic();
        
        
        public GameBorad(decimal i_Rows, decimal i_Columns , string i_Player1 , string i_Player2)
        {
            m_PlayerInput = new string[Decimal.ToInt32(i_Rows), Decimal.ToInt32(i_Columns)];
            m_CurrentHeightGame = new List<string>(Decimal.ToInt32(i_Columns));
            this.r_FixLocationOfXByTheSizeOfTheMatrix = m_Columns * (k_ButtonSize + 10);
            this.r_FixLocationOfYByTheSizeOfTheMatrix = m_Rows * (k_ButtonSize + 10);
            this.m_Rows = Decimal.ToInt32(i_Rows);
            this.m_Columns = Decimal.ToInt32(i_Columns);
            this.Text = "4 in a Row Game Panel";
            this.CenterToParent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(m_Columns* (k_ButtonSize+10) + 70 , m_Rows * (k_ButtonSize+10) + 125);

            m_BoradPanel.Size = new Size(m_Columns * (k_ButtonSize + 10), m_Rows * (k_ButtonSize + 10) + 40);
            m_BoradPanel.Left = 20;
            m_GameBoardMatrixCoins = new Button[m_Rows, m_Columns];
            m_InsertCoinButton = new List<Button>(m_Columns);
            CreateBoradMatrix(m_Rows, m_Columns);

            m_ScorePanel.Size = new Size(200,20);
            m_ScorePanel.Location = new Point(this.ClientSize.Width / 2 - m_ScorePanel.Size.Width / 2, this.ClientSize.Height -40);
            m_Player1Name.Text = i_Player1;
            m_Player2Name.Text = i_Player2;
            BoradScore();

            
            this.Controls.AddRange(new[] { m_BoradPanel, m_ScorePanel });
            this.ShowDialog();
        }

        public void ButtonAdd_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = Array.IndexOf(m_InsertCoinButton.ToArray(), clickedButton);

            clickedButton.Text = "...button clicked...";
        }

        public void CreateBoradMatrix(int i_Rows, int i_Columns)
        {

            for (int i = 0; i < i_Columns; i++)
            {
                m_InsertCoinButton.Add(new Button());
                m_InsertCoinButton[i].Text = string.Format("{0}", i+1);
                m_InsertCoinButton[i].Size = new Size(50, 20);
                m_InsertCoinButton[i].Location = new Point(60 * i + 10, 15);
                m_BoradPanel.Controls.Add(m_InsertCoinButton[i]);
                m_InsertCoinButton[i].Click += ButtonAdd_Click;
            }

            for (int i=0; i< i_Rows; i++)
            {
                for (int j = 0; j < i_Columns; j++)
                {                 
                    m_GameBoardMatrixCoins[i, j] = new Button();
                    m_GameBoardMatrixCoins[i, j].Size = new Size(50, 50);
                    m_GameBoardMatrixCoins[i, j].Location = new Point(60 * j + 10 , i * 60 + 50);
                    m_BoradPanel.Controls.Add(m_GameBoardMatrixCoins[i, j]);
                }
            }
        }

        private void BoradScore()
        {

            SetPlayerNames(m_Player1Name,1);
            SetPlayerNames(m_Player2Name,2);

            m_Player1Name.AutoSize = true;
            m_Player1Name.Location = new Point(0, 0);

            m_Player2Name.AutoSize = true;
            m_Player2Name.Location = new Point(m_Player1Name.Location.X+100, m_Player1Name.Location.Y);

            m_Player1Score.Text = "0";
            m_Player1Score.AutoSize = true;
            m_Player1Score.Location = new Point(m_Player1Name.Location.X + m_Player1Name.PreferredSize.Width, m_Player1Name.Location.Y);

            m_Player2Score.Text = "0";
            m_Player2Score.AutoSize = true;
            m_Player2Score.Location = new Point(m_Player2Name.Location.X + m_Player2Name.PreferredSize.Width, m_Player2Name.Location.Y);
            
            m_ScorePanel.Controls.Add(m_Player1Name);
            m_ScorePanel.Controls.Add(m_Player2Name);
            m_ScorePanel.Controls.Add(m_Player1Score);
            m_ScorePanel.Controls.Add(m_Player2Score);
        }

        public void SetPlayerNames(Label i_name,int i_PlayerNumber)
        {
            if (i_name.Text.Equals(string.Empty))
            {
                i_name.Text = string.Format("Player{0} : ", i_PlayerNumber);
            }
            else
            {
                i_name.Text += " : ";
            }
        }

        public void AddCoin(int i_Width, int i_Height, string i_Coin)
        {
            m_PlayerInput[i_Width, i_Height] = i_Coin;
            m_GameBoardMatrixCoins[i_Width, i_Height].Text = i_Coin;
            
        }

        public string GetIndex(int i_Width, int i_Height)
        {
            return m_PlayerInput[i_Width, i_Height];
        }

        public List<string> GetColumnPlayerInput(int i_Height)
        {
            m_CurrentHeightGame.Clear();

            for (int width = 0; width < m_PlayerInput.GetLength(0); width++)
            {
                if (!m_PlayerInput[width, i_Height].Equals(""))
                {
                    m_CurrentHeightGame.Add(m_PlayerInput[m_Rows, i_Height]);
                }
            }
            return m_CurrentHeightGame;
        }

        public string[,] GetCurrentPlayerBoardMatrix()
        {
            return m_PlayerInput;
        }

        public void ClearGame()
        {
            m_PlayerInput = new string[m_Rows, m_Columns];
        }

    }
}
