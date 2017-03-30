<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DrBrownfields.UI.VideoPoker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Video Poker</title>
    <style type="text/css">
        img {
            width: 160px;
            height: 200px;
        }

        input {
            width: 25px;
            margin-left: 50px;
        }

        button {
            width: 100px;
        }

        div.card {
            margin: 5px;
            float: left;
        }

        div.deal {
            width: 100px;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
            padding: 0px;
        }

        td.Ranking {
            width: 200px;
            float: left;
            padding: 5px;
        }

        td.Payout {
            width: 50px;
            text-align: right;
            padding: 5px;
        }

        td.Caption {
            width: 80px;
        }

        td.Value {
            width: 25px;
            text-align: right;
        }

        div {
            margin-left: auto;
            margin-right: auto;
        }

        table.Betting {
            float: right;
            margin-right: 60px;
            border-collapse: separate;
            border-spacing: 10px;
        }
    </style>
    <style runat="server" id="currentRanking">
        tr.Nothing {
            background-color: red;
        }
    </style>
    <script type="text/javascript">
        function Select(hold) {
            if (hold.disabled == false) {
                hold.checked = !hold.checked;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="width: 900px;">
        <h1>Dr. Brownfield's Poker Emporium</h1>
        <table class="Betting">
            <tr>
                <td class="Caption">Stake</td>
                <td class="Value" runat="server" id="Stake">100</td>
            </tr>
            <tr>
                <td>Bet</td>
                <td class="Value" runat="server" id="Bet">5</td>
            </tr>
            <tr>
                <td>Win</td>
                <td class="Value" runat="server" id="Win">0</td>
            </tr>
        </table>
        <table class="Rankings">
            <tr class="RoyalFlush">
                <td class="Ranking">Royal Flush</td>
                <td class="Payout">2000</td>
            </tr>
            <tr class="StraightFlush">
                <td class="Ranking">Straight Flush</td>
                <td class="Payout">250</td>
            </tr>
            <tr class="FourOfAKind">
                <td class="Ranking">Four of a Kind</td>
                <td class="Payout">125</td>
            </tr>
            <tr class="FullHouse">
                <td class="Ranking">Full House</td>
                <td class="Payout">40</td>
            </tr>
            <tr class="Flush">
                <td class="Ranking">Flush</td>
                <td class="Payout">25</td>
            </tr>
            <tr class="Straight">
                <td class="Ranking">Straight</td>
                <td class="Payout">20</td>
            </tr>
            <tr class="ThreeOfAKind">
                <td class="Ranking">Three of a Kind</td>
                <td class="Payout">15</td>
            </tr>
            <tr class="TwoPair">
                <td class="Ranking">Two Pair</td>
                <td class="Payout">10</td>
            </tr>
            <tr class="Pair">
                <td class="Ranking">Pair</td>
                <td class="Payout">5</td>
            </tr>
        </table>
        <div class="card">
            <div>
                <img runat="server" id="Card1" src="Images/CardBack.png" onclick="Select(Hold1);" />
            </div>
            <div>
                <input runat="server" type="checkbox" id="Hold1" />Hold
            </div>
        </div>
        <div class="card">
            <div>
                <img runat="server" id="Card2" src="Images/CardBack.png" onclick="Select(Hold2);" />
            </div>
            <div>
                <input runat="server" type="checkbox" id="Hold2" />Hold
            </div>
        </div>
        <div class="card">
            <div>
                <img runat="server" id="Card3" src="Images/CardBack.png" onclick="Select(Hold3);" />
            </div>
            <div>
                <input runat="server" type="checkbox" id="Hold3" />Hold
            </div>
        </div>
        <div class="card">
            <div>
                <img runat="server" id="Card4" src="Images/CardBack.png" onclick="Select(Hold4);" />
            </div>
            <div>
                <input runat="server" type="checkbox" id="Hold4" />Hold
            </div>
        </div>
        <div class="card">
            <div>
                <img runat="server" id="Card5" src="Images/CardBack.png" onclick="Select(Hold5);" />
            </div>
            <div>
                <input runat="server" type="checkbox" id="Hold5" />Hold
            </div>
        </div>
        <div class="deal">
            <button runat="server" type="button" id="Deal" onserverclick="Deal_ServerClick">Deal</button>
            <button runat="server" type="button" id="Draw" onserverclick="Draw_ServerClick">Draw</button>
        </div>
    </form>
</body>
</html>
