using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Points = 0;
        private int player2Points = 0;

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
            if (player1Points < 4 && player2Points < 4 && player1Points != player2Points)
            {
                score = scores[player1Points] + "-" + scores[player2Points];
            }         
        }

        private void CheckEqualPoints(ref string score)
        {
            if (player1Points == player2Points)
            {
                score = (player1Points < 3) ? (scores[player1Points] + "-All") : "Deuce";
            }
                   
        }

        private void CheckWin(ref string score)
        {  
            if (player1Points >= 4 && player1Points - 1 > player2Points)
            {
                score = "Win for player1";
            }
            if (player2Points >= 4 && player2Points - 1 > player1Points)
            {
                score = "Win for player2";
            }
        }

        private void CheckAdvantage(ref string score)
        {
            if (player2Points >= 3 && player1Points > player2Points)
            {
                score = "Advantage player1";
            }

            if (player1Points >= 3 && player2Points > player1Points)
            {
                score = "Advantage player2";
            }
        }


        public void SetP1Score(int number = 1)
        {
            player1Points += number;
        }

        public void SetP2Score(int number = 1)
        {
            player2Points += number;
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

