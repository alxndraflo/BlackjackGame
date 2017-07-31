using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    class Player 
    {
        private List<Card> _handOfCards;


        public Player()
        {
        }

        // Adds a card to player or dealer's hand.
        public void AddCard(Card card)
        {
            if (_handOfCards == null)
            {
                _handOfCards = new List<Card>();
            }

            _handOfCards.Add(card);
        }


        // Get and add card values in _handOfCards. Returns an int set to total value of _handOfCards.
        public int GetHandValue()
        {
            List<int> cardValues = new List<int>();
            int handValue = 0;

            int index = 0;
            foreach (var card in _handOfCards)
            {
                List<int> singleCardValue = card.GetCardValue();

                if (singleCardValue != null && singleCardValue.Count != 0)
                {
                    cardValues.Add(singleCardValue[index]);
                }
            }

            foreach (var val in cardValues)
            {
                handValue += val;
            }

            return handValue;
        }

        // TODO: Finish Ace logic and move to correct class
        //private int CheckIfAce(List<Card> handOfCardsIn)
        //{
        //    List<Card> handOfCards = handOfCardsIn;

        //    if (handOfCards.Contains())

        //    return 0;
        //}


        // TODO: Finish logic for winner method.
        public bool IsWinner()
        {
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in _handOfCards)
            {
                sb.AppendFormat($"{c.rank} of {c.suit}\n");
            }
            sb.Append("\n");

            return sb.ToString();
        }
    }
}





// Prints hand values & ask if hit/stand. If blackjack, break. Gives card and prints value until bust, or player stands.
//public override void CheckHitStand()
//{

//    var playerNumber = 1;

//    foreach (var p in playersAtTable)
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
//                p.AddCard(deckOfCards.DealCard());
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