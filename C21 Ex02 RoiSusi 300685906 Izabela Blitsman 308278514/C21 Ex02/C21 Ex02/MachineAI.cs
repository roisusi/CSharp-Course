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
        public int tryToWinMove(ref char[,] i_currentBoard, int width, int height)
        {
            int chooseColumns = -1;

            return chooseColumns;
        }
    
        //find left or right 3 coin for player
        public int tryNotToLoseeLeftOrRight(ref char[,] i_currentBoard, int width, int height)
        {
            int chooseColumns = -1;

            return chooseColumns;
        }

        //find up 3 coin for player
        public int tryNotToLoseeUp(ref char[,] i_currentBoard, int width, int height)
        {
            int chooseColumns = -1;

            return chooseColumns;
        }

        public int MoveLeftOrRightOrUp(ref char [,] i_currentBoard,int width , int height)
        {
            int chooseColumns = -1;
            Random leftOrRight = new Random();
            if (leftOrRight.Next(0, 2) == 0)
            {
                if (findFreeCellLeft(i_currentBoard,  width, height))
                {
                    chooseColumns = height - 1;
                }
            }
            else if (findFreeCellRight(i_currentBoard, width, height))
            {
                chooseColumns = height + 1;
            }

            //cant go left or right then go up
            if (chooseColumns == -1)
            {
                if (findFreeCellRight(i_currentBoard, width, height))
                {
                    chooseColumns = width - 1;
                }
            }

            return chooseColumns;
        }

        //search if i can insert coin on left and it is free
        public bool findFreeCellLeft(char[,] i_currentBoard , int width, int height)
        {
            if (height - 1 >= 0)
            {
                if (i_currentBoard[width, height - 1] == '\0')
                    return true;
            }
            return false;
        }

        //search if i can insert coin on right and it is free
        public bool findFreeCellRight(char[,] i_currentBoard, int width, int height)
        {
            if (height + 1 <= i_currentBoard.GetLength(0))
            {
                if (i_currentBoard[width, height + 1] == '\0')
                    return true;
            }
            return false;
        }


        //search if i can insert coin UP and it is free
        public bool findFreeCellUp(char[,] i_currentBoard, int width, int height)
        {
            if (width - 1 <= i_currentBoard.GetLength(1))
            {
                if (i_currentBoard[width-1, height] == '\0')
                    return true;
            }
            return false;
        }

        //todo smart blocking


        //if all other options were fail
        public int RandomInsert(ref char[,] i_currentBoard, int width, int height)
        {
            int chooseColumns = -1;

            return chooseColumns;
        }





    }
}
