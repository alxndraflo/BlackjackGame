using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.CardGame
{
    public sealed class GameInterface
    {
        private Dealer _dealer;

        static GameInterface()
        {
        }

        public static GameInterface Instance { get; } = new GameInterface();

        private GameInterface()
        {
        }

        public void StartNewGame()
        {
            _dealer = new Dealer();
            _dealer.CreateGame();
        }




    }
}












//private void PlayGame(CardDeck deckOfCardsIn)
//{
//    _deckOfCards = deckOfCardsIn;

//    Console.Write("Please enter number of players: ");
//    var playersIn = Console.ReadLine();
//    int.TryParse(playersIn, out _numPlayers);
//    _dealer.AddPlayers();

//    Console.WriteLine("Dealing cards...\n");
//    _dealer.DealInitialHand();

//    CheckHitStand();

//    DealerGame();

//    // TODO: Below...

//    //List<Player> winners = new List<Player>();
//    //foreach (var player in playersAtTable)
//    //{
//    //    // if playerHandValue < dealerHandValue
//    //    //      dealer wins;
//    //    //      Print "Dealer wins";
//    //    // else
//    //    //      player wins;
//    //    //      winners.Add(player)
//    //}

//    //if (winners.Contains(null))
//    //{
//    //    Console.WriteLine("Dealer is the only winner.\n");
//    //}

//    //foreach (var w in winners)
//    //{
//    //    Console.Write($"Winners are: {w} \n");
//    //}

//    Console.Write("");
//}