using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public class Player
    {
        private List<Card> _handOfCards;

        // Adds a card to player or dealer's hand.
        public List<Card> AddCardToHand(Card card)
        {
            if (_handOfCards == null)
            {
                _handOfCards = new List<Card>();
            }

            _handOfCards.Add(card);

            return _handOfCards;
        }

        public List<Card> GetHandOfCards()
        {
            List<Card> handOfCards = new List<Card>(_handOfCards);
            return handOfCards;
        }

        //public int GetHandValue()
        //{
        //    var handValue = ScoreHand
        //    return handValue;
        //}


        // TODO: Complete logic for method
        public bool IsWinner()
        {
            return false;
        }

        // Prints hand of cards.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var card in _handOfCards)
            {
                sb.AppendFormat($"{card.rank} of {card.suit}\n");
            }
            sb.Append("\n");

            return sb.ToString();
        }

    }
}
