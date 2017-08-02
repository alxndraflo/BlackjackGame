using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.CardGame
{
    public class Player
    {
        private List<Card> _handOfCards;

        // Adds a card to _handOfCards.
        public List<Card> AddCardToHand(Card card)
        {
            if (_handOfCards == null)
            {
                _handOfCards = new List<Card>();
            }

            _handOfCards.Add(card);

            return _handOfCards;
        }

        // Returns hand of cards.
        public List<Card> GetHandOfCards()
        {
            List<Card> handOfCards = new List<Card>(_handOfCards);
            return handOfCards;
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
