using System;

namespace Ex04.Menus.Test
{
    class ActionsCollection
    {
        public void ShowDate()
        {
            string currentDate = string.Format("Current date: {0}", DateTime.Today);
            System.Console.WriteLine(currentDate);
        }

        public void ShowTime()
        {
            string currentTime = string.Format("Current time: {0}", DateTime.Now);
            Console.WriteLine(currentTime);
        }

        public void CountSpaces()
        {
            string userStringInput;
            int spacesNumber;

            Console.WriteLine("Please enter a sentence:");
            userStringInput = getStringFromUser();
            spacesNumber = getSpacesNumberInString(userStringInput);
            string userMessage = string.Format("Number of spaces: {0}", spacesNumber);
            System.Console.WriteLine(userMessage);
        }

        private string getStringFromUser()
        {
            string userStringInput;

            userStringInput = System.Console.ReadLine();
            while (userStringInput == string.Empty)
            {
                System.Console.WriteLine("Invalid input. Please try again:");
                userStringInput = System.Console.ReadLine();
            }

            return userStringInput;
        }

        private int getSpacesNumberInString(string userStringInput)
        {
            int spacesCounter = 0;

            foreach (char letter in userStringInput)
            {
                if (char.IsWhiteSpace(letter))
                {
                    spacesCounter++;
                }
            }

            return spacesCounter;
        }

        public void ShowVerison()
        {
            System.Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}