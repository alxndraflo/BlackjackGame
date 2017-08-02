using System;

namespace CodingChallenges.CardGame
{
    public class CardsMain
    {
        static void Main(string[] args)
        {
            var quit = false;

            Console.WriteLine("Welcome to the game engine!\n");

            do
            {
                Console.Write("Would you like to start a new game (Y/N)?\nChoice: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "Y" || input == "y")
                {
                    BlackjackGame.Instance.StartNewGame();
                }
                else if (input == "N" || input == "n")
                {
                    Console.WriteLine("Ok, goodbye!");
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.\n");
                }

            } while (!quit);

            Console.WriteLine("Quitting game program...");
        }
    }
}
