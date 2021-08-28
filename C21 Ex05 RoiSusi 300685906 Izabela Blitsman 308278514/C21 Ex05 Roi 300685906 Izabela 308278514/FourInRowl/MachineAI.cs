using System;
namespace FourInRowLogic
{
    class MachineAI
    {
        public int      TryToWinMove(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

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

        public int      FindFreeCellSequenceOfTwoLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

            if (findSeuenceOfTwoLeft(i_CurrentBoard, i_Width, i_Height) && findFreeCellRight(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height + 1;
            }
            else if (findSeuenceOfTwoLeft(i_CurrentBoard, i_Width, i_Height) && findFreeCellLeft(i_CurrentBoard, i_Width, i_Height - 1))
            {
                chooseColumns = i_Height - 2;
            }

            return chooseColumns;
        }

        public int      FindFreeCellSequenceOfTwoRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

            if (findSeuenceOfTwoRight(i_CurrentBoard, i_Width, i_Height) && findFreeCellLeft(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height - 1;
            }
            else if (findSeuenceOfTwoRight(i_CurrentBoard, i_Width, i_Height) && findFreeCellLeft(i_CurrentBoard, i_Width, i_Height + 1))
            {
                chooseColumns = i_Height + 2;
            }

            return chooseColumns;
        }

        public int      FindFreeCellSequenceOfTwoUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

            if (findSeuenceOfTwoUp(i_CurrentBoard, i_Width, i_Height) && findFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height;
            }

            return chooseColumns;
        }

        public int      TryNotToLoseeLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

            if (FindSeuenceOfThreeLeft(i_CurrentBoard, i_Width, i_Height) && findFreeCellRight(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height + 1;
            }
            else if (FindSeuenceOfThreeLeft(i_CurrentBoard, i_Width, i_Height) && findFreeCellLeft(i_CurrentBoard, i_Width, i_Height - 2))
            {
                chooseColumns = i_Height - 3;
            }

            return chooseColumns;
        }

        public int      TryNotToLoseeRigth(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

            if (FindSeuenceOfThreeRight(i_CurrentBoard, i_Width, i_Height) && findFreeCellRight(i_CurrentBoard, i_Width, i_Height + 2))
            {
                chooseColumns = i_Height + 3;
            }
            else if (FindSeuenceOfThreeRight(i_CurrentBoard, i_Width, i_Height) && findFreeCellLeft(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height - 1;
            }

            return chooseColumns;
        }

        public int      TryNotToLoseeUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int     chooseColumns = -1;

            if (FindSeuenceOfThreeUp(i_CurrentBoard, i_Width, i_Height) && findFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height;
            }

            return chooseColumns;
        }

        public int      MoveLeftOrRightOrUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int         chooseColumns = -1;
            Random      leftOrRight = new System.Random();

            while (chooseColumns == -1)
            {
                switch (leftOrRight.Next(1, 4))
                {
                    case 1:
                        if (findFreeCellLeft(i_CurrentBoard, i_Width, i_Height))
                        {
                            chooseColumns = i_Height - 1;
                        }
                        break;
                    case 2:
                        if (findFreeCellRight(i_CurrentBoard, i_Width, i_Height))
                        {
                            chooseColumns = i_Height + 1;
                        }
                        break;
                    case 3:
                        if (findFreeCellUp(i_CurrentBoard, i_Width, i_Height))
                        {
                            chooseColumns = i_Height;
                        }
                        break;
                }
            }

            return chooseColumns;
        }

        public bool     IfCanMoveLeftRightUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool    ifCanMove = false;

            if (findFreeCellLeft(i_CurrentBoard, i_Width, i_Height) ||
                findFreeCellRight(i_CurrentBoard, i_Width, i_Height) ||
                findFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                ifCanMove = true;
            }

            return ifCanMove;
        }

        private bool    findFreeCellLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool    isLeftCellFree = false;

            if (i_Height - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1] == string.Empty)
                {
                    isLeftCellFree = true;
                }
            }

            return isLeftCellFree;
        }

        private bool    findFreeCellRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool    isRightCellFree = false;

            if (i_Height + 1 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1] == string.Empty)
                {
                    isRightCellFree = true;
                }
            }

            return isRightCellFree;
        }

        private bool    findFreeCellUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool    isUpCellFree = false;

            if (i_Width - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width - 1, i_Height] == string.Empty)
                {
                    isUpCellFree = true;
                }
            }

            return isUpCellFree;
        }

        public bool     FindSeuenceOfThreeLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool        isLeftThreeSequence = false;
            string      playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height - 2 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1].Equals(playerCoin) &&
                    i_CurrentBoard[i_Width, i_Height - 2].Equals(playerCoin))
                {
                    isLeftThreeSequence = true;
                }
            }

            return isLeftThreeSequence;
        }

        public bool     FindSeuenceOfThreeRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool        isRightThreeSequence = false;
            string      playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height + 2 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1].Equals(playerCoin) &&
                    i_CurrentBoard[i_Width, i_Height + 2].Equals(playerCoin))
                {
                    isRightThreeSequence = true;
                }
            }

            return isRightThreeSequence;
        }

        public bool     FindSeuenceOfThreeUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool        isUpThreeSequence = false;
            string      playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Width + 2 < i_CurrentBoard.GetLength(0))
            {
                if (i_CurrentBoard[i_Width + 1, i_Height].Equals(playerCoin) &&
                    i_CurrentBoard[i_Width + 2, i_Height].Equals(playerCoin))
                {
                    isUpThreeSequence = true;
                }
            }

            return isUpThreeSequence;
        }

        private bool    findSeuenceOfTwoRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool        isRightTwoSequence = false;
            string      playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height + 1 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1].Equals(playerCoin))
                {
                    isRightTwoSequence = true;
                }
            }

            return isRightTwoSequence;
        }

        private bool    findSeuenceOfTwoLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool        isLeftTwoSequence = false;
            string      playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1].Equals(playerCoin))
                {
                    isLeftTwoSequence = true;
                }
            }

            return isLeftTwoSequence;
        }

        private bool    findSeuenceOfTwoUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            bool        isUpTwoSequence = false;
            string      playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Width + 1 < i_CurrentBoard.GetLength(0))
            {
                if (i_CurrentBoard[i_Width + 1, i_Height].Equals(playerCoin))
                {
                    isUpTwoSequence = true;
                }
            }

            return isUpTwoSequence;
        }
    }
}
