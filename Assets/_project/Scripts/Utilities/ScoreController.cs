namespace Utilites
{
    public class ScoreController
    {
        private const int _pointsForEnemy = 2;
        public int PlayerScore { get; private set; }

        public ScoreController() 
        {
            ResetScore();
        }

        private void ResetScore()
        {
            PlayerScore = 0;
        }

        public void KilledEnemy()
        {
            PlayerScore += _pointsForEnemy;
        }
    }
}