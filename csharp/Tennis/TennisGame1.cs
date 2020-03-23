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
            string score;
            switch (m_score1)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }

        private string LessThenFourPoints()
        {
            string score = "";
            int tempScore;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = m_score1;
                else { score += "-"; tempScore = m_score2; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        private string FourAndMorePoints()
        {
            string score = "Advantage ";
            var minusResult = m_score1 - m_score2;
            
            if (minusResult == 1) score += "player1";
            else if (minusResult == -1) score += "player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";

            return score;
        }
    }
}

