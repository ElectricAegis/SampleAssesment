using System.Collections.Generic;
using BlackJack21App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack21
{
    [TestClass]
    public class BlackJack21Tests
    {
        [TestMethod]
        public void PlayersWithHandsHigherThanDealerWin()
        {
            //Given
            var playerHands = new Dictionary<string, List<string>>
            {
                {"Dealer",new List<string> {"Six of Clubs", "Nine of Clubs"} },
                {"Billy",new List<string> {"Queen of Diamonds", "King of Clubs"} },
                {"Andrew",new List<string> {"Nine of Hearts", "Six of Clubs", "Jack of Hearts"} },
                {"Carla",new List<string> {"Two of Clubs", "Nine of Diamonds", "King of Clubs"} }
            };

            var blackJackEvaluator = new BlackJackEvaluator();

            //When
            var winners = blackJackEvaluator.Evaluate(playerHands);

            //Then
            CollectionAssert.AreEquivalent(new List<string> { "Billy","Carla" }, winners);
        }

        [TestMethod]
        public void PlayerWithFiveCardsUnder21BeatsDealer()
        {
            //Given
            var playerHands = new Dictionary<string, List<string>>
            {
                {"Dealer",new List<string> {"Jack of Spades", "Seven of Diamonds"} },
                {"Billy",new List<string> {"Two of Spades", "Two of Diamonds","Two of Hearts","Four of Diamonds","Five of Clubs"} },
                {"Andrew",new List<string> {"King of Diamonds", "Four of Spades", "Four of Clubs"} },
                {"Carla",new List<string> {"Queen of Clubs", "Six of Spades", "Nine of Diamonds"} } 
            };

            var blackJackEvaluator = new BlackJackEvaluator();

            //When
            var winners = blackJackEvaluator.Evaluate(playerHands);

            //Then
            CollectionAssert.AreEquivalent(new List<string> {"Andrew","Billy"}, winners);
        }

        [TestMethod]
        public void PlayerWithAceChoosesNotToGoOver21()
        {
            //Given
            var playerHands = new Dictionary<string, List<string>>
            {
                {"Dealer",new List<string> {"Six of Clubs", "Nine of Clubs"} },
                {"Billy",new List<string> {"Queen of Diamonds", "King of Clubs"} },
                {"Andrew",new List<string> {"Nine of Hearts", "Six of Clubs", "Ace of Spades"} },
                {"Carla",new List<string> {"Two of Clubs", "Nine of Diamonds", "King of Clubs"} }
            };

            var blackJackEvaluator = new BlackJackEvaluator();

            //When
            var winners = blackJackEvaluator.Evaluate(playerHands);

            //Then
            CollectionAssert.AreEquivalent(new List<string> { "Andrew", "Billy", "Carla" }, winners);
        }
    }
}
