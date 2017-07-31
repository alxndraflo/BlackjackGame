using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    class Human : Player
    {
        private List<Card> _handOfCards;

        public void AddCardToHand(Card card)
        {
            if (_handOfCards == null)
            {
                _handOfCards = new List<Card>();
            }

            _handOfCards.Add(card);
        }
    }
}
