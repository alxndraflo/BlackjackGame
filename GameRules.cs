using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public abstract class GameRules
    {
        private List<Card> _handOfCards = new List<Card>();
        private List<Player> _players;

        protected GameRules()
        {
            //_handOfCards = handOfCardsIn;
        }

        // TODO: Figure out Ace logic!!*****
        // Get and add card values in handOfCards. Returns an int set to total value of handOfCards.
        public int GetHandValue() // ***Or return type List<int>***
        {
            List<int> allHandValues = new List<int>();
            int handValue = 0;
            var index = 0;

            foreach (var card in _handOfCards)
            {
                List<int> cardValue = card.GetCardValue();

                if (cardValue != null && cardValue.Count != 0)
                {
                    allHandValues.Add(cardValue[index]);
                    index++;
                }
            }

            foreach (var val in allHandValues)
            {
                handValue += val;
            }

            return handValue;
        }

        public List<int> GetCardValue()
        {
            Card card;

            switch (card)
            {
                case Card.CardRank.Jack:
                case Card.CardRank.Queen:
                case Card.CardRank.King:
                    return new List<int> { 10 };
                case Card.CardRank.Ace:
                    return new List<int> { 1 }; // TODO: ***Add 11 back in***
                default:
                    return new List<int> { (int) card };
            }
        }

    }
}
