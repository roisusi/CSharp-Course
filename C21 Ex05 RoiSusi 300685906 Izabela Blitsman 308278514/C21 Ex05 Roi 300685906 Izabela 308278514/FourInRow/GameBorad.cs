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
        private readonly int r_Rows = 0;
        private readonly int r_Columns = 0;
        private const int c_ButtonSize = 50;
        private readonly int r_FixLocationOfXByTheSizeOfTheMatrix = 0;
        private readonly int r_FixLocationOfYByTheSizeOfTheMatrix = 0;
        private string[,] m_GameBoardInput = null;
        private string m_Player1 = string.Empty;
        private string m_Player2 = string.Empty;

        Panel m_BoradPanel = new Panel();
        Panel m_ScorePanel = new Panel();
        Button[,] m_GameBoardMatrixCoins = null;
        List<Button> m_InsertCoinButton = null;
        Label m_Player1Name = new Label();
        Label m_Player2Name = new Label();
        Label m_Player1Score = new Label();
        Label m_Player2Score = new Label();
        FourInRowLogic m_fourInRow = null;
        
        
        public GameBorad(decimal i_Rows, decimal i_Columns, string i_Player1, string i_Player2)
        {
            this.m_Player1 = i_Player1;
            this.m_Player2 = i_Player2;
            this.m_fourInRow = new FourInRowLogic(Decimal.ToInt32(i_Rows), Decimal.ToInt32(i_Columns));
            this.m_GameBoardInput = new string[Decimal.ToInt32(i_Rows), Decimal.ToInt32(i_Columns)];
            this.r_FixLocationOfXByTheSizeOfTheMatrix = r_Columns * (c_ButtonSize + 10);
            this.r_FixLocationOfYByTheSizeOfTheMatrix = r_Rows * (c_ButtonSize + 10);
            this.r_Rows = Decimal.ToInt32(i_Rows);
            this.r_Columns = Decimal.ToInt32(i_Columns);
            this.Text = "4 in a Row Game Panel";
            this.CenterToParent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(r_Columns* (c_ButtonSize+10) + 70 , r_Rows * (c_ButtonSize+10) + 125);

            m_BoradPanel.Size = new Size(r_Columns * (c_ButtonSize + 10), r_Rows * (c_ButtonSize + 10) + 40);
            m_BoradPanel.Left = 20;
            m_GameBoardMatrixCoins = new Button[r_Rows, r_Columns];
            m_InsertCoinButton = new List<Button>(r_Columns);
            CreateBoradMatrix(r_Rows, r_Columns);

            m_ScorePanel.Size = new Size(200,20);
            m_ScorePanel.Location = new Point(this.ClientSize.Width / 2 - m_ScorePanel.Size.Width / 2, this.ClientSize.Height -40);
            m_Player1Name.Text = i_Player1;
            m_Player2Name.Text = i_Player2;
            boradScore();

            m_fourInRow.SetPlayers(i_Player1, i_Player2);
            this.Controls.AddRange(new[] { m_BoradPanel, m_ScorePanel });
            this.ShowDialog();
        }

        private void cleanMatrix()
        {
            for(int i = 0; i < r_Rows; i++)
            {
                for(int j = 0; j < r_Columns; j++)
                {
                    m_GameBoardMatrixCoins[i, j].Text = "";
                }
            }

            for(int i = 0; i < r_Columns; i++)
            {
                m_InsertCoinButton[i].Enabled = true;
            }
        }

        public void UpdateMatrix()
        {
            for(int i = 0; i < r_Rows; i++)
            {
                for(int j = 0; j < r_Columns; j++)
                {
                    m_GameBoardMatrixCoins[i, j].Text = m_GameBoardInput[i, j];
                }
            }
        }

        public void ButtonAdd_Click(object sender, EventArgs e)
        {
            Button clickedButton =      (Button)sender;
            int playerIndexInput =      Array.IndexOf(m_InsertCoinButton.ToArray(), clickedButton);
            
            if(!m_Player2.Equals("[Computer]"))
            {
                m_fourInRow.PlayerVsPlayerGame(playerIndexInput);
            }
            else
            {
                m_fourInRow.PlayerVsMachineGame(playerIndexInput);
            }

            m_GameBoardInput = m_fourInRow.GetCurrentPlayerBoardMatrix();

            UpdateMatrix();

            if(m_fourInRow.IsMatrixColumnFull(playerIndexInput))
            {
                clickedButton.Enabled = false;
            }
 
            if(m_fourInRow.AnnouncePlayer())
            {
                string message = string.Format("Player {0} Won !!\nAnother round?", m_fourInRow.PlayarWonName());
                string title = string.Format("Player {0} Won!", m_fourInRow.PlayarWonName());
                this.WinnerOrTieUpadteAndAnnounce(message, title);
            }
            else if(m_fourInRow.AnnounceTie())
            {
                string message = string.Format("A Tie!\nAnother round?");
                string title = string.Format("A Tie!!");
                this.WinnerOrTieUpadteAndAnnounce(message, title);
            }
        }

        private void checkWhoWonOrTieAndUpateScore()
        {
            if(m_fourInRow.PlayarWonName().Equals(m_Player1))
            {
                m_Player1Score.Text = string.Format("{0}", m_fourInRow.PlayarScore());
            }
            else if(m_fourInRow.PlayarWonName().Equals(m_Player2))
            {
                m_Player2Score.Text = string.Format("{0}", m_fourInRow.PlayarScore());
            }
            else
            {
                int Player1Score = int.Parse(m_Player1Score.Text);
                int Player2Score = int.Parse(m_Player2Score.Text);
                Player1Score++;
                Player2Score++;
                m_Player1Score.Text = string.Format("{0}", Player1Score);
                m_Player2Score.Text = string.Format("{0}", Player2Score);
            }
        }

        public void WinnerOrTieUpadteAndAnnounce(string i_Message, string i_Title)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(i_Message, i_Title, buttons, MessageBoxIcon.Information);
            
            if(result == DialogResult.Yes)
            {
                m_fourInRow.ClearGame();
                cleanMatrix();
                checkWhoWonOrTieAndUpateScore();            
            }
            else
            {
                this.Close();
            }
        }

        public void CreateBoradMatrix(int i_Rows, int i_Columns)
        {
            for(int i = 0; i < i_Columns; i++)
            {
                m_InsertCoinButton.Add(new Button());
                m_InsertCoinButton[i].Text = string.Format("{0}", i+1);
                m_InsertCoinButton[i].Size = new Size(50, 20);
                m_InsertCoinButton[i].Location = new Point(60 * i + 10, 15);
                m_BoradPanel.Controls.Add(m_InsertCoinButton[i]);
                m_InsertCoinButton[i].Click += ButtonAdd_Click;
            }

            for(int i=0; i< i_Rows; i++)
            {
                for(int j = 0; j < i_Columns; j++)
                {                 
                    m_GameBoardMatrixCoins[i, j] = new Button();
                    m_GameBoardMatrixCoins[i, j].Size = new Size(50, 50);
                    m_GameBoardMatrixCoins[i, j].Location = new Point(60 * j + 10 , i * 60 + 50);
                    m_BoradPanel.Controls.Add(m_GameBoardMatrixCoins[i, j]);
                }
            }
        }

        private void boradScore()
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
            if(i_name.Text.Equals(string.Empty))
            {
                i_name.Text = string.Format("Player{0} : ", i_PlayerNumber);
            }
            else
            {
                i_name.Text += " : ";
            }
        }
    }
}
