using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        
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
            _ = (playerName == "player1") ? m_score1 += 1 : m_score2 += 1;
        }
 
        public string GetScore()
        {
            if (m_score1 == m_score2)
            {
                return EqualPoints();
            }
            if (m_score1 >= 4 || m_score2 >= 4)
            {
                return FourAndMorePoints();
            }        
            return LessThenFourPoints();                     
        }

        private string EqualPoints()
        {
            return (m_score1 < 3) ? (scores[m_score1] + "-All") : "Deuce";
        }

        private string LessThenFourPoints()
        {
            return scores[m_score1] + "-" + scores[m_score2];
        }

        private string FourAndMorePoints()
        {
            string score ;
            var scoreDifference = m_score1 - m_score2;
            
            if (scoreDifference == 1) score = "Advantage player1";
            else if (scoreDifference == -1) score = "Advantage player2";
            else if (scoreDifference >= 2) score = "Win for player1";
            else score = "Win for player2";

            return score;
        }
    }
}

