namespace Utilities
{
    public class ScoreController
    {
        public int PlayerScore { get; private set; }

        private const int POINTS_FOR_ENEMY = 2;

        public ScoreController() 
        {
            ResetScore();
        }

        private void ResetScore()
        {
            PlayerScore = 0;
        }

        public void EnemyKilled()
        {
            PlayerScore += POINTS_FOR_ENEMY;
        }
    }
}