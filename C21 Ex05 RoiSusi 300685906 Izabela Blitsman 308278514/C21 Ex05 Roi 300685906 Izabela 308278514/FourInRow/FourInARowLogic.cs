using System.Collections.Generic;
using FourInRow;

namespace C21_Ex02
{
    public class FourInRowLogic
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private readonly string r_CoinOne = "X";
        private readonly string r_CoinTwo = "O";
        private int m_MatrixWidth = 0;
        private int m_MatrixHeight = 0;
        private readonly int r_MaxBoardParameter = 8;
        private readonly int r_MinBoardParameter = 4;
        private GameSettings m_GameSettings = null;
        private GameBorad m_GameBorad = null;


        //public void Menu()
        //{
        //    int optionChoose = 0;
        //    string readFromUser = "";
        //    string userMessage = "";

        //    userMessage = string.Format("Hello and welcome to 4 in a Row game\n" +
        //                            "Please Select the Size of the BoardGame\n");
        //    System.Console.WriteLine(userMessage);

        //    System.Console.WriteLine("Please Enter Matrix Width:");
        //    readFromUser = System.Console.ReadLine();
        //    GetMatrixInput(readFromUser, out m_MatrixWidth);

        //    System.Console.WriteLine("Please Enter Matrix Height");
        //    readFromUser = System.Console.ReadLine();
        //    GetMatrixInput(readFromUser, out m_MatrixHeight); 

        //    userMessage = string.Format("Please select one of the options\n" +
        //                            "1. Player Vs Player\n" +
        //                            "2. Player Vs Computer\n");

        //    System.Console.WriteLine(userMessage);
        //    readFromUser = System.Console.ReadLine();
        //    GetGameInput(readFromUser, out optionChoose);

        //    switch (optionChoose)
        //    {
        //        case 1:
        //            {
        //                System.Console.WriteLine("You selected option {0} {1}\n" , optionChoose,GameOption.PlayerVsPlayer);
        //                PlayerVsPlayerGame();
        //                break;
        //            }
        //        case 2:
        //            {
        //                System.Console.WriteLine("You selected option {0} {1}\n", optionChoose, GameOption.PlayerVsMachine);
        //                PlayerVsMachineGame();
        //                break;
        //            }
        //    }
        //}

        public void Setting()
        {
            m_GameSettings = new GameSettings();
            m_GameSettings.ShowDialog();
        }

        public void Play(GameBorad gameBorad)
        {
            m_GameBorad = gameBorad;
            PlayerVsPlayerGame();
        }

        public void SetPlayers(string i_PlayerName)
        {
            m_FirstPlayer = new Player(i_PlayerName, r_CoinOne, false, false);
            m_SecondPlayer = new Player(i_PlayerName, r_CoinTwo, true, false);
        }

        public void PlayerVsMachineGame()
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
            m_GameSettings = new GameSettings();

            SetPlayers(m_GameSettings.Player1Name);
            SetPlayers(m_GameSettings.Player2Name);

            playersList.Add(m_FirstPlayer);
            playersList.Add(m_SecondPlayer);

            do
            {
                isPlayerWin = false;
                isPlayerExitGame = false;
                machineLastHight = -1;
                machineLastWidth = -1;
                m_GameBorad.ClearGame();
                m_FirstPlayer.SetTurn(false);
                m_SecondPlayer.SetTurn(false);

                while (!IsMatrixFull() && !isPlayerWin && !isPlayerExitGame)
                {
                    foreach (Player player in playersList)
                    {
                        if (!player.GetMachine())
                        {
                            PlayerInputValidation(player, out height);

                            if (height == -1)
                            {
                                UserExitGame(playersList, player);
                                isPlayerExitGame = true;
                                break;
                            }
                        }

                        else 
                        {
                            width = m_MatrixWidth - m_GameBorad.GetColumnPlayerInput(height).Count;

                            if (machineLastHight != -1 && machineAI.TryToWinMove(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.TryToWinMove(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineAI.TryNotToLoseeUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height) != -1)
                            {
                                height = machineAI.TryNotToLoseeUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else if (machineAI.TryNotToLoseeLeft(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height) != -1)
                            {
                                height = machineAI.TryNotToLoseeLeft(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else if (machineAI.TryNotToLoseeRigth(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height) != -1)
                            {
                                height = machineAI.TryNotToLoseeRigth(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else if (machineLastHight != -1 && machineAI.FindFreeCellSequenceOfTwoLeft(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.FindFreeCellSequenceOfTwoLeft(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineLastHight != -1 && machineAI.FindFreeCellSequenceOfTwoRight(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.FindFreeCellSequenceOfTwoRight(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineLastHight != -1 && machineAI.FindFreeCellSequenceOfTwoUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight) != -1)
                            {
                                height = machineAI.FindFreeCellSequenceOfTwoUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), machineLastWidth, machineLastHight);
                            }

                            else if (machineAI.IfCanMoveLeftRightUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height) &&
                                !machineAI.FindSeuenceOfThreeUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height) &&
                                !machineAI.FindSeuenceOfThreeLeft(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height) &&
                                !machineAI.FindSeuenceOfThreeRight(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height))
                            {
                                height = machineAI.MoveLeftOrRightOrUp(m_GameBorad.GetCurrentPlayerBoardMatrix(), width, height);
                            }

                            else
                            {
                                do
                                {
                                    height = random.Next(1, m_MatrixHeight + 1);
                                } while (IsMatrixColumnFull(height));
                            }

                            machineLastHight = height;
                            machineLastWidth = m_MatrixWidth - m_GameBorad.GetColumnPlayerInput(height).Count - 1;
                        }

                        PlayerTurn(player, height, out isPlayerWin);

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

                PrintPlayersScore(playersList);

            } while (IsAnotherRound());
        }

        public void PlayerVsPlayerGame()
        {
            int height = 0;
            bool isPlayerWin = false;
            bool isPlayerExitGame = false;
            List<Player> playersList = new List<Player>();
            m_GameSettings = new GameSettings();


            SetPlayers(m_GameSettings.Player1Name);
            SetPlayers(m_GameSettings.Player2Name);

            playersList.Add(m_FirstPlayer);
            playersList.Add(m_SecondPlayer);

            do
            {
                isPlayerWin = false;
                isPlayerExitGame = false;
                //m_GameBorad.ClearGame();
                m_FirstPlayer.SetTurn(false);
                m_SecondPlayer.SetTurn(false);

                while (!IsMatrixFull() && !isPlayerWin && !isPlayerExitGame)
                {
                    foreach (Player player in playersList)
                    {
                        PlayerInputValidation(player, out height);

                        if (height == -1)
                        {
                            UserExitGame(playersList, player);
                            isPlayerExitGame = true;
                            break;
                        }

                        PlayerTurn(player, height, out isPlayerWin);

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
                
                PrintPlayersScore(playersList);

            } while (IsAnotherRound());
        }

        public void PlayerTurn(Player io_CurrentPlayer, int height, out bool i_IsPlayerWin)
        {
            int width = 0;
            i_IsPlayerWin = false;

            width = m_MatrixWidth - m_GameBorad.GetColumnPlayerInput(height).Count - 1;
            m_GameBorad.AddCoin(width, height, io_CurrentPlayer.GetCoin());

            if (CheckIfPlayerWin(io_CurrentPlayer.GetCoin()))
            {
                int score = io_CurrentPlayer.GetScore();
                io_CurrentPlayer.SetScore(++score);
                io_CurrentPlayer.SetTurn(true);
                i_IsPlayerWin = true;
            }
        }

        public void FindGameWinner(List<Player> i_PlayersList)
        {
            Player winner = null;

            foreach (Player player in i_PlayersList)
            {
                if (player.GetTurn())
                {
                    winner = player;
                    break;
                }
            }

            if (winner != null)
            {
                string winnerMessage = string.Format("Congradulations, the winner is {0}", winner.GetName());
                System.Console.WriteLine(winnerMessage);
            }

            else
            {
                System.Console.WriteLine("This is a Tie - no winner in this game");
            }
        }

        public void UserExitGame(List<Player> i_PlayersList, Player i_ExitGamePlayer)
        {
            int score = 0;

            foreach (Player player in i_PlayersList)
            {
                if (player != i_ExitGamePlayer)
                {
                    score = player.GetScore();
                    player.SetScore(++score);
                }
            }
        }

        public void PrintPlayersScore(List<Player> i_PlayersList)
        {
            string scoreMessage = null;

            foreach (Player player in i_PlayersList)
            {
                scoreMessage = string.Format("{0} score is: {1}", player.GetName(), player.GetScore());
                System.Console.WriteLine(scoreMessage);
            }
        }
        
        public bool IsMatrixColumnFull(int i_MatrixColumn)
        {
            List<string> matrixColumn = m_GameBorad.GetColumnPlayerInput(i_MatrixColumn - 1);

            if (matrixColumn.Count < m_MatrixWidth)
            {
                return false;
            }

            System.Console.WriteLine("The current column is full.");
            return true;
        }

        public bool IsMatrixFull()
        {
            string[,] matrixBoard = m_GameBorad.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i < m_MatrixWidth; i++)
            {
                for (int j = 0; j < m_MatrixHeight; j++)
                {
                    if (matrixBoard[i, j].Equals('\0'))
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
            string[,] matrixBoard = m_GameBorad.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i < m_MatrixWidth; i++)
            {
                for (int j = 0; j <= m_MatrixHeight - 4; j++)
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
            string[,] matrixBoard = m_GameBorad.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_MatrixWidth - 4; i++)
            {
                for (int j = 0; j < m_MatrixHeight; j++)
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
            string[,] matrixBoard = m_GameBorad.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_MatrixWidth - 4; i++)
            {
                for (int j = 0; j <= m_MatrixHeight - 4; j++)
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
            string[,] matrixBoard = m_GameBorad.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_MatrixWidth - 4; i++)
            {
                for (int j = m_MatrixHeight - 1; j >= 3; j--)
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

        public void GetGameInput(string i_UserInput, out int io_GameInput)
        {
            io_GameInput = 0;

            while (!GameInputValidation(i_UserInput, out io_GameInput))
            {
                System.Console.WriteLine("Please enter valid game option:");
                i_UserInput = System.Console.ReadLine();
            }
        }

        public bool GameInputValidation(string i_UserInput, out int o_GameInput)
        {
            o_GameInput = 0;

            if (int.TryParse(i_UserInput, out o_GameInput))
            {
                if (o_GameInput >= 1 && o_GameInput <= 2)
                {
                    return true;
                }
            }

            System.Console.WriteLine("Invalid input - choose the first or the second option.");
            return false;
        }

        public void GetMatrixInput(string i_UserInput, out int io_MatrixParameter)
        {
            io_MatrixParameter = 0;

            while (!BoardInputValidation(i_UserInput, out io_MatrixParameter))
            {
                System.Console.WriteLine("Please enter valid matrix parameter:");
                i_UserInput = System.Console.ReadLine();
            }
        }

        public bool BoardInputValidation(string i_BoardParameter, out int o_BoardParameter)
        {
            o_BoardParameter = 0;

            if (int.TryParse(i_BoardParameter, out o_BoardParameter))
            {
                if (o_BoardParameter >= r_MinBoardParameter && o_BoardParameter <= r_MaxBoardParameter)
                {
                    return true;
                }
            }

            string userMessage = string.Format("Invalid board parameter.\nBoard's minimum size 4X4 and maximum size 8X8");
            System.Console.WriteLine(userMessage);

            return false;
        }

        public bool MatrixInputValidation(string i_MatrixParameter, out int o_MatrixParameter)
        {
            o_MatrixParameter = 0;

            if (int.TryParse(i_MatrixParameter, out o_MatrixParameter))
            {
                if (o_MatrixParameter >= 1 && o_MatrixParameter <= m_MatrixHeight)
                {
                    return true;
                }
            }

            string userMessage = string.Format("Invalid board parameter.\nBoard's column sould be between 1 and {0}", m_MatrixHeight);

            if (!i_MatrixParameter.Equals("Q"))
            {
                System.Console.WriteLine(userMessage);
            }
                
            return false;
        }

        public void PlayerInputValidation(Player i_Player, out int o_MatrixHeight)
        {
            o_MatrixHeight = 0;
            string userMessage = null;
            string readFromUser = null;
            
            do
            {
                userMessage = string.Format("Player named {0} - Please choose a column in matrix or press 'Q' to exit:", i_Player.GetName());
                System.Console.WriteLine(userMessage);
                readFromUser = System.Console.ReadLine();

                while (!MatrixInputValidation(readFromUser, out o_MatrixHeight) && !readFromUser.Equals("Q"))
                {
                    System.Console.WriteLine(userMessage);
                    readFromUser = System.Console.ReadLine();
                }

            } while (!readFromUser.Equals("Q") && IsMatrixColumnFull(o_MatrixHeight));

            o_MatrixHeight--;
        }
    }
}
