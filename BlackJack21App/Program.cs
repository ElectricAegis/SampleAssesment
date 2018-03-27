using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21App
{
    class Program
    {
        static void Main(string[] args)
        {
            var evaluator = new BlackJackEvaluator();
            var playerHands = new Dictionary<string, List<string>>
            {
                {"Dealer",new List<string> {"Six of Clubs", "Nine of Clubs"} },
                {"Billy",new List<string> {"Queen of Diamonds", "King of Clubs"} },
                {"Andrew",new List<string> {"Nine of Hearts", "Six of Clubs", "Jack of Hearts"} },
                {"Carla",new List<string> {"Two of Clubs", "Nine of Diamonds", "King of Clubs"} }
            };

            foreach(var player in evaluator.PlayersWithHandsHigherThanDealerWin(playerHands))
            {
                Console.WriteLine(player);
            }

            Console.Read();

        }
    }
}
