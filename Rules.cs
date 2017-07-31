using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.CardGame
{
    public abstract class Rules
    {
        private List<Card> handOfCards;
        private int singleCardValue;
        private List<int> cardValues;

        // Assigns card value based on suit. Returns list of ints based on type of card.
        public List<int> GetCardValue()
        {
            switch (rank)
            {
                case Card.CardRank.Jack:
                case Card.CardRank.Queen:
                case Card.CardRank.King:
                    return new List<int> { 10 };
                case Card.CardRank.Ace:
                    return new List<int> { 1 }; // TODO: ***Add 11 back in***
                default:
                    return new List<int> { (int)rank };
            }
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
    }
}
