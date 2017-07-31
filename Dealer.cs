using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public class Dealer : Player
    {
        private List<Card> _handOfCards;

        public Dealer()
        {
        }

        //private void PrintDealerHand()
        //{
        //    foreach (var c in _handOfCards)
        //    {
        //        Console.WriteLine($"{c.rank} of {c.suit}");
        //    }
        //    Console.WriteLine();
        //}


        //private int GetDealerHandValue()
        //{
        //    List<int> cardValues = new List<int>();
        //    int dealerHandValue = 0;

        //    var index = 0;
        //    foreach (var card in _handOfCards)
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



        //// Prints hand values & ask if hit/stand. If blackjack, break. Gives card and prints value until bust, or player stands.
        //public override void CheckHitOrStand()
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
        //                p.AddCardToHand(_deckOfCards.DealCard());
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