using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public class CardDeck
    {
        private const int numCardsInDeck = 52;
        private const int numberOfCardType = 4;
        private const int numberOfCardRank = 13;

        private List<Card> deck;
        private Card card;
        private int currentCard;
        private Random shuffle = new Random();

        public CardDeck()
        {
            CreateDeck();
        }

        // Creates deck of cards.
        private void CreateDeck()
        {
            deck = new List<Card>();
            
            for (int suit = 0; suit < numberOfCardType; suit++)
            {
                for (int rank = 1; rank <= numberOfCardRank; rank++)
                {
                    card = new Card((Card.CardRank) rank, (Card.CardType) suit);
                    deck.Add(card);
                }
            }
        }

        // Shuffle deck of cards by using Random() and swapping items in list with each other.
        public void Shuffle()
        {
            for (var i = deck.Count() - 1; i > 0; i--)
            {
                var count = shuffle.Next(i + 1);
                var temp = deck[count];
                deck[count] = deck[i];
                deck[i] = temp;
            }
        }

        // Deals a single card to player/dealer.
        public Card DealCard()
        {
            if (currentCard > numCardsInDeck)
            {
                Console.WriteLine("No cards left in deck.");
                return null;
            }

            return deck[currentCard++];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var card in deck)
            {
                sb.AppendFormat("{0} of {1} \n", card.rank, card.suit);
            }
            sb.Append("\n");

            return sb.ToString();
        }
    }
}
