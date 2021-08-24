namespace C21_Ex02
{
    class MachineAI
    {
        public int TryToWinMove(string[,] i_CurrentBoard, int i_Width, int i_Height)
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

        public int BuildSequenceOfThree(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindFreeCellSequenceOfTwoLeft(i_CurrentBoard, i_Width, i_Height) != -1)
            {
                chooseColumns = FindFreeCellSequenceOfTwoLeft(i_CurrentBoard, i_Width, i_Height);
            }

            else if (FindFreeCellSequenceOfTwoRight(i_CurrentBoard, i_Width, i_Height) != -1)
            {
                chooseColumns = FindFreeCellSequenceOfTwoRight(i_CurrentBoard, i_Width, i_Height);
            }

            else if (FindFreeCellSequenceOfTwoUp(i_CurrentBoard, i_Width, i_Height) != -1)
            {
                chooseColumns = FindFreeCellSequenceOfTwoUp(i_CurrentBoard, i_Width, i_Height);
            }

            return chooseColumns;
        }

        public int FindFreeCellSequenceOfTwoLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfTwoLeft(i_CurrentBoard, i_Width, i_Height) && FindFreeCellRight(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height + 1;
            }

            else if (FindSeuenceOfTwoLeft(i_CurrentBoard, i_Width, i_Height) && FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height - 1))
            {
                chooseColumns = i_Height - 2;
            }

            return chooseColumns;
        }

        public int FindFreeCellSequenceOfTwoRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfTwoRight(i_CurrentBoard, i_Width, i_Height) && FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height - 1;
            }

            else if (FindSeuenceOfTwoRight(i_CurrentBoard, i_Width, i_Height) && FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height + 1))
            {
                chooseColumns = i_Height + 2;
            }
            return chooseColumns;
        }

        public int FindFreeCellSequenceOfTwoUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfTwoUp(i_CurrentBoard, i_Width, i_Height) && FindFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height;
            }

            return chooseColumns;
        }

        public int TryNotToLoseeLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
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

        public int TryNotToLoseeRigth(string[,] i_CurrentBoard, int i_Width, int i_Height)
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

        public int TryNotToLoseeUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            int chooseColumns = -1;

            if (FindSeuenceOfThreeUp(i_CurrentBoard, i_Width, i_Height) && FindFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                chooseColumns = i_Height;
            }

            return chooseColumns;
        }

        public int MoveLeftOrRightOrUp(string[,] i_CurrentBoard, int i_Width , int i_Height)
        {
            int chooseColumns = -1;
            System.Random leftOrRight = new System.Random();

            while (chooseColumns == -1)
            {
                switch (leftOrRight.Next(1, 4))
                {
                    case 1:
                        if (FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height))
                        {
                            chooseColumns = i_Height - 1;
                        }
                        break;
                    case 2:
                        if (FindFreeCellRight(i_CurrentBoard, i_Width, i_Height))
                        {
                            chooseColumns = i_Height + 1;
                        }
                        break;
                    case 3:
                        if (FindFreeCellUp(i_CurrentBoard, i_Width, i_Height))
                        {
                            chooseColumns = i_Height;
                        }
                        break;
                }
            }

            return chooseColumns;
        }

        public bool IfCanMoveLeftRightUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            if (FindFreeCellLeft(i_CurrentBoard, i_Width, i_Height) ||
                FindFreeCellRight(i_CurrentBoard, i_Width, i_Height) ||
                FindFreeCellUp(i_CurrentBoard, i_Width, i_Height))
            {
                return true;
            }

            return false;
        }

        public bool FindFreeCellLeft(string[,] i_CurrentBoard , int i_Width, int i_Height)
        {
            if (i_Height - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1] == "")
                {
                    return true;
                }
            }

            return false;
        }

        public bool FindFreeCellRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            if (i_Height + 1 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1] == "")
                {
                    return true;
                }
            }
           
            return false;
        }

        public bool FindFreeCellUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            if (i_Width - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width - 1, i_Height] == "")
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool FindSeuenceOfThreeLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            string playerCoin = i_CurrentBoard[i_Width, i_Height];

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

        public bool FindSeuenceOfThreeRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            string playerCoin = i_CurrentBoard[i_Width, i_Height];

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

        public bool FindSeuenceOfThreeUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            string playerCoin = i_CurrentBoard[i_Width, i_Height];

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

        public bool FindSeuenceOfTwoRight(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            string playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height + 1 < i_CurrentBoard.GetLength(1))
            {
                if (i_CurrentBoard[i_Width, i_Height + 1].Equals(playerCoin))
                {
                    return true;
                }
            }

            return false;
        }

        public bool FindSeuenceOfTwoLeft(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            string playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Height - 1 >= 0)
            {
                if (i_CurrentBoard[i_Width, i_Height - 1].Equals(playerCoin))
                {
                    return true;
                }
            }

            return false;
        }

        public bool FindSeuenceOfTwoUp(string[,] i_CurrentBoard, int i_Width, int i_Height)
        {
            string playerCoin = i_CurrentBoard[i_Width, i_Height];

            if (i_Width + 1 < i_CurrentBoard.GetLength(0))
            {
                if (i_CurrentBoard[i_Width + 1, i_Height].Equals(playerCoin))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
