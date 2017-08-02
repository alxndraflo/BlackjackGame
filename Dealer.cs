using System;
using System.Collections.Generic;

namespace CodingChallenges.CardGame
{
    public class Dealer : Player
    {
        private List<Card> _handOfCards;
        private readonly CardDeck _deckOfCards;

        public Dealer(CardDeck deckOfCardsIn)
        {
            _deckOfCards = deckOfCardsIn;
        }

        // Plays dealer's game. Hits on 17. Plays until bust or stand on > 17.
        public int PlayDealer()
        {
            _handOfCards = GetHandOfCards();

            Console.WriteLine($"DEALER \n");
            Console.WriteLine("Dealer Hand:");
            Console.Write(_handOfCards.ToString());
            var handValue = BlackjackGame.Instance.ScoreHand(_handOfCards);
            Console.Write($"Hand value is: {handValue}\n\n");

            while (handValue > 0 && handValue < 17)
            {
                Console.WriteLine("Dealer hits...\n");
                _handOfCards = AddCardToHand(_deckOfCards.DealCard());

                Console.WriteLine("New Dealer Hand:");
                Console.Write(_handOfCards.ToString());

                handValue = BlackjackGame.Instance.ScoreHand(_handOfCards);
                Console.Write($"Hand value is: {handValue}\n\n");
            }

            if (handValue == 21)
            {
                Console.WriteLine("Blackjack!!\n");
            }

            if (handValue > 21)
            {
                Console.WriteLine("Dealer busts! \n");
            }

            if (handValue > 16 && handValue < 21)
            {
                Console.WriteLine("Dealer stands.\n");
            }

            return handValue;
        }
    }
}