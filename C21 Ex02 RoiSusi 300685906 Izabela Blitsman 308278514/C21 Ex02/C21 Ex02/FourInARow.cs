using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C21_Ex02
{
    class FourInARow
    {
        //This is the Logic Class
        //Here we need to implement all the rules
        private Player m_playerOneName;
        private Player m_playerTwoName;
        private const char m_coinOne = 'X';
        private const char m_coinTwo = 'O';
        private int m_matrixWidth = 0;
        private int m_matrixHeight = 0;


        public FourInARow(string i_playerOne, string i_playerTwo)
        {
            m_playerOneName = new Player(i_playerOne, m_coinOne);
            m_playerTwoName = new Player(i_playerTwo, m_coinTwo);
        }

        public void Turn()
        {

        }

        public static void Menu()
        {
            int matrixWidth = 0;
            int matrixHeight = 0;
            int optionChoose = 0;
            string readFromUser = "";
            string welcome = "";

            welcome = string.Format("Hello and welcome to 4 in a Row game\n" +
                                    "Please Select the Size of the BoardGame\n" +
                                    "Please Enter Width");
            System.Console.WriteLine(welcome);
            readFromUser = System.Console.ReadLine();
            matrixWidth = int.Parse(readFromUser);

            welcome = string.Format("Please Enter Height");
            System.Console.WriteLine(welcome);
            readFromUser = System.Console.ReadLine();
            matrixHeight = int.Parse(readFromUser);
            System.Console.WriteLine(welcome);

            welcome = string.Format("Please select one of the options\n" +
                                    "1. Player Vs Player\n" +
                                    "2. Player Vs Computer\n");
            System.Console.WriteLine(welcome);

            readFromUser = System.Console.ReadLine();
            optionChoose = int.Parse(readFromUser);

            switch (optionChoose)
            {
                case 1:
                {
                    System.Console.WriteLine("You selected option {0} {1}\n" , optionChoose,GameOption.PlayerVsPlayer);
                    break;
                }
                case 2:
                {
                    System.Console.WriteLine("You selected option {0} {1}\n", optionChoose,GameOption.PlayerVsMachine);
                    break;
                }
            }

            MatrixCliUi matrixCliUi = new MatrixCliUi(matrixWidth, matrixHeight);
            matrixCliUi.InitiateNewGame();
            matrixCliUi.PrintGameMatrixBoard();

            //Testing
            matrixCliUi.AddCoin(3,3,"X");
            List<string> getList = matrixCliUi.GetColumnPlayerInput(3);
            System.Console.WriteLine(getList[3]);
        }
    }
}
