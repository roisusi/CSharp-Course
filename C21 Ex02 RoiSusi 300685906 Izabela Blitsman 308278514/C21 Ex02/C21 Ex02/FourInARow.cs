using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C21_Ex02
{
    public class FourInARow
    {
        //This is the Logic Class
        //Here we need to implement all the rules
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private const char m_CoinOne = 'X';
        private const char m_CoinTwo = 'O';
        private int m_MatrixWidth = 0;
        private int m_MatrixHeight = 0;
        private const int k_MaxBoardParameter = 8;
        private const int k_MinBoardParameter = 4;
        private MatrixCliUi m_MatrixCliUi = null;
        private bool v_AnotherRoundFlag = false;


/*        public FourInARow(string i_playerOne, string i_playerTwo)
        {
            m_PlayerOneName = new Player(i_playerOne, m_CoinOne);
            m_PlayerTwoName = new Player(i_playerTwo, m_CoinTwo);
        }*/

        public void Menu()
        {
            int optionChoose = 0;
            string readFromUser = "";
            string userMessage = "";

            userMessage = string.Format("Hello and welcome to 4 in a Row game\n" +
                                    "Please Select the Size of the BoardGame\n");
            Console.WriteLine(userMessage);

            Console.WriteLine("Please Enter Matrix Width:");
            readFromUser = Console.ReadLine();
            GetMatrixInput(readFromUser, out m_MatrixWidth); 

            Console.WriteLine("Please Enter Matrix Height");
            readFromUser = Console.ReadLine();
            GetMatrixInput(readFromUser, out m_MatrixHeight); 

            userMessage = string.Format("Please select one of the options\n" +
                                    "1. Player Vs Player\n" +
                                    "2. Player Vs Computer\n");
            
            Console.WriteLine(userMessage);
            readFromUser = Console.ReadLine();
            GetGameInput(readFromUser, out optionChoose);

            switch (optionChoose)
            {
                case 1:
                    {
                        Console.WriteLine("You selected option {0} {1}\n" , optionChoose,GameOption.PlayerVsPlayer);
                        PlayerVsPlayerGame();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You selected option {0} {1}\n", optionChoose, GameOption.PlayerVsMachine);
                        PlayerVsMachineGame();
                        break;
                    }
            }

/*            //Testing
            matrixCliUi.AddCoin(3,3,"X");
            List<string> getList = matrixCliUi.GetColumnPlayerInput(3);
            Console.WriteLine(getList[3]);*/
        }

        public void PlayerVsMachineGame()
        {
            int width = 0;
            int height = 0;
            String readFromUser;
            Random random = new Random();

            m_MatrixCliUi = new MatrixCliUi(m_MatrixWidth, m_MatrixHeight);
            m_MatrixCliUi.InitiateNewGame();

            m_FirstPlayer = new Player(null, 'X', true);
            m_SecondPlayer = new Player(null, 'O', false);

            do
            {
                while (true)
                {
                    if (m_FirstPlayer.GetTurn())
                    {
                        Console.WriteLine("Please choose a row in matrix:");
                        readFromUser = Console.ReadLine();

                        do
                        {
                            readFromUser = Console.ReadLine();
                        } while (!UserInputValidation(readFromUser, out width));

                        Console.WriteLine("Please choose a column in matrix or press 'Q' to exit:");
                        readFromUser = Console.ReadLine();
                        
                        do
                        {
                            readFromUser = Console.ReadLine();
                        } while (!UserInputValidation(readFromUser, out height));

                        if (readFromUser.Equals('Q'))
                        {
                            if (m_FirstPlayer.GetTurn())
                            {
                                int score = m_FirstPlayer.GetScore();
                                m_FirstPlayer.SetScore(score++);
                            }
                            else
                            {
                                int score = m_SecondPlayer.GetScore();
                                m_SecondPlayer.SetScore(score++);
                            }

                            break;
                        }

                        ////TODO: check if column is full

                        m_MatrixCliUi.AddCoin(width, height, m_FirstPlayer.GetCoin());

                        if (CheckIfPlayerWin(m_FirstPlayer.GetCoin()))
                        {
                            int score = m_FirstPlayer.GetScore();
                            m_FirstPlayer.SetScore(score++);
                            break;
                        }

                        m_FirstPlayer.SetTurn(false);
                        m_SecondPlayer.SetTurn(true);
                    }

                    else
                    {
                        height = random.Next(1, 9);

                        //TODO: check if column is full

                        m_MatrixCliUi.AddCoin(width, height, m_SecondPlayer.GetCoin());

                        if (CheckIfPlayerWin(m_SecondPlayer.GetCoin()))
                        {
                            int score = m_SecondPlayer.GetScore();
                            m_SecondPlayer.SetScore(score++);
                            break;
                        }

                        m_FirstPlayer.SetTurn(true);
                        m_SecondPlayer.SetTurn(false);
                    }

                    Ex02.ConsoleUtils.Screen.Clear();
                    m_MatrixCliUi.PrintGameMatrixBoard();
                }
            } while (IsAnotherRound());
        }

        public void PlayerVsPlayerGame()
        {
            int height = 0;
            bool isPlayerWin = false;
            string readFromUser = null;
            List<Player> playersList = new List<Player>();

            m_MatrixCliUi = new MatrixCliUi(m_MatrixWidth, m_MatrixHeight);
            //m_MatrixCliUi.InitiateNewGame();
            //m_MatrixCliUi.PrintGameMatrixBoard();

            m_FirstPlayer = new Player(null, 'X', true);
            m_SecondPlayer = new Player(null, 'O', false);
            
            playersList.Add(m_FirstPlayer);
            playersList.Add(m_SecondPlayer);

            do
            {
                isPlayerWin = false;
                Ex02.ConsoleUtils.Screen.Clear();
                m_MatrixCliUi.ClearGame();
                m_MatrixCliUi.PrintGameMatrixBoard();

                while (!IsMatrixFull() && !isPlayerWin)
                {
                    Console.WriteLine("Please choose a column in matrix or press 'Q' to exit:");
                    readFromUser = Console.ReadLine();

                    if (readFromUser.Equals("Q"))
                    {
                        if (m_FirstPlayer.GetTurn())
                        {
                            int score = m_SecondPlayer.GetScore();
                            m_SecondPlayer.SetScore(++score);
                        }
                        else
                        {
                            int score = m_FirstPlayer.GetScore();
                            m_FirstPlayer.SetScore(++score);
                        }

                        break;
                    }

                    do
                    {
                        while (!BoardInputValidation(readFromUser, out height))
                        {
                            Console.WriteLine("Please choose valid column in matrix:");
                            readFromUser = Console.ReadLine();
                        }
                        
                    } while (IsMatrixColumnFull(height));


/*                    foreach (Player player in playersList)
                    {
                        if(player.GetTurn())
                        {
                            PlayerTurn(player, height, out isPlayerWin);
                            player.SetTurn(false);
                        }

                    }*/

                    if (m_FirstPlayer.GetTurn())
                    {
                        PlayerTurn(ref m_FirstPlayer, height, out isPlayerWin);

                        m_FirstPlayer.SetTurn(false);
                        m_SecondPlayer.SetTurn(true);
                    }

                    else
                    {
                        PlayerTurn(ref m_SecondPlayer, height, out isPlayerWin);

                        m_FirstPlayer.SetTurn(true);
                        m_SecondPlayer.SetTurn(false);
                    }

                    Ex02.ConsoleUtils.Screen.Clear();
                    m_MatrixCliUi.PrintGameMatrixBoard();
                }

                if (isPlayerWin)
                {
                    if (!m_FirstPlayer.GetTurn())
                    {
                        Console.WriteLine("Congradulations, the winner is player 1");
                    }

                    else
                    {
                        Console.WriteLine("Congradulations, the winner is player 2");
                    }
                }

                else if (IsMatrixFull())
                {
                    Console.WriteLine("This is a tie - no winner in this game");
                }

                Console.WriteLine("Player 1 score: " + m_FirstPlayer.GetScore());
                Console.WriteLine("Player 2 score: " + m_SecondPlayer.GetScore());

            } while (IsAnotherRound());
        }

        public void PlayerTurn(ref Player io_CurrentPlayer, int height, out bool i_IsPlayerWin)
        {
            int width = 0;
            string readFromUser = null;
            i_IsPlayerWin = false;

            while (IsMatrixColumnFull(height))
            {
                Console.WriteLine("Please choose another column in matrix:");
                readFromUser = Console.ReadLine();

                while (!BoardInputValidation(readFromUser, out height))
                {
                    Console.WriteLine("Please choose valid column in matrix:");
                    readFromUser = Console.ReadLine();
                }
            }

            width = m_MatrixWidth - m_MatrixCliUi.GetColumnPlayerInput(height - 1).Count - 1;
            m_MatrixCliUi.AddCoin(width, height - 1, io_CurrentPlayer.GetCoin());

            if (CheckIfPlayerWin(io_CurrentPlayer.GetCoin()))
            {
                int score = io_CurrentPlayer.GetScore();
                io_CurrentPlayer.SetScore(++score);
                i_IsPlayerWin = true;
            }
        }

        public bool IsMatrixColumnFull(int i_MatrixColumn)
        {
            List<char> matrixColumn = m_MatrixCliUi.GetColumnPlayerInput(i_MatrixColumn - 1);

            if (matrixColumn.Count < m_MatrixHeight)
            {
                return false;
            }

            Console.WriteLine("The current column is full.");
            return true;
        }

        public bool IsMatrixFull()
        {
            char[,] matrixBoard = m_MatrixCliUi.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i < m_MatrixHeight; i++)
            {
                if (matrixBoard[0,i].Equals('\0'))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfPlayerWin(char i_PlayerCoin)
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

        public bool IsHorizontalSequence(Char i_PlayerCoin)
        {
            char[,] matrixBoard = m_MatrixCliUi.GetCurrentPlayerBoardMatrix();

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

        public bool IsVerticalSequence(char i_PlayerCoin)
        {
            char[,] matrixBoard = m_MatrixCliUi.GetCurrentPlayerBoardMatrix();

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

        public bool IsDownwardDiagonalSequence(char i_PlayerCoin)
        {
            char[,] matrixBoard = m_MatrixCliUi.GetCurrentPlayerBoardMatrix();

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

        public bool IsUpwardDiagonalSequence(char i_PlayerCoin)
        {
            char[,] matrixBoard = m_MatrixCliUi.GetCurrentPlayerBoardMatrix();

            for (int i = 0; i <= m_MatrixWidth - 4; i++)
            {
                for (int j = m_MatrixHeight - 1; j >= 4; j--)
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

        public bool IsAnotherRound()
        {
            string readFromUser = null;

            Console.WriteLine("Do you want to play another round? Press YES or any other key to exit");
            readFromUser = Console.ReadLine();
            
            if (readFromUser.ToUpper().Equals("YES"))
            {
                return true;
            }

            return false;
        }

        public bool StringInputValidtion(string i_UserInput)
        {
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (Char.IsLetter(i_UserInput[i]))
                {
                    if (Char.ToUpper(i_UserInput[i]) <'A' || Char.ToUpper(i_UserInput[i]) > 'Z')
                    {
                        Console.WriteLine("Invalid input - the answer should be YES or NO");
                        return false;
                    }
                }
            }

            return true;
        }

        public void GetGameInput(string i_UserInput, out int io_GameInput)
        {
            io_GameInput = 0;

            while (!GameInputValidation(i_UserInput, out io_GameInput))
            {
                Console.WriteLine("Please enter valid game option:");
                i_UserInput = Console.ReadLine();
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

            Console.WriteLine("Invalid input - choose the first or the second option.");
            return false;
        }

        public void GetMatrixInput(string i_UserInput, out int io_MatrixParameter)
        {
            io_MatrixParameter = 0;

            while (!UserInputValidation(i_UserInput, out io_MatrixParameter))
            {
                Console.WriteLine("Please enter valid matrix parameter:");
                i_UserInput = Console.ReadLine();
            }
        }

        public bool UserInputValidation(string i_BoardParameter, out int o_BoardParameter)
        {
            o_BoardParameter = 0;

            if (int.TryParse(i_BoardParameter, out o_BoardParameter))
            {
                if (o_BoardParameter >= k_MinBoardParameter && o_BoardParameter <= k_MaxBoardParameter)
                {
                    return true;
                }
            }

            StringBuilder userMessage = new StringBuilder();
            userMessage.AppendLine("Invalid board parameter.");
            userMessage.AppendLine("Board's minimum size 4X4 and maximum size 8X8");
            Console.WriteLine(userMessage);

            return false;
        }

        public bool BoardInputValidation(string i_BoardParameter, out int o_BoardParameter)
        {
            o_BoardParameter = 0;

            if (int.TryParse(i_BoardParameter, out o_BoardParameter))
            {
                if (o_BoardParameter >= 1 && o_BoardParameter <= m_MatrixHeight)
                {
                    return true;
                }
            }

            string userMessage = string.Format("Invalid board parameter.\nBoard's column sould be between 1 and {0}", m_MatrixHeight);
            Console.WriteLine(userMessage);
            return false;
        }
    }
}
