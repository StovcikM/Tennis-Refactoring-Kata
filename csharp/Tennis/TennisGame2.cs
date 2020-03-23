namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point = 0;
        private int player2Point = 0;

        private string player1Result = "";
        private string player2Ressult = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";

            CheckEqualPoints(ref score);
            CheckOnePlayerZeroPoints(ref score);
            CheckOnePlayerLeadingUnderFourPoints(ref score);
            CheckAdvantage(ref score);
            CheckWin(ref score);
            
            return score;
        }

        private void CheckOnePlayerLeadingUnderFourPoints(ref string score)
        {
            if (player1Point > player2Point && player1Point < 4)
            {
                if (player1Point == 2)
                    player1Result = "Thirty";
                if (player1Point == 3)
                    player1Result = "Forty";
                if (player2Point == 1)
                    player2Ressult = "Fifteen";
                if (player2Point == 2)
                    player2Ressult = "Thirty";
                score = player1Result + "-" + player2Ressult;
            }
            if (player2Point > player1Point && player2Point < 4)
            {
                if (player2Point == 2)
                    player2Ressult = "Thirty";
                if (player2Point == 3)
                    player2Ressult = "Forty";
                if (player1Point == 1)
                    player1Result = "Fifteen";
                if (player1Point == 2)
                    player1Result = "Thirty";
                score = player1Result + "-" + player2Ressult;
            }
        }

        private void CheckOnePlayerZeroPoints(ref string score)
        {
            if (player1Point > 0 && player2Point == 0)
            {
                if (player1Point == 1)
                    player1Result = "Fifteen";
                if (player1Point == 2)
                    player1Result = "Thirty";
                if (player1Point == 3)
                    player1Result = "Forty";

                player2Ressult = "Love";
                score = player1Result + "-" + player2Ressult;
            }
            if (player2Point > 0 && player1Point == 0)
            {
                if (player2Point == 1)
                    player2Ressult = "Fifteen";
                if (player2Point == 2)
                    player2Ressult = "Thirty";
                if (player2Point == 3)
                    player2Ressult = "Forty";

                player1Result = "Love";
                score = player1Result + "-" + player2Ressult;
            }
        }

        private void CheckEqualPoints(ref string score)
        {
            if (player1Point == player2Point && player1Point < 3)
            {
                if (player1Point == 0)
                    score = "Love";
                if (player1Point == 1)
                    score = "Fifteen";
                if (player1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (player1Point == player2Point && player1Point > 2)
                score = "Deuce";
        }

        private void CheckWin(ref string score)
        {
            if (player1Point >= 4 && player2Point >= 0 && (player1Point - player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Point >= 4 && player1Point >= 0 && (player2Point - player1Point) >= 2)
            {
                score = "Win for player2";
            }
        }

        private void CheckAdvantage(ref string score)
        {
            if (player1Point > player2Point && player2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Point > player1Point && player1Point >= 3)
            {
                score = "Advantage player2";
            }
        }


        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            player1Point++;
        }

        private void P2Score()
        {
            player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

