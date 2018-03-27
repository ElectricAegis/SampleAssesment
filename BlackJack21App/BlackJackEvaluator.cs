using System;
using System.Collections.Generic;
using System.Media;

namespace BlackJack21App
{
    public class BlackJackEvaluator
    {

        private Dictionary<string, int> _cardSymbols = new Dictionary<string, int>()
        {
            {"Ace", 1 },
            {"Two", 2 },
            {"Three", 3 },
            {"Four", 4 },
            {"Five", 5 },
            {"Six", 6 },
            {"Seven", 7 },
            {"Eight", 8 },
            {"Nine", 9 },
            {"Ten", 10 },
            {"King", 10 },
            {"Queen", 10 },
            {"Jack", 10 },
        };

        public List<string> Evaluate(Dictionary<string, List<string>> playerHands)
        {
            throw new NotImplementedException();
        }

        public List<string> PlayersWithHandsHigherThanDealerWin(Dictionary<string, List<string>> playerHands)
        {
            List<string> winners = new List<string>();
            Dictionary<string, int> playerTotals = new Dictionary<string, int>();

            var sum = 0;
            var player = "";

            foreach (var playerHand in playerHands)
            {
                var cardsInHand = playerHands[playerHand.Key];
                foreach (var cardInHand in cardsInHand)
                {
                    foreach (var cardSymbol in this._cardSymbols.Keys)
                    {
                        if (cardInHand.Contains(cardSymbol))
                        {
                            player = playerHand.Key;
                            sum += this._cardSymbols[cardSymbol];
                            playerTotals.Add(player,sum);
                        }
                    }
                }

                Console.WriteLine("Player:{0} - Sum:{1} ", player, sum);
                sum = 0;
            }

            foreach (var playerTotal in playerTotals)
            {
                var PlayerHandCount = playerHands[playerTotal.Key].Count;
                var DealerHandCount = playerHands["Dealer"].Count;

                if (PlayerHandCount > DealerHandCount)
                {
                    if (playerTotals[playerTotal.Key] > playerTotals["Dealer"])
                        winners.Add(playerTotal.Key);
                }
            }


            return winners;
        }


        public List<string> PlayerWithFiveCardsUnder21BeatsDealer(Dictionary<string, List<string>> playerHands)
        {

            List<string> winners = new List<string>();
            Dictionary<string, int> playerTotals = new Dictionary<string, int>();

            var sum = 0;
            var player = "";

            foreach (var playerHand in playerHands)
            {
                var cardsInHand = playerHands[playerHand.Key];
                foreach (var cardInHand in cardsInHand)
                {
                    foreach (var cardSymbol in this._cardSymbols.Keys)
                    {
                        if (cardInHand.Contains(cardSymbol))
                        {
                            player = playerHand.Key;
                            sum += this._cardSymbols[cardSymbol];
                            playerTotals.Add(player, sum);
                        }
                    }
                }

                Console.WriteLine("Player:{0} - Sum:{1} ", player, sum);
                if(playerHands[player].Count == 5 && playerTotals[player] < 21)
                    winners.Add(player);

                sum = 0;
            }

            return winners;
        }

        public List<string> PlayerWithAceChoosesNotToGoOver21(Dictionary<string, List<string>> playerHands)
        {

            List<string> winners = new List<string>();
            Dictionary<string, int> playerTotals = new Dictionary<string, int>();

            var sum = 0;
            var player = "";

            foreach (var playerHand in playerHands)
            {
                var cardsInHand = playerHands[playerHand.Key];
                foreach (var cardInHand in cardsInHand)
                {
                    foreach (var cardSymbol in this._cardSymbols.Keys)
                    {
                        if (cardInHand.Contains(cardSymbol))
                        {
                            player = playerHand.Key;
                            sum += this._cardSymbols[cardSymbol];
                            playerTotals.Add(player, sum);
                        }
                    }
                }
                sum = 0;
            }

            return new List<string>();
        }



    }
}