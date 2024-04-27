using System;

namespace MasterMind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Select Difficulty? [easy, medium, hard]");
            string difficulty;
            do
            {
                difficulty = Console.ReadLine().ToLower();
                if (difficulty != "easy" && difficulty != "medium" && difficulty != "hard")
                {
                    Console.WriteLine("Invalid difficulty level. Please select again.");
                }
            } while (difficulty != "easy" && difficulty != "medium" && difficulty != "hard");

            Random rand = new Random();
            int minRange = 0;
            int maxRange = 0;
            switch (difficulty)
            {
                case "easy":
                    minRange = 100;
                    maxRange = 999;
                    break;
                case "medium":
                    minRange = 1000;
                    maxRange = 9999;
                    break;
                case "hard":
                    minRange = 10000;
                    maxRange = 99999;
                    break;
            }

            string computerGuess = rand.Next(minRange, maxRange + 1).ToString();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Please write your guess number");
                string userGuess = Console.ReadLine();

                GetHelp(userGuess: userGuess, computerGuess: computerGuess);

                if (userGuess == computerGuess)
                {
                    Console.WriteLine("\nYou win!");
                    break;
                }
                else
                {
                    Console.WriteLine("\nIncorrect guess. Try again.");
                }

                if (i == 9)
                {
                    Console.WriteLine($"\nYou lost. The correct answer was: {computerGuess}");
                }
            }

        }
        static void GetHelp(string userGuess, string computerGuess)
        {
            for (int i = 0; i < userGuess.Length; i++)
            {
                if (userGuess[i] == computerGuess[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(userGuess[i]);
                }
                else if (computerGuess.Contains(userGuess[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(userGuess[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(userGuess[i]);
                }
                Console.ResetColor();
            }
        }

    }

}
