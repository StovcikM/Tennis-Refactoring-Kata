using System;
using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int player1Points = 0;
        private int player2Points = 0;
        
        private string player1Name;
        private string player2Name;

        private List<string> scores = new List<string>() { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            _ = (playerName == "player1") ? player1Points += 1 : player2Points += 1;
        }
 
        public string GetScore()
        {
            if (player1Points == player2Points)
            {
                return (player1Points < 3) ? (scores[player1Points] + "-All") : "Deuce";
            }
            if (player1Points >= 4 || player2Points >= 4)
            {
                return FourAndMorePoints();
            }        
            return scores[player1Points] + "-" + scores[player2Points];
        }

        private string FourAndMorePoints()
        {            
            string leadingPlayer = (player1Points > player2Points) ? "player1" : "player2";
            int scoreDifference = Math.Abs(player1Points - player2Points);

            if (scoreDifference == 1)
            {
                return "Advantage " + leadingPlayer;
            }
            return "Win for " + leadingPlayer;
        }
    }
}

