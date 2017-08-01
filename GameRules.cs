using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public abstract class GameRules
    {
        //private List<Card> _handOfCards;
        //private List<Player> _players;


        // Get and add card values in handOfCards. Returns an int set to total value of handOfCards.
        public int ScoreHand(List<Card> handOfCards) // TODO: Add null check***
        {
            var aceCounter = 0;
            var handValue = 0;

            foreach (var card in handOfCards)
            {
                var cardValue = GetCardValue(card);

                if (card.rank.Equals(Card.CardRank.Ace))
                {
                    aceCounter++;
                }
                handValue += cardValue;
            }

            while (handValue > 21 && aceCounter > 0)
            {
                for (var i = 0; i < aceCounter; i++)
                {
                    handValue -= 10;
                    aceCounter--;

                    if (handValue < 21)
                    {
                        break;
                    }
                }
            }
            return handValue;
        }

        public int GetCardValue(Card card)
        {
            switch (card.rank)
            {
                case Card.CardRank.Jack:
                case Card.CardRank.Queen:
                case Card.CardRank.King:
                    return 10;
                case Card.CardRank.Ace:
                    return 11;
                default:
                    return (int) card.rank;
            }
        }
    }
}




//public void ScoreHand(List<Card> handOfCards)
//{
//    List<int> allHandValues = new List<int>();
//    int handValue = 0;
//    int singleCard = 0;
//    var index = 0;

//    if (handOfCards == null && handOfCards.Count == 0)
//    {
//        Console.WriteLine("Null hand of cards passed.");
//    }
//    else
//    {
//        handOfCards = new List<Card>(handOfCards);
//    }

//    foreach (var card in handOfCards)
//    {
//        List<int> cardValue = GetCardValue(card);

//        if (cardValue != null && cardValue.Count != 0)
//        {
//            allHandValues.Add(cardValue[index]);
//            index++;
//        }

//        foreach (var val in allHandValues)
//        {
//            while (card.rank == Card.CardRank.Ace)
//            {
//                singleCard = cardValue[0];

//                if (singleCard > 21)
//                {
//                    singleCard = cardValue[1]
//                }
//            }
//            handValue += val;
//        }

//    }
//}