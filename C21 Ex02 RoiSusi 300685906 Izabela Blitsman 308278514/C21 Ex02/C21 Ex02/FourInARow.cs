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
                while (!IsGameOver())
                {
                    if (m_FirstPlayer.GetTurn())
                    {
                        Console.WriteLine("Please choose a row in matrix:");
                        readFromUser = Console.ReadLine();

                        do
                        {
                            readFromUser = Console.ReadLine();
                        } while (!BoardInputValidation(readFromUser, out width));

                        Console.WriteLine("Please choose a column in matrix or press 'Q' to exit:");
                        readFromUser = Console.ReadLine();
                        
                        do
                        {
                            readFromUser = Console.ReadLine();
                        } while (!BoardInputValidation(readFromUser, out height));

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

                        if (IsWin(m_FirstPlayer.GetCoin()))
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

                        if (IsWin(m_SecondPlayer.GetCoin()))
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
            int width = 0;
            int height = 0;
            string readFromUser = null;

            m_MatrixCliUi = new MatrixCliUi(m_MatrixWidth, m_MatrixHeight);
            m_MatrixCliUi.InitiateNewGame();

            m_FirstPlayer = new Player(null, 'X', true);
            m_SecondPlayer = new Player(null, 'O', false);

            do
            {
                while (!IsGameOver())
                {
                    //TODO: check if coulmn is not empty
                    //maybe this is GetIndex() method functionality in UI

                    Console.WriteLine("Please choose a row in matrix:");
                    do 
                    {
                        readFromUser = Console.ReadLine();
                    } while(!BoardInputValidation(readFromUser, out width));

                    Console.WriteLine("Please choose a column in matrix or press 'Q' to exit:");
                    readFromUser = Console.ReadLine();

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

                    do
                    {
                        readFromUser = Console.ReadLine();
                        while (!BoardInputValidation(readFromUser, out height))
                        {
                            readFromUser = Console.ReadLine();
                        }
                        
                    } while (!IsMatrixColumnFull(height));


                    if (m_FirstPlayer.GetTurn())
                    {
                        //TODO: check if column is full

                        m_MatrixCliUi.AddCoin(width, height, m_FirstPlayer.GetCoin());

                        if (IsWin(m_FirstPlayer.GetCoin()))
                        {
                            int score = m_FirstPlayer.GetScore();
                            m_FirstPlayer.SetScore(score++);
                        }

                        m_FirstPlayer.SetTurn(false);
                        m_SecondPlayer.SetTurn(true);
                    }

                    else
                    {
                        //TODO: check if column is full

                        m_MatrixCliUi.AddCoin(width, height, m_SecondPlayer.GetCoin());

                        if (IsWin(m_SecondPlayer.GetCoin()))
                        {
                            int score = m_SecondPlayer.GetScore();
                            m_SecondPlayer.SetScore(score++);
                        }

                        m_FirstPlayer.SetTurn(true);
                        m_SecondPlayer.SetTurn(false);
                    }

                    Ex02.ConsoleUtils.Screen.Clear();
                    m_MatrixCliUi.PrintGameMatrixBoard();
                }
            } while (IsAnotherRound());
        }

        public bool IsMatrixColumnFull(int i_MatrixColumn)
        {
            List<String> matrixColumn = m_MatrixCliUi.GetColumnPlayerInput(i_MatrixColumn);

            if (matrixColumn.Count < m_MatrixHeight)
            {
                Console.WriteLine("The current column is full. Please enter column in matrix:");
                return false;
            }

            return true;
        }

        public bool IsMatrixFull()
        {
            for (int i = 0; i < m_MatrixHeight; i++)
            {
                List<String> matrixColumn = m_MatrixCliUi.GetColumnPlayerInput(i_MatrixColumn);

                if (matrixColumn.Count < m_MatrixHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsGameOver()
        {
            //TODO: Check if matrix is full
            return false;
        }



        public bool IsWin(Char i_PlayerCoin)
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
            string[,] matrixBoard = m_MatrixCliUi.GetMatrixBoard();

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

        public bool IsVerticalSequence(Char i_PlayerCoin)
        {
            string[,] matrixBoard = m_MatrixCliUi.GetMatrixBoard();

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

        public bool IsDownwardDiagonalSequence(Char i_PlayerCoin)
        {
            string[,] matrixBoard = m_MatrixCliUi.GetMatrixBoard();

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

        public bool IsUpwardDiagonalSequence(Char i_PlayerCoin)
        {
            string[,] matrixBoard = m_MatrixCliUi.GetMatrixBoard();

            for (int i = 0; i <= m_MatrixWidth - 4; i++)
            {
                for (int j = m_MatrixHeight; j >= 4; j++)
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

            Console.WriteLine("Do you want to play another round? Press YES/NO");
            readFromUser = Console.ReadLine();

            while (!StringInputValidtion(readFromUser))
            {
                readFromUser = Console.ReadLine();
            }

            if (readFromUser.ToUpper().Equals("YES"))
            {
                return true;
            }

            else if (readFromUser.ToUpper().Equals("NO"))
            {
                return false;
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

        public void GetGameInput(String i_UserInput, out int io_GameInput)
        {
            io_GameInput = 0;

            while (!GameInputValidation(i_UserInput, out io_GameInput))
            {
                Console.WriteLine("Please enter vlaid game option:");
                i_UserInput = Console.ReadLine();
            }
        }

        public bool GameInputValidation(String i_UserInput, out int o_GameInput)
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

        public void GetMatrixInput(String i_UserInput, out int io_MatrixParameter)
        {
            io_MatrixParameter = 0;

            while (!BoardInputValidation(i_UserInput, out io_MatrixParameter))
            {
                Console.WriteLine("Please enter vlaid matrix parameter:");
                i_UserInput = Console.ReadLine();
            }
        }

        public bool BoardInputValidation(string i_BoardParameter, out int o_BoardParameter)
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
    }
}
