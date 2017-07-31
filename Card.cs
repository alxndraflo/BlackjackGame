using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public class Card
    {
        // Assigns card suits.
        public enum CardType
        {
            Clubs, Diamonds, Hearts, Spades
        }

        // Assigns card ranks.
        public enum CardRank
        {
            Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }

        public readonly CardType suit;
        public readonly CardRank rank;

        public Card(CardRank rankIn, CardType suitIn)
        {
            suit = suitIn;
            rank = rankIn;
        }

        // Assigns card value based on suit. Returns list of ints based on type of card.
        public List<int> GetCardValue()
        {
            switch (rank)
            {
                case CardRank.Jack:
                case CardRank.Queen:
                case CardRank.King:
                    return new List<int> { 10 };
                case CardRank.Ace:
                    return new List<int> { 1 }; // TODO: ***Add 11 back in***
                default:
                    return new List<int> { (int)rank };
            }
        }
    }
}
