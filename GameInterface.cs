using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public sealed class GameInterface
    {
        private const int NumCardsPerPlayer = 2;
        private readonly CardDeck _deckOfCards;
        private readonly Dealer _dealer;

        private int _numPlayers;
        private List<Player> _players;

        static GameInterface()
        {
        }

        public static GameInterface Instance { get; } = new GameInterface();

        private GameInterface()
        {
            _deckOfCards = new CardDeck();
            _dealer = new Dealer();
        }

        // Initializes card game. Uses created deck, shuffles cards, and starts game.
        public void StartNewGame()
        {
            Console.WriteLine("Shuffling cards...\n");

            _deckOfCards.Shuffle();
            Console.WriteLine(_deckOfCards.ToString());
            Console.WriteLine();

            PlayGame();
        }

        // Acts as user interface to game of cards.
        private void PlayGame()
        {
            Console.Write("Please enter number of players: ");
            var playersIn = Console.ReadLine();
            int.TryParse(playersIn, out _numPlayers);

            AddPlayers();

            Console.WriteLine("Dealing cards...\n");
            DealInitialHand();

            CheckHitOrStand();
            PlayDealer();


            // TODO: Below...
            // TODO: Need DetermineWinners() method. 
            // TODO: Fix Ace logic.

            //List<Player> winners = new List<Player>();
            //foreach (var player in _players)
            //{
            //    // if playerHandValue < dealerHandValue
            //    //      dealer wins;
            //    //      Print "Dealer wins";
            //    // else
            //    //      player wins;
            //    //      winners.Add(player)
            //}

            //if (winners.Contains(null))
            //{
            //    Console.WriteLine("Dealer is the only winner.\n");
            //}

            //foreach (var w in winners)
            //{
            //    Console.Write($"Winners are: {w} \n");
            //}

            Console.Write("");
        }

        // Creates user-specified number of players and adds to '_players' list.
        public void AddPlayers()
        {
            _players = new List<Player>();

            for (var i = 0; i < _numPlayers; i++)
            {
                _players.Add(new Player());
            }
        }

        // Creates initial hand for all players and dealer.
        public void DealInitialHand()
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
        public void CheckHitOrStand()
        {
            var playerNumber = 1;

            foreach (var player in _players)
            {
                var hit = true;

                Console.WriteLine($"PLAYER NUMBER {playerNumber}\n");
                Console.WriteLine("Player Hand:");
                Console.Write(player.ToString());

                Console.WriteLine("Getting card values...");
                var handValue = player.GetHandValue();
                Console.Write($"Hand value is: {handValue}\n\n");

                if (handValue == 21)
                {
                    Console.WriteLine("Blackjack!! You win. Next player.");
                    continue;
                }

                while (hit)
                {
                    Console.Write("Do you want to hit or stand (H/S)? \nChoice: ");
                    var input = Console.ReadLine();

                    if (input == "H" || input == "h")
                    {
                        Console.WriteLine("Here is another card...\n");
                        player.AddCardToHand(_deckOfCards.DealCard());
                        Console.WriteLine("New Player Hand:");
                        Console.Write(player.ToString());

                        handValue = player.GetHandValue(); // TODO: Change to correct method/class etc...
                        Console.Write($"Hand value is: {handValue}\n\n");

                        if (handValue > 21)
                        {
                            Console.WriteLine("Bust!! You lose. Next player.\n");
                            hit = false;
                        }
                    }
                    else if (input == "S" || input == "s")
                    {
                        Console.WriteLine("Ok, stand. Next player.\n");
                        hit = false;
                    }
                }
                playerNumber++;
            }
        }

        // Plays dealer's game. Hits on soft 17 (with Ace). Plays until bust or stand on > 17.
        public void PlayDealer()
        {
            Console.WriteLine($"DEALER: \n");
            Console.WriteLine("Dealer Hand:");
            Console.Write(_dealer.ToString());
            var handValues = _dealer.GetHandValue();
            Console.Write($"Hand value is: {handValues}\n\n");

            if (handValues == 21)
            {
                Console.WriteLine("Blackjack!!");
            }
            else if (handValues > 21)
            {
                Console.WriteLine("Dealer busts! Dealer loses! \n");
            }
            else if (handValues > 17 && handValues < 21)
            {
                Console.WriteLine("Dealer stands");
            }

            while (handValues > 0 && handValues < 18)
            {
                Console.WriteLine("Dealer hits...\n");
                _dealer.AddCardToHand(_deckOfCards.DealCard());

                Console.WriteLine("New Dealer Hand:");
                Console.Write(ToString());

                handValues = _dealer.GetHandValue();
                Console.Write($"Hand value is: {handValues}\n\n");
            }
        }

    }
}












//private void PlayGame(CardDeck deckOfCardsIn)
//{
//    _deckOfCards = deckOfCardsIn;

//    Console.Write("Please enter number of players: ");
//    var playersIn = Console.ReadLine();
//    int.TryParse(playersIn, out _numPlayers);
//    _dealer.AddPlayers();

//    Console.WriteLine("Dealing cards...\n");
//    _dealer.DealInitialHand();

//    CheckHitOrStand();

//    DealerGame();

//    // TODO: Below...

//    //List<Player> winners = new List<Player>();
//    //foreach (var player in playersAtTable)
//    //{
//    //    // if playerHandValue < dealerHandValue
//    //    //      dealer wins;
//    //    //      Print "Dealer wins";
//    //    // else
//    //    //      player wins;
//    //    //      winners.Add(player)
//    //}

//    //if (winners.Contains(null))
//    //{
//    //    Console.WriteLine("Dealer is the only winner.\n");
//    //}

//    //foreach (var w in winners)
//    //{
//    //    Console.Write($"Winners are: {w} \n");
//    //}

//    Console.Write("");
//}