using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrBrownfields {
    public class Game {

        public Game() {
            Stake = 100;
            Bet = 5;
            Win = 0;
        }

        public int Stake { get; private set; }

        public int Bet { get; private set; }

        public int Win { get; private set; }

        public Hand Hand { get; private set; }

        private Deck deck;

        public void Deal() {
            deck = new Deck();
            Hand = new Hand();
            deck.Shuffle();
            for(int i = 0; i < 5; ++i) {
                Hand.AddCard(deck.Deal());
            }
            Stake -= Bet;
            Win = (int)Hand.BestRanking;
        }

        public void Draw(int[] cardIndexes) {
            foreach(var index in cardIndexes) {
                Hand.ExchangeCard(index, deck.Deal());
            }
            Win = (int)Hand.BestRanking;
            Stake += Win;
        }

    }
}
