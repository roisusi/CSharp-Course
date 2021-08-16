using System;

namespace Ex04.Menus.Test
{
    class ActionsCollection
    {
        public void ShowDate()
        {
            Console.WriteLine($"Current Date: {DateTime.Now.Date:dd/MM/yyyy}");
        }

        public void ShowTime()
        {
            Console.WriteLine($"Current Time: {DateTime.Now:HH:mm:ss}");
        }

        public void CountSpaces()
        {
            string userStringInput;
            int spacesNumber;

            Console.WriteLine("Please enter a sentence:");
            userStringInput = getStringFromUser();
            spacesNumber = getSpacesNumberInString(userStringInput);
            Console.WriteLine(@"There are {0} spaces in the sentence: 
{1}",
                spacesNumber.ToString(),
                userStringInput);
        }

        private string getStringFromUser()
        {
            string userStringInput;

            userStringInput = Console.ReadLine();
            while (userStringInput == string.Empty)
            {
                Console.WriteLine("Invalid input. Please try again:");
                userStringInput = Console.ReadLine();
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
            Console.WriteLine("Version: 21.1.4.8930");
        }
    }
}
