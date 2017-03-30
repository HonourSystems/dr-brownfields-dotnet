using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrBrownfields {
    public class Deck {

        public Deck() {
            Initialize();
        }

        public void Shuffle() {
            var r = new Random();
            for(int i = 0; i < 100; ++i) {
                Swap(r.Next(52), r.Next(52));
            }
        }

        public Card Deal() {
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        private void Initialize() {
            cards.Clear();
            for(Suit suit = Suit.Clubs; suit <= Suit.Spades; ++suit) {
                for(Rank rank = Rank.Two; rank <= Rank.Ace; ++rank) {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        private void Swap(int lowerIndex, int upperIndex) {
            var cardCount = cards.Count;
            if(lowerIndex != upperIndex && lowerIndex >= 0 && upperIndex >= 0 && lowerIndex <= --cardCount && upperIndex <= --cardCount) {
                var temp = cards[lowerIndex];
                cards[lowerIndex] = cards[upperIndex];
                cards[upperIndex] = temp;
            }
        }

        private List<Card> cards = new List<Card>();
    }
}
