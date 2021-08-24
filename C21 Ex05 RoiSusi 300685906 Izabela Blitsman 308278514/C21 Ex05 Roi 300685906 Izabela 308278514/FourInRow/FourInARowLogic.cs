using System.Collections.Generic;
using FourInRow;

namespace C21_Ex02
{
    public class FourInRowLogic
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private List<Player> m_PlayersList = new List<Player>();
        private readonly string r_CoinOne = "X";
        private readonly string r_CoinTwo = "O";
        private int m_Rows = 0;
        private int m_Columns = 0;
        private string[,] m_PlayerInput = null;
        private List<string> m_CurrentHeightGame = null;
        private bool m_isPlayerWin = false;
        private bool m_isATie = false;
        private int m_Score = 0;
        private string m_PlayerWonName = string.Empty;


        public FourInRowLogic(int i_Rows, int i_Columns)
        {
            m_Rows = i_Rows;
            m_Columns = i_Columns;
            m_PlayerInput = new string[i_Rows, i_Columns];
            m_CurrentHeightGame = new List<string>(i_Columns);
            CreateEmptyMatrix();
            
        }

        public void SetPlayers(string i_Player1Name, string i_Player2Name)
        {
            m_FirstPlayer = new Player(i_Player1Name, r_CoinOne, false, true);
            m_SecondPlayer = new Player(i_Player2Name, r_CoinTwo, true, false);
            m_PlayersList.Add(m_FirstPlayer);
            m_PlayersList.Add(m_SecondPlayer);
        }

        public void PlayerVsMachineGame(int i_ButtonIndex)
        {
            int width = 0;
            int height = 0;
            int machineLastHight = -1;
            int machineLastWidth = -1;
            bool isPlayerExitGame = false;
            bool isPlayerWin = false;
            List<Player> playersList = new List<Player>();
            System.Random random = new System.Random();
            MachineAI machineAI = new MachineAI();

            playersList.Add(m_FirstPlayer);
            playersList.Add(m_SecondPlayer);

            do
            {
                isPlayerWin = false;
                isPlayerExitGame = false;
                machineLastHight = -1;
                machineLastWidth = -1;
                m_FirstPlayer.Turn = false;
                m_SecondPlayer.Turn = false;

                while (!IsMatrixFull() && !isPlayerWin && !isPlayerExitGame)
                {
                    foreach (Player player in playersList)
                    {
                        if (!player.Machine)
                        {
                            //PlayerInputValidation(player, out height);

                            if (height == -1)
                            {
                                //UserExitGame(playersList, player);
                                isPlayerExitGame = true;
                                break;
                            }
                        }

                        else 
                        {
                            width = m_Rows - this.GetColumnPlayerInput(height).Count;

                            if (machineLastHight != -1 && machineAI.TryToWinMove(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.TryToWinMove(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineAI.TryNotToLoseeUp(this.GetCurrentPlayerBoardMatrix(), width, height) != -1)
                            {
                                height = machineAI.TryNotToLoseeUp(this.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else if (machineAI.TryNotToLoseeLeft(this.GetCurrentPlayerBoardMatrix(), width, height) != -1)
                            {
                                height = machineAI.TryNotToLoseeLeft(this.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else if (machineAI.TryNotToLoseeRigth(this.GetCurrentPlayerBoardMatrix(), width, height) != -1)
                            {
                                height = machineAI.TryNotToLoseeRigth(this.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else if (machineLastHight != -1 && machineAI.FindFreeCellSequenceOfTwoLeft(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.FindFreeCellSequenceOfTwoLeft(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineLastHight != -1 && machineAI.FindFreeCellSequenceOfTwoRight(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.FindFreeCellSequenceOfTwoRight(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineLastHight != -1 && machineAI.FindFreeCellSequenceOfTwoUp(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.FindFreeCellSequenceOfTwoUp(this.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineAI.IfCanMoveLeftRightUp(this.GetCurrentPlayerBoardMatrix(), width, height) &&
                                !machineAI.FindSeuenceOfThreeUp(this.GetCurrentPlayerBoardMatrix(), width, height) &&
                                !machineAI.FindSeuenceOfThreeLeft(this.GetCurrentPlayerBoardMatrix(), width, height) &&
                                !machineAI.FindSeuenceOfThreeRight(this.GetCurrentPlayerBoardMatrix(), width, height))
                            {
                                height = machineAI.MoveLeftOrRightOrUp(this.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else
                            {
                                do
                                {
                                    height = random.Next(1, m_Columns + 1);
                                } while (IsMatrixColumnFull(height));
                            }

                            machineLastHight = height;
                            machineLastWidth = m_Rows - this.GetColumnPlayerInput(height).Count - 1;
                        }

                        PlayerTurn(player, height);

                        if (isPlayerWin)
                        {
                            break;
                        }
                    }
                }

                if (!isPlayerExitGame)
                {
                    FindGameWinner(playersList);
                }

            } while (IsAnotherRound());
        }

        public void PlayerVsPlayerGame(int i_ButtonIndex)
        {
            m_isATie = false;
            Player currentPlayer = getCurrentPlayer();
            PlayerTurn(currentPlayer, i_ButtonIndex);
            CheckIfPlayerWon(currentPlayer);
            if (IsMatrixFull())
            {
                m_isATie = true;
                m_SecondPlayer.Score++;
                m_FirstPlayer.Score++;
                m_PlayerWonName = string.Empty;
            }

        }

        private Player getCurrentPlayer()
        {
            Player currentPlayer = null;

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

        private void PlayerTurn(Player io_CurrentPlayer, int i_Column)
        {
            int width = 0;

            width = m_Rows - this.GetColumnPlayerInput(i_Column).Count - 1;
            this.AddCoin(width, i_Column, io_CurrentPlayer.Coin);
        }
        public bool AnnounceTie()
        {
            return m_isATie;
        }
        public bool AnnouncePlayer()
        {
            return m_isPlayerWin;
        }

        public string PlayarWonName()
        {
            return m_PlayerWonName;
        }

        public int PlayarScore()
        {
            return m_Score;
        }

        public bool CheckIfPlayerWon(Player io_CurrentPlayer)
        {
            int score = 0;
            if (CheckIfPlayerWin(io_CurrentPlayer.Coin))
            {
                score = io_CurrentPlayer.Score;
                io_CurrentPlayer.Score= ++score;
                m_isPlayerWin = true;
                m_Score = score;
                m_PlayerWonName = io_CurrentPlayer.Name;
                m_FirstPlayer.Turn = true;
                m_SecondPlayer.Turn = false;

            }

            return m_isPlayerWin;
        }

        public void FindGameWinner(List<Player> i_PlayersList)
        {
            Player winner = null;

            foreach (Player player in i_PlayersList)
            {
                if (player.Turn)
                {
                    winner = player;
                    break;
                }
            }

            if (winner != null)
            {
                string winnerMessage = string.Format("Congradulations, the winner is {0}", winner.Name);
                System.Console.WriteLine(winnerMessage);
            }

            else
            {
                System.Console.WriteLine("This is a Tie - no winner in this game");
            }
        }

        public bool IsMatrixColumnFull(int i_MatrixColumn)
        {
            List<string> matrixColumn = this.GetColumnPlayerInput(i_MatrixColumn);

            if (matrixColumn.Count < m_Rows)
            {
                return false;
            }

            return true;
        }

        public bool IsMatrixFull()
        {
            string[,] matrixBoard = this.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    if (matrixBoard[i, j].Equals(""))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckIfPlayerWin(string i_PlayerCoin)
        {
            if (IsHorizontalSequence(i_PlayerCoin) ||
                IsVerticalSequence(i_PlayerCoin) ||
                IsDownwardDiagonalSequence(i_PlayerCoin) ||
                IsUpwardDiagonalSequence(i_PlayerCoin))
            {
                return true;
            }

            return false;
        }

        public bool IsHorizontalSequence(string i_PlayerCoin)
        {
            string[,] matrixBoard = this.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j <= m_Columns - 4; j++)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i, j + 1].Equals(i_PlayerCoin) &&
                        matrixBoard[i, j + 2].Equals(i_PlayerCoin) &&
                        matrixBoard[i, j + 3].Equals(i_PlayerCoin))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsVerticalSequence(string i_PlayerCoin)
        {
            string[,] matrixBoard = this.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_Rows - 4; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 1, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 2, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 3, j].Equals(i_PlayerCoin))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsDownwardDiagonalSequence(string i_PlayerCoin)
        {
            string[,] matrixBoard = this.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_Rows - 4; i++)
            {
                for (int j = 0; j <= m_Columns - 4; j++)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 1, j + 1].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 2, j + 2].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 3, j + 3].Equals(i_PlayerCoin))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsUpwardDiagonalSequence(string i_PlayerCoin)
        {
            string[,] matrixBoard = this.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_Rows - 4; i++)
            {
                for (int j = m_Columns - 1; j >= 3; j--)
                {
                    if (matrixBoard[i, j].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 1, j - 1].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 2, j - 2].Equals(i_PlayerCoin) &&
                        matrixBoard[i + 3, j - 3].Equals(i_PlayerCoin))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsAnotherRound()
        {
            string readFromUser = null;

            System.Console.WriteLine("Do you want to play another round? Press YES or any other key to exit");
            readFromUser = System.Console.ReadLine();
            
            if (readFromUser.ToUpper().Equals("YES"))
            {
                return true;
            }

            return false;
        }

        public void AddCoin(int i_Rows, int i_Columns, string i_Coin)
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

        public string[,] GetCurrentPlayerBoardMatrix()
        {
            return m_PlayerInput;
        }

        public void CreateEmptyMatrix()
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Columns; j++)
                {
                    m_PlayerInput[i, j] = "";
                }
            }
        }

        public void ClearGame()
        {
            m_PlayerInput = new string[m_Rows, m_Columns];
            CreateEmptyMatrix();
            m_isPlayerWin = false ;

        }
    }
}
