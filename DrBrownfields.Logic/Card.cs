using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrBrownfields {
    public class Card {
        public Card(Rank rank, Suit suit) {
            Rank = rank;
            Suit = suit;
        }

        public Rank Rank { get; private set; }

        public Suit Suit { get; private set; }
    }
}
