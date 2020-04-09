using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Points;
        private int player1Points;
        private string player1Name;
        private string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string[] points = { "Love", "Fifteen", "Thirty", "Forty" };
            if (player1Points == player2Points)
            {
                return (player1Points < 3) ? (points[player1Points] + "-All") : "Deuce";
            }
            if (player1Points < 4 && player2Points < 4)
            {                
                return points[player1Points] + "-" + points[player2Points];
            }
            
            string leadingPlayer = player1Points > player2Points ? player1Name : player2Name;
            int scoreDifference = Math.Abs(player1Points - player2Points);

            return (scoreDifference == 1) ? "Advantage " + leadingPlayer : "Win for " + leadingPlayer;            
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                player1Points++;
            }
            else
            { 
                player2Points++;
            }
        }

    }
}

