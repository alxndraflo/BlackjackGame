using System;
using System.Collections.Generic;

namespace CodingChallenges.CardGame
{
    public class BlackjackGame : GameRules
    {
        private const int NumCardsPerPlayer = 2;
        private readonly CardDeck _deckOfCards;
        private readonly Dealer _dealer;
        private int _numPlayers;
        private List<Player> _players;

        private static BlackjackGame _instance;

        // Ensures that only one instance of BlackjackGame is created.
        public static BlackjackGame Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BlackjackGame();
                }

                return _instance;
            }
        }

        private BlackjackGame()
        {
            _deckOfCards = new CardDeck();
            _dealer = new Dealer(_deckOfCards);
        }

        // Initializes card game. Uses created deck, shuffles cards, and starts game.
        public void StartNewGame()
        {
            Console.WriteLine("Shuffling cards...\n");

            _deckOfCards.Shuffle();

            // Print shuffled deck of cards (for debugging purposes).
            //Console.WriteLine(_deckOfCards.ToString());
            //Console.WriteLine();

            PlayGame();
        }

        // Starts playing game. 
        private void PlayGame()
        {
            Console.Write("Please enter number of players: ");
            var playersIn = Console.ReadLine();
            Console.WriteLine();
            int.TryParse(playersIn, out _numPlayers);

            AddPlayers();

            Console.WriteLine("Dealing cards...\n");
            DealInitialHand();

            var allPlayerHandVals = AskHitStand();
            var dealerHandVal = _dealer.PlayDealer();

            DetermineWinners(dealerHandVal, allPlayerHandVals);
        }

        // Takes dealerHandValue and list of allPlayerHandValues as parameter. Prints winners.
        private void DetermineWinners(int dealerHandValIn, List<int> allPlayerHandValsIn)
        {
            var dealerHandValue = dealerHandValIn;
            var allPlayerHandValues = allPlayerHandValsIn;
            var playerCount = 1;

            foreach (var value in allPlayerHandValues)
            {
                if (value > dealerHandValue && value <= 21)
                {
                    Console.WriteLine($"Player {playerCount}: Congratulations, you win!! :)\n");
                }

                if (value < dealerHandValue && dealerHandValue <= 21)
                {
                    Console.WriteLine($"Player {playerCount}: Sorry you lose. :(\n");
                }

                if (value == dealerHandValue && value <= 21)
                {
                    Console.WriteLine($"Player {playerCount}: Push with dealer.\n");
                }

                if (value > 21)
                {
                    Console.WriteLine($"Player {playerCount}: Bust! You lose. :(\n");
                }

                playerCount++;
            }

            if (dealerHandValue > 21)
            {
                Console.WriteLine("Dealer: Bust! Dealer loses!\n");
            }
        }

        // Creates user-specified number of players and adds to '_players' list.
        private void AddPlayers()
        {
            _players = new List<Player>();

            for (var i = 0; i < _numPlayers; i++)
            {
                _players.Add(new Player());
            }
        }

        // Creates initial hand for all players and dealer.
        private void DealInitialHand()
        {
            for (var i = 0; i < NumCardsPerPlayer; i++)
            {
                foreach (var player in _players)
                {
                    player.AddCardToHand(_deckOfCards.DealCard());
                }

                _dealer.AddCardToHand(_deckOfCards.DealCard());
            }
        }

        // Prints hand values & ask if hit/stand. If blackjack, break. Gives card and prints value until bust, or player stands.
        private List<int> AskHitStand()
        {
            var playerNumber = 1;
            var playersHandValues = new List<int>();

            foreach (var player in _players)
            {
                var hit = true;
                var playerHand = player.GetHandOfCards();

                Console.WriteLine($"PLAYER {playerNumber}:\n");
                Console.WriteLine("Player Hand:");
                Console.Write(player.ToString());

                Console.WriteLine("Getting card values...\n");
                var handValue = ScoreHand(playerHand);
                Console.Write($"Hand value is: {handValue}\n\n");

                if (handValue == 21)
                {
                    Console.WriteLine("Blackjack!! Next player.\n");
                    playerNumber++;
                    continue;
                }

                while (hit)
                {
                    Console.Write("Do you want to hit or stand (H/S)? \nChoice: ");
                    var input = Console.ReadLine();
                    Console.WriteLine();

                    if (input == "H" || input == "h")
                    {
                        Console.WriteLine("Here is another card...\n");
                        playerHand = player.AddCardToHand(_deckOfCards.DealCard());
                        Console.WriteLine("New Player Hand:");
                        Console.Write(player.ToString());

                        handValue = ScoreHand(playerHand);
                        Console.Write($"Hand value is: {handValue}\n\n");

                        if (handValue > 21)
                        {
                            Console.WriteLine("Bust!! Next player.\n");
                            hit = false;
                        }

                        if (handValue == 21)
                        {
                            Console.WriteLine("Blackjack!! Next player.");
                            hit = false;
                        }
                    }
                    else if (input == "S" || input == "s")
                    {
                        Console.WriteLine("Ok, stand. Next player.\n");
                        hit = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }

                playersHandValues.Add(handValue);
                playerNumber++;
            }

            return playersHandValues;
        }
    }
}
