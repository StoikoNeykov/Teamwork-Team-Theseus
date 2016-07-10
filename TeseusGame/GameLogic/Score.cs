namespace GameLogic
{
    public class Score
    {
        private static Score instance;

        private Score()
        {
            this.CurentScore = 0;
        }

        public static Score Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Score();
                }
                return instance;
            }
        }

        public int CurentScore { get; private set; }

        public void AddToScore(int value)
        {
            this.CurentScore += value;
        }

        public void ClearScore()
        {
            this.CurentScore = 0;
        }
    }
}
