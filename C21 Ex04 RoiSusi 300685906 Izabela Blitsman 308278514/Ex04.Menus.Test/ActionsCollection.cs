using System;

namespace Ex04.Menus.Test
{
    class ActionsCollection
    {
        public void ShowDate()
        {
            string currentDate = string.Format("Current date: {0}", DateTime.Today.ToString("dd/MM/yyyy"));
            System.Console.WriteLine(currentDate);
        }

        public void ShowTime()
        {
            string currentTime = string.Format("Current time: {0}", DateTime.Now.ToString("h:mm:ss tt"));
            Console.WriteLine(currentTime);
        }

        public void CountSpaces()
        {
            string  userInput = string.Empty;
            string  userMessage = string.Empty;
            int     spacesNumber = 0;

            Console.WriteLine("Please write something:");
            userInput = getUserInput();
            spacesNumber = countSpacesNumber(userInput);
            userMessage = string.Format("Number of spaces: {0}", spacesNumber);
            System.Console.WriteLine(userMessage);
        }

        private string getUserInput()
        {
            string userInput = string.Empty;

            userInput = System.Console.ReadLine();

            while(userInput == string.Empty)
            {
                System.Console.WriteLine("Invalid input - Please try again:");
                userInput = System.Console.ReadLine();
            }

            return userInput;
        }

        private int countSpacesNumber(string i_UserInput)
        {
            int spacesCounter = 0;

            foreach(char letter in i_UserInput)
            {
                if(char.IsWhiteSpace(letter))
                {
                    spacesCounter++;
                }
            }

            return spacesCounter;
        }

        public void ShowVersion()
        {
            System.Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}