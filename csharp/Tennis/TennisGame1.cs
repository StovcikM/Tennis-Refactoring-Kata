using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

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
            string score;

            if (m_score1 == m_score2)
            {
                score = EqualPoints();
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                score = FourAndMorePoints();
            }
            else
            {
                score = LessThenFourPoints();
            }
            return score;
        }

        private string EqualPoints()
        {
            List<string> scores = new List<string>() {"Love-All", "Fifteen-All", "Thirty-All", "Deuce"};
            return (m_score1 < 4) ? scores[m_score1] : scores[3];
        }

        private string LessThenFourPoints()
        {
            List<string> scores = new List<string>() { "Love", "Fifteen", "Thirty", "Forty" };
            return scores[m_score1] + "-" + scores[m_score2];
        }

        private string FourAndMorePoints()
        {
            string score ;
            var minusResult = m_score1 - m_score2;
            
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";

            return score;
        }
    }
}

