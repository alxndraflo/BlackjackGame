using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public class Dealer
    {
        private const int NumCardsPerPlayer = 2;

        private readonly CardDeck _deckOfCards;
        private int _numPlayers;
        private List<Player> _players;
        private List<Card> _dealerHand;

        public Dealer()
        {
            _deckOfCards = new CardDeck();
        }

        // Initializes card game. Uses created deck, shuffles cards, and starts game.
        public void CreateGame()
        {
            Console.WriteLine("I will now shuffle the cards.\n");

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

            // CheckHitOrStand();

            //DealerGame();

            // TODO: Below...

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
                foreach (var p in _players)
                {
                    p.AddCard(_deckOfCards.DealCard());
                }

                if (_dealerHand == null)
                {
                    _dealerHand = new List<Card>();
                }

                _dealerHand.Add(_deckOfCards.DealCard());
            }
        }

        private void CheckHitOrStand()
        {
            var hit = true;

            while (hit)
            {
                Console.Write("Do you want to hit or stand (H/S)? \nChoice: ");
                var input = Console.ReadLine();

                if (input == "H" || input == "h")
                {
                    Console.WriteLine("Here is another card...\n");
                    p.AddCard(deckOfCards.DealCard());
                    Console.WriteLine("New Player Hand:");
                    Console.Write(p.ToString());

                    playerHandValue = p.GetHandValue();
                    Console.Write($"Hand value is: {playerHandValue}\n\n");

                    if (playerHandValue > 21)
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in _dealerHand)
            {
                sb.AppendFormat($"{c.rank} of {c.suit}\n");
            }
            sb.Append("\n");

            return sb.ToString();
        }

            //private void DealerGame()
            //{
            //    Console.WriteLine($"DEALER: \n");
            //    Console.WriteLine("Dealer Hand:");
            //    PrintDealerHand();
            //    var handValues = GetDealerHandValue();
            //    Console.Write($"Hand value is: {handValues}\n\n");

            //    if (handValues == 21)
            //    {
            //        Console.WriteLine("Blackjack!!");
            //    }

            //    while (handValues > 0 && handValues < 18)
            //    {
            //        Console.WriteLine("Dealer hits...\n");
            //        _dealerHand.Add(_deckOfCards.DealCard());

            //        Console.WriteLine("New Dealer Hand:");
            //        PrintDealerHand();

            //        handValues = GetDealerHandValue();
            //        Console.Write($"Hand value is: {handValues}\n\n");
            //    }

            //    if (handValues > 21)
            //    {
            //        Console.WriteLine("Dealer busts! Dealer loses! \n");
            //    }
            //}

            //private int GetDealerHandValue()
            //{
            //    List<int> cardValues = new List<int>();
            //    int dealerHandValue = 0;

            //    var index = 0;
            //    foreach (var card in _dealerHand)
            //    {
            //        List<int> singleCardValue = card.GetCardValue();

            //        if (singleCardValue != null && singleCardValue.Count != 0)
            //        {
            //            cardValues.Add(singleCardValue[index]);
            //        }
            //    }

            //    foreach (var val in cardValues)
            //    {
            //        dealerHandValue += val;
            //    }

            //    return dealerHandValue;
            //}

            //private void PrintDealerHand()
            //{
            //    foreach (var c in _dealerHand)
            //    {
            //        Console.WriteLine($"{c.rank} of {c.suit}");
            //    }
            //    Console.WriteLine();
            //}

            //// Prints hand values & ask if hit/stand. If blackjack, break. Gives card and prints value until bust, or player stands.
            //public override void CheckHitStand()
            //{
            //    var playerNumber = 1;

            //    foreach (var p in _players)
            //    {
            //        var hit = true;

            //        Console.WriteLine($"PLAYER NUMBER {playerNumber}\n");
            //        Console.WriteLine("Player Hand:");
            //        Console.Write(p.ToString());

            //        Console.WriteLine("Getting card values...");
            //        var playerHandValue = p.GetHandValue();
            //        Console.Write($"Hand value is: {playerHandValue}\n\n");

            //        if (playerHandValue == 21)
            //        {
            //            Console.WriteLine("Blackjack!! You win. Next player.");
            //            continue;
            //        }

            //        while (hit)
            //        {
            //            Console.Write("Do you want to hit or stand (H/S)? \nChoice: ");
            //            var input = Console.ReadLine();

            //            if (input == "H" || input == "h")
            //            {
            //                Console.WriteLine("Here is another card...\n");
            //                p.AddCard(_deckOfCards.DealCard());
            //                Console.WriteLine("New Player Hand:");
            //                Console.Write(p.ToString());

            //                playerHandValue = p.GetHandValue();
            //                Console.Write($"Hand value is: {playerHandValue}\n\n");

            //                if (playerHandValue > 21)
            //                {
            //                    Console.WriteLine("Bust!! You lose. Next player.\n");
            //                    hit = false;
            //                }
            //            }
            //            else if (input == "S" || input == "s")
            //            {
            //                Console.WriteLine("Ok, stand. Next player.\n");
            //                hit = false;
            //            }
            //        }
            //        playerNumber++;
            //    }
            //}
        }

}


//// Creates dealer's initial hand. ***Duplicate code to function in Player class.***
//private void MakeDealerHand()
//{
//    if (dealerHand == null)
//    {
//        dealerHand = new List<Card>();
//    }

//    dealerHand.Add(deckOfCards.DealCard());
//}


//foreach (var c in playerHand)
//{
//    Console.Write($"{c.rank} of {c.suit}\n");
//}