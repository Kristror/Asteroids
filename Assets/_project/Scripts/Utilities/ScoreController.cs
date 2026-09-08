using Configs;
using Zenject;

namespace Utilities
{
    public class ScoreController: IInitializable
    {
        public int PlayerScore { get; private set; }

        private int _pointsForEnemy;

        private ConfigsController _configController;

        public ScoreController(ConfigsController configsController) 
        {
            _configController = configsController;
            ResetScore();
        }

        public void Initialize()
        {
            _pointsForEnemy = _configController.GetPointsForEnemy();
        }

        private void ResetScore()
        {
            PlayerScore = 0;
        }

        public void EnemyKilled()
        {
            PlayerScore += _pointsForEnemy;
        }
    }
}