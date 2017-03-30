using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DrBrownfields.UI {
    public partial class VideoPoker : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            cardImages = new HtmlImage[] { Card1, Card2, Card3, Card4, Card5 };
            checkboxes = new HtmlInputCheckBox[] { Hold1, Hold2, Hold3, Hold4, Hold5 };
            Draw.Visible = false;
        }

        private HtmlImage[] cardImages;
        private HtmlInputCheckBox[] checkboxes;

        protected void Deal_ServerClick(object sender, EventArgs e) {
            Game.Deal();
            Update(false);
        }

        protected void Draw_ServerClick(object sender, EventArgs e) {
            var exchange = new List<int>();
            for(int i = 0; i < 5; ++i) {
                if(!checkboxes[i].Checked) {
                    exchange.Add(i);
                }
            }
            Game.Draw(exchange.ToArray());
            Update(true);
        }

        private void Update(bool dealEnabled) {
            var cards = Game.Hand.Cards;
            for(int i = 0; i < 5; ++i) {
                cardImages[i].Src = String.Format("Images/{0}{1}.png", cards[i].Rank, cards[i].Suit);
            }
            Stake.InnerText = Game.Stake.ToString();
            Bet.InnerText = Game.Bet.ToString();
            Win.InnerText = Game.Win.ToString();
            foreach(var checkbox in checkboxes) {
                checkbox.Checked = false;
                checkbox.Disabled = dealEnabled;
            }
            Draw.Visible = !dealEnabled;
            Deal.Visible = dealEnabled;
            currentRanking.InnerText = String.Format("tr.{0} {{ background-color: red; }}", Game.Hand.BestRanking);
        }

        protected Game Game {
            get {
                var session = HttpContext.Current.Session;
                if(session["Game"] == null) {
                    session["Game"] = new Game();
                }
                return session["Game"] as Game;
            }
        }
    }
}
