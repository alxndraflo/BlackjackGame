using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.CardGame
{
    public class CardDeck
    {
        private const int NumCardsInDeck = 52;
        private const int NumOfCardType = 4;
        private const int NumOfCardRank = 13;

        private List<Card> _deck;
        private Card _card;
        private int _currentCard;
        private readonly Random _shuffle = new Random();

        public CardDeck()
        {
            CreateDeck();
        }

        // Creates _deck of cards.
        private void CreateDeck()
        {
            _deck = new List<Card>();
            
            for (int suit = 0; suit < NumOfCardType; suit++)
            {
                for (int rank = 1; rank <= NumOfCardRank; rank++)
                {
                    _card = new Card((Card.CardRank) rank, (Card.CardType) suit);
                    _deck.Add(_card);
                }
            }
        }

        // Shuffle _deck of cards by using Random() and swapping items in list with each other.
        public void Shuffle()
        {
            for (var i = _deck.Count() - 1; i > 0; i--)
            {
                var count = _shuffle.Next(i + 1);
                var temp = _deck[count];
                _deck[count] = _deck[i];
                _deck[i] = temp;
            }
        }

        // Deals a single _card to player/dealer.
        public Card DealCard()
        {
            if (_currentCard > NumCardsInDeck)
            {
                Console.WriteLine("No cards left in _deck.");
                return null;
            }

            return _deck[_currentCard++];
        }

        // Prints deck of cards.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var card in _deck)
            {
                sb.AppendFormat("{0} of {1} \n", card.rank, card.suit);
            }

            sb.Append("\n");

            return sb.ToString();
        }
    }
}
