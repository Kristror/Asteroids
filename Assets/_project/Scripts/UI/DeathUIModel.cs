using System;
using Utilites;

namespace UI
{
    public class DeathUIModel
    {
        public Action RestartGame;

        public string PlayerScore => scoreText + _scoreController.PlayerScore;

        private SceneController _sceneController;
        private TimeController _timeController;
        private ScoreController _scoreController;

        private const string scoreText = "Score : ";
        
        public DeathUIModel(ScoreController scoreController)
        {
            _scoreController = scoreController;
        }

        private void StartRestartGame()
        {
            RestartGame?.Invoke();
        }
    }
}