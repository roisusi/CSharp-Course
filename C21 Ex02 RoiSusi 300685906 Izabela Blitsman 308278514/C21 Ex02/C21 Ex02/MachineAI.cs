using System;
using System.Collections.Generic;
using System.Text;

namespace C21_Ex02
{
    class MachineAI
    {

        //try make the same move as he did last time try to make
        // OO
        // 
        // O
        // O
        public int TryToWinMove(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (TryNotToLoseeLeft(i_CurrentBoard, i_Width, i_Height) != -1)
            {
                chooseColumns = TryNotToLoseeLeft(i_CurrentBoard, i_Width, i_Height);
            }

            else if (TryNotToLoseeRigth(i_CurrentBoard, i_Width, i_Height) != -1)
            {
                chooseColumns = TryNotToLoseeRigth(i_CurrentBoard, i_Width, i_Height);
            }

            else if (TryNotToLoseeUp(i_CurrentBoard, i_Width, i_Height) != -1)
            {
                chooseColumns = TryNotToLoseeUp(i_CurrentBoard, i_Width, i_Height);
            }

            return chooseColumns;
        }
    
        //find left 3 coin for player
        public int TryNotToLoseeLeft(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfThreeLeft(i_CurrentBoard, i_Width, i_Height) && FindFreeCellRight(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height + 1;
            }
            else if (FindSeuenceOfThreeLeft(i_CurrentBoard, i_Width, i_Height) && FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height - 2))
            {
                chooseColumns = i_Height - 3;
            }

            return chooseColumns;
        }

        //find right 3 coin for player
        public int TryNotToLoseeRigth(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfThreeRight(i_CurrentBoard, i_Width, i_Height) && FindFreeCellRight(i_CurrentBoard, i_Width, i_Height + 2))
            {
                chooseColumns = i_Height + 3;
            }

            else if (FindSeuenceOfThreeRight(i_CurrentBoard, i_Width, i_Height) && FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height - 1;
            }

            return chooseColumns;
        }

        //find up 3 coin for player
        public int TryNotToLoseeUp(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfThreeUp(i_CurrentBoard, i_Width, i_Height) && FindFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height;
            }

            return chooseColumns;
        }

        public int MoveLeftOrRightOrUp(char [,] i_CurrentBoard, int i_Width , int i_Height)
        {
            int chooseColumns = -1;
            Random leftOrRight = new Random();
            //if (leftOrRight.Next(0, 2) == 0)
            //{
                if (FindFreeCellLeft(i_CurrentBoard,  i_Width, i_Height))
                {
                    chooseColumns = i_Height - 1;
                }
            //}
            else if (FindFreeCellRight(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height + 1;
            }

            //cant go left or right then go up
            if (chooseColumns == -1)
            {
                if (FindFreeCellUp(i_CurrentBoard, i_Width, i_Height))
                {
                    //chooseColumns = i_Width - 1;
                    chooseColumns = i_Height;
                }
            }

            return chooseColumns;
        }

        //search if i can insert coin on left and it is free
        public bool FindFreeCellLeft(char[,] i_CurrentBoard , int i_Width, int i_Height)
        {
            if (i_Height - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1] == '\0')
                {
                    return true;
                }
            }

            return false;
        }

        //search if i can insert coin on right and it is free
        public bool FindFreeCellRight(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            /*            if (i_Height + 1 <= i_CurrentBoard.GetLength(0))
                        {
                            if (i_CurrentBoard[i_Width, i_Height + 1] == '\0')
                            {
                                return true;
                            }  
                        }*/

            if (i_Height + 1 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1] == '\0')
                {
                    return true;
                }
            }
           
            return false;
        }


        //search if i can insert coin UP and it is free
        public bool FindFreeCellUp(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            /*            if (i_Width - 1 <= i_CurrentBoard.GetLength(1))
                        {
                            if (i_CurrentBoard[i_Width - 1, i_Height] == '\0')
                            {
                                return true;
                            }
                        }*/

            if (i_Width - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width - 1, i_Height] == '\0')
                {
                    return true;
                }
            }

            return false;
        }

        //todo smart blocking
        
        //search if there is a left sequence of three player's coins
        public bool FindSeuenceOfThreeLeft(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            char playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height - 2 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1].Equals(playerCoin) &&
                    i_CurrentBoard[i_Width, i_Height - 2].Equals(playerCoin))
                {
                    return true;
                }
            }

            return false;
        }

        //search if there is a right sequence of three player's coins
        public bool FindSeuenceOfThreeRight(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            char playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height + 2 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1].Equals(playerCoin) &&
                    i_CurrentBoard[i_Width, i_Height + 2].Equals(playerCoin))
                {
                    return true;
                }
            }

            return false;
        }

        //search if there is a up sequence of three player's coins
        public bool FindSeuenceOfThreeUp(char[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            char playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Width + 2 < i_CurrentBoard.GetLength(0))
            {
                if (i_CurrentBoard[i_Width + 1, i_Height].Equals(playerCoin) &&
                    i_CurrentBoard[i_Width + 2, i_Height].Equals(playerCoin))
                {
                    return true;
                }
            }

            return false;
        }

        //if all other options were fail
/*        public int RandomInsert(ref char[,] i_currentBoard, int width, int height)
        {
            Random random = new Random();



            return chooseColumns;
        }*/
    }
}
