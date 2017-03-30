using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrBrownfields {
    public class Hand {
        
        public void AddCard(Card card) {
            cards.Add(card);
            CalculateBestRanking();
        }

        public void ExchangeCard(int oldCardIndex, Card newCard) {
            if(oldCardIndex >= 0 || oldCardIndex <= cards.Count) {
                var card = cards[oldCardIndex];
                cards.RemoveAt(oldCardIndex);
                cards.Insert(oldCardIndex, newCard);
                CalculateBestRanking();
            }
        }

        public IReadOnlyList<Card> Cards {
            get {
                return new ReadOnlyCollection<Card>(cards);
            }
        }

        public Ranking BestRanking { get; private set; }

        private void CalculateBestRanking() {
            if(cards.Count < 5) {
                return;
            }
            var sc = cards.OrderBy(e => e.Rank).ToList();
            if(IsFlush(sc) && IsStraight(sc)) {
                if(sc[4].Rank == Rank.Ace) {
                    BestRanking = Ranking.RoyalFlush;
                }
                else {
                    BestRanking = Ranking.StraightFlush;
                }
            }
            else if(IsThreeOfAKind(sc, 1, 2, 3) && (IsPair(sc, 0, 1) || IsPair(sc, 3, 4))) {
                BestRanking = Ranking.FourOfAKind;
            }
            else if(IsPair(sc, 0, 1) && IsThreeOfAKind(sc, 2, 3, 4) || IsPair(sc, 3, 4) && IsThreeOfAKind(sc, 0, 1, 2)) {
                BestRanking = Ranking.FullHouse;
            }
            else if(IsFlush(sc)) {
                BestRanking = Ranking.Flush;
            }
            else if(IsStraight(sc)) {
                BestRanking = Ranking.Straight;
            }
            else if(IsThreeOfAKind(sc, 0, 1, 2) || IsThreeOfAKind(sc, 1, 2, 3) || IsThreeOfAKind(sc, 2, 3, 4)) {
                BestRanking = Ranking.ThreeOfAKind;
            }
            else if(IsPair(sc, 0, 1) && IsPair(sc, 2, 3) || IsPair(sc, 0, 1) && IsPair(sc, 3, 4) || IsPair(sc, 1, 2) && IsPair(sc, 3, 4)) {
                BestRanking = Ranking.TwoPair;
            }
            else if(IsPair(sc, 0, 1) || IsPair(sc, 1, 2) || IsPair(sc, 2, 3) || IsPair(sc, 3, 4)) {
                BestRanking = Ranking.Pair;
            }
            else {
                BestRanking = Ranking.Nothing;
            }
        }

        private static bool IsThreeOfAKind(IList<Card> c, int index1, int index2, int index3) {
            return IsPair(c, index1, index2) && IsPair(c, index2, index3);
        }

        private static bool IsPair(IList<Card> c, int index1, int index2) {
            return c[index1].Rank == c[index2].Rank;
        }

        private static bool IsFlush(IList<Card> c) {
            return c[0].Suit == c[1].Suit && c[1].Suit == c[2].Suit && c[2].Suit == c[3].Suit && c[3].Suit == c[4].Suit;
        }

        private static bool IsStraight(IList<Card> c) {
            return c[0].Rank == c[1].Rank - 1 && c[1].Rank == c[2].Rank - 1 && c[2].Rank == c[3].Rank - 1 && c[3].Rank == c[4].Rank - 1;
        }

        private List<Card> cards = new List<Card>();
    }
}
