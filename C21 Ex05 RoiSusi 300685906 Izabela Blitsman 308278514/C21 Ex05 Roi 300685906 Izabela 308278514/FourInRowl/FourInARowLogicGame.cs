using System.Collections.Generic;

namespace FourInRowLogic
{
    public class FourInARowLogicGame
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private List<Player> m_PlayersList = new List<Player>();
        private List<string> m_CurrentHeightGame = null;
        private MachineAI m_MachineAI = new MachineAI();
        private readonly string r_CoinOne = "X";
        private readonly string r_CoinTwo = "O";
        private string m_PlayerWonName = string.Empty;
        private string[,] m_PlayerInput = null;
        private bool m_IsPlayerWin = false;
        private bool m_IsATie = false;
        private int m_Score = 0;
        private int m_MachineLastHight = -1;
        private int m_MachineLastWidth = -1;
        private int width = 0;
        private int height = 0;
        private int m_Rows = 0;
        private int m_Columns = 0;
        private System.Random m_Random = new System.Random();


        public              FourInARowLogicGame(int i_Rows, int i_Columns)
        {
            m_Rows = i_Rows;
            m_Columns = i_Columns;
            m_PlayerInput = new string[i_Rows, i_Columns];
            m_CurrentHeightGame = new List<string>(i_Columns);
            CreateEmptyMatrix();
        }

        public void         SetPlayers(string i_Player1Name, string i_Player2Name)
        {
            m_FirstPlayer = new Player(i_Player1Name, r_CoinOne, true);
            m_SecondPlayer = new Player(i_Player2Name, r_CoinTwo, false);
            m_PlayersList.Add(m_FirstPlayer);
            m_PlayersList.Add(m_SecondPlayer);
        }

        public void         PlayerVsMachineGame(int i_ButtonIndex)
        {
            m_IsATie = false;
            foreach (Player currentPlayer in m_PlayersList)
            {
                if (m_PlayersList[1].Equals(currentPlayer))
                {
                    width = m_Rows - this.GetColumnPlayerInput(i_ButtonIndex).Count;
                    if (m_MachineLastHight != -1 && m_MachineAI.TryToWinMove(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight) != -1)
                    {
                        height = m_MachineAI.TryToWinMove(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight);
                    }
                    else if (m_MachineAI.TryNotToLoseeUp(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex) != -1)
                    {
                        height = m_MachineAI.TryNotToLoseeUp(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex);
                    }
                    else if (m_MachineAI.TryNotToLoseeLeft(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex) != -1)
                    {
                        height = m_MachineAI.TryNotToLoseeLeft(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex);
                    }
                    else if (m_MachineAI.TryNotToLoseeRigth(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex) != -1)
                    {
                        height = m_MachineAI.TryNotToLoseeRigth(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex);
                    }
                    else if (m_MachineLastHight != -1 && m_MachineAI.FindFreeCellSequenceOfTwoLeft(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight) != -1)
                    {
                        height = m_MachineAI.FindFreeCellSequenceOfTwoLeft(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight);
                    }
                    else if (m_MachineLastHight != -1 && m_MachineAI.FindFreeCellSequenceOfTwoRight(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight) != -1)
                    {
                        height = m_MachineAI.FindFreeCellSequenceOfTwoRight(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight);
                    }
                    else if (m_MachineLastHight != -1 && m_MachineAI.FindFreeCellSequenceOfTwoUp(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight) != -1)
                    {
                        height = m_MachineAI.FindFreeCellSequenceOfTwoUp(this.GetCurrentPlayerBoardMatrix(), m_MachineLastWidth, m_MachineLastHight);
                    }
                    else if (m_MachineAI.IfCanMoveLeftRightUp(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex) &&
                        !m_MachineAI.FindSeuenceOfThreeUp(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex) &&
                        !m_MachineAI.FindSeuenceOfThreeLeft(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex) &&
                        !m_MachineAI.FindSeuenceOfThreeRight(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex))
                    {
                        height = m_MachineAI.MoveLeftOrRightOrUp(this.GetCurrentPlayerBoardMatrix(), width, i_ButtonIndex);
                    }
                    else
                    {
                        do
                        {
                            height = m_Random.Next(0, m_Columns);
                        } while (IsMatrixColumnFull(height));
                    }

                    m_MachineLastHight = height;
                    m_MachineLastWidth = m_Rows - this.GetColumnPlayerInput(height).Count - 1;
                    playerTurn(currentPlayer, m_MachineLastHight);
                }
                else
                {
                    playerTurn(currentPlayer, i_ButtonIndex);
                }

                CheckIfPlayerWon(currentPlayer);

                if (IsMatrixFull() && !m_IsPlayerWin)
                {
                    m_IsATie = true;
                    m_SecondPlayer.Score++;
                    m_FirstPlayer.Score++;
                    m_PlayerWonName = string.Empty;
                }
            }
        }

        public int          MachineCurrentIndexInput
        {
            get { return m_MachineLastHight; }
        }

        public void         PlayerVsPlayerGame(int i_ButtonIndex)
        {
            Player      currentPlayer = getCurrentPlayer();

            m_IsATie = false;
            playerTurn(currentPlayer, i_ButtonIndex);
            CheckIfPlayerWon(currentPlayer);

            if (IsMatrixFull() && !m_IsPlayerWin)
            {
                m_IsATie = true;
                m_SecondPlayer.Score++;
                m_FirstPlayer.Score++;
                m_PlayerWonName = string.Empty;
            }
        }

        private Player      getCurrentPlayer()
        {
            Player      currentPlayer = null;

            if (m_PlayersList[0].Turn)
            {
                currentPlayer = m_PlayersList[0];
                m_PlayersList[1].Turn = true;
            }
            else
            {
                currentPlayer = m_PlayersList[1];
                m_PlayersList[0].Turn = true;
            }

            currentPlayer.Turn = false;
            return currentPlayer;
        }

        private void        playerTurn(Player i_CurrentPlayer, int i_Column)
        {
            int     row = 0;

            row = m_Rows - this.GetColumnPlayerInput(i_Column).Count - 1;
            this.AddCoin(row, i_Column, i_CurrentPlayer.Coin);
        }

        public bool         AnnounceTie()
        {
            return m_IsATie;
        }

        public bool         AnnouncePlayer()
        {
            return m_IsPlayerWin;
        }

        public string       PlayarWonName()
        {
            return m_PlayerWonName;
        }

        public int          PlayarScore()
        {
            return m_Score;
        }

        public bool         CheckIfPlayerWon(Player io_CurrentPlayer)
        {
            int     score = 0;

            if (CheckIfPlayerWin(io_CurrentPlayer.Coin))
            {
                score = io_CurrentPlayer.Score;
                io_CurrentPlayer.Score = ++score;
                m_IsPlayerWin = true;
                m_Score = score;
                m_PlayerWonName = io_CurrentPlayer.Name;
                m_FirstPlayer.Turn = true;
                m_SecondPlayer.Turn = false;
            }

            return m_IsPlayerWin;
        }

        public bool         IsMatrixColumnFull(int i_MatrixColumn)
        {
            bool            isColumnFull = false;
            List<string>    matrixColumn = this.GetColumnPlayerInput(i_MatrixColumn);

            if (matrixColumn.Count >= m_Rows)
            {
                isColumnFull = true;
            }

            return isColumnFull;
        }

        public bool         IsMatrixFull()
        {
            bool        isMatrixFull = true;
            string[,]   matrixBoard = GetCurrentPlayerBoardMatrix();
   
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    if (matrixBoard[i, j].Equals(""))
                    {
                        isMatrixFull = false;
                    }
                }
            }

            return isMatrixFull;
        }

        public bool         CheckIfPlayerWin(string i_PlayerCoin)
        {
            bool isPlayerWin = false;

            if (IsHorizontalSequence(i_PlayerCoin) ||
                IsVerticalSequence(i_PlayerCoin) ||
                IsDownwardDiagonalSequence(i_PlayerCoin) ||
                IsUpwardDiagonalSequence(i_PlayerCoin))
            {
                isPlayerWin = true;
            }

            return isPlayerWin;
        }

        public bool         IsHorizontalSequence(string i_PlayerCoin)
        {
            bool        isHorizontalSequence = false;
            string[,]   matrixBoard = GetCurrentPlayerBoardMatrix();

            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j <= m_Columns - 4; j++)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i, j + 1].Equals(i_PlayerCoin) &&
                        matrixBoard[i, j + 2].Equals(i_PlayerCoin) &&
                        matrixBoard[i, j + 3].Equals(i_PlayerCoin))
                    {
                        isHorizontalSequence = true;
                    }
                }
            }

            return isHorizontalSequence;
        }

        public bool         IsVerticalSequence(string i_PlayerCoin)
        {
            bool        isVerticalSequence = false;
            string[,]   matrixBoard = GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_Rows - 4; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 1, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 2, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 3, j].Equals(i_PlayerCoin))
                    {
                        isVerticalSequence = true;
                    }
                }
            }

            return isVerticalSequence;
        }

        public bool         IsDownwardDiagonalSequence(string i_PlayerCoin)
        {
            bool        isDownwardDiagonalSequence = false;
            string[,]   matrixBoard = GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_Rows - 4; i++)
            {
                for (int j = 0; j <= m_Columns - 4; j++)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 1, j + 1].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 2, j + 2].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 3, j + 3].Equals(i_PlayerCoin))
                    {
                        isDownwardDiagonalSequence = true;
                    }
                }
            }

            return isDownwardDiagonalSequence;
        }

        public bool         IsUpwardDiagonalSequence(string i_PlayerCoin)
        {
            bool        isUpwardDiagonalSequence = false;
            string[,]   matrixBoard = GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_Rows - 4; i++)
            {
                for (int j = m_Columns - 1; j >= 3; j--)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 1, j - 1].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 2, j - 2].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 3, j - 3].Equals(i_PlayerCoin))
                    {
                        isUpwardDiagonalSequence = true;
                    }
                }
            }

            return isUpwardDiagonalSequence;
        }

        public void         AddCoin(int i_Rows, int i_Columns, string i_Coin)
        {
            m_PlayerInput[i_Rows, i_Columns] = i_Coin;
        }

        public List<string> GetColumnPlayerInput(int i_Height)
        {
            m_CurrentHeightGame.Clear();

            for (int width = 0; width < m_PlayerInput.GetLength(0); width++)
            {
                if (!m_PlayerInput[width, i_Height].Equals(""))
                {
                    m_CurrentHeightGame.Add(m_PlayerInput[width, i_Height]);
                }
            }
            return m_CurrentHeightGame;
        }

        public string[,]    GetCurrentPlayerBoardMatrix()
        {
            return m_PlayerInput;
        }

        public void         CreateEmptyMatrix()
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    m_PlayerInput[i, j] = "";
                }
            }
        }

        public void         ClearGame()
        {
            m_PlayerInput = new string[m_Rows, m_Columns];
            CreateEmptyMatrix();
            m_IsPlayerWin = false;
        }
    }
}
