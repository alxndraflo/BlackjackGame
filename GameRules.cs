using System.Collections.Generic;

namespace CodingChallenges.CardGame
{
    public abstract class GameRules
    {
        // Get and add card values in handOfCards. Returns an int set to total value of handOfCards.
        public int ScoreHand(List<Card> handOfCards)
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
                    handValue -= 10; // Or something like this...? handValue = handValue - (aceCounter * (10))
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