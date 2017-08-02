using System;
using System.Collections.Generic;

namespace CodingChallenges.CardGame
{
    class CardsMain
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





















//static void CreateCustomGame()
//{
//    CardDeck deckOfCards = new CardDeck();
//    int numCards = 52;
//    int numPlayers;
//    int numCardsPerPlayer;
//    var playAgain = false;

//    //Console.WriteLine("UN-SHUFFLED Deck: \n");
//    //Console.Write(deckOfCards.ToString());

//    do
//    {
//        Console.WriteLine("--- Custom Game - NEW GAME --- \n");
//        Console.Write("Please enter number of players: ");
//        var players = Console.ReadLine();
//        int.TryParse(players, out numPlayers);

//        Console.Write("Please enter number of cards per player: ");
//        var cards = Console.ReadLine();
//        int.TryParse(cards, out numCardsPerPlayer);

//        Console.Write("Please choose an option: \n" +
//                            "     1) Shuffle cards. \n" +
//                            "     2) Deal cards. \n" +
//                            "     0) Exit. \n");
//        Console.Write("Option: ");
//        var option = Console.ReadLine();


//        switch (option)
//        {
//            case "1":
//            {
//                deckOfCards.Shuffle();
//                Console.Write("SHUFFLED Deck: \n");
//                Console.Write(deckOfCards.ToString());
//                break;
//            }
//            case "2":
//            {
//                Console.WriteLine();
//                Console.WriteLine("DEALT Hand: ");
//                for (int i = 0; i < numCardsPerPlayer; i++)
//                {
//                    for (int j = 0; j < numPlayers; j++)
//                    {
//                        deckOfCards.DealCard();
//                    }
//                }
//                break;
//            }
//            case "0":
//            {
//                break;
//            }
//        }

//        Console.Write("Do you want to play another game? (Y/N): ");
//        var quit = Console.ReadLine();
//        if (quit == "Y" || quit == "y")
//        {
//            playAgain = true;
//        }
//        else
//        {
//            Console.WriteLine("Returning to Main Menu.");
//        }

//    } while (playAgain);

//}






//static void Main(string[] args)
//{
//var quitProgram = false;

//    do
//{
//    Console.WriteLine("Welcome to the game engine!! \n");
//    Console.WriteLine("--- MAIN MENU ---\n");
//    Console.Write("Please choose an option (Enter 1, 2, or 0): \n" +
//                  "     1) Play Blackjack.\n" +
//                  "     2) Play Custom Game.\n" +
//                  "     0) Exit.\n\n" +
//                  "Enter option (1, 2, or 0): ");
//    var option = Console.ReadLine();

//    switch (option)
//    {
//        case "1":
//            break;
//        case "2":
//            CreateCustomGame();
//            break;
//        case "0":
//            break;
//    }

//    Console.WriteLine("Do you want to Quit? (Y/N): ");
//    var userIn = Console.ReadLine();

//    if (userIn == "N" || userIn == "n")
//    {
//        quitProgram = true;
//    }

//} while (quitProgram);

//Console.Write("Quitting now... Goodbye!\n");
//}




//static void Main(string[] args)
//{
//int numCards = 52;
//int[] deck = new int[numCards];

//    for (int i = 0; i < numCards; i++)
//{
//    deck[i] += i;
//    Console.WriteLine(deck[i]);
//}
//Console.WriteLine();

//Random shuffle = new Random();

//    for (int i = deck.Length - 1; i > 0; i--)
//{
//    int count = shuffle.Next(i + 1);

//    int temp = deck[count];
//    deck[count] = deck[i];
//    deck[i] = temp;
//}

//Console.WriteLine("Shuffled Deck: \n");

//foreach (int card in deck)
//{
//    Console.WriteLine(card);
//}

//}