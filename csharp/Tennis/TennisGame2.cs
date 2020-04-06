using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point = 0;
        private int player2Point = 0;

        private string player1Name;
        private string player2Name;

        private List<string> scores = new List<string>() { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";

            CheckEqualPoints(ref score);
            CheckLeadingUnderFourPoints(ref score);
            CheckAdvantage(ref score);
            CheckWin(ref score);
            
            return score;
        }

        private void CheckLeadingUnderFourPoints(ref string score)
        {
            if (player1Point < 4 && player2Point < 4 && player1Point != player2Point)
            {
                score = scores[player1Point] + "-" + scores[player2Point];
            }         
        }

        private void CheckEqualPoints(ref string score)
        {
            if (player1Point == player2Point)
            {
                score = (player1Point < 3) ? (scores[player1Point] + "-All") : "Deuce";
            }
                   
        }

        private void CheckWin(ref string score)
        {  
            if (player1Point >= 4 && player1Point - 1 > player2Point)
            {
                score = "Win for player1";
            }
            if (player2Point >= 4 && player2Point - 1 > player1Point)
            {
                score = "Win for player2";
            }
        }

        private void CheckAdvantage(ref string score)
        {
            if (player2Point >= 3 && player1Point > player2Point)
            {
                score = "Advantage player1";
            }

            if (player1Point >= 3 && player2Point > player1Point)
            {
                score = "Advantage player2";
            }
        }


        public void SetP1Score(int number = 1)
        {
            player1Point += number;
        }

        public void SetP2Score(int number = 1)
        {
            player2Point += number;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                SetP1Score();
            else
                SetP2Score();
        }

    }
}

