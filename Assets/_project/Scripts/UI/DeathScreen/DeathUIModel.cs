using System;
using Utilites;

namespace UI
{
    public class DeathUIModel
    {
        public event Action RestartGame;

        public string PlayerScore => scoreText + _scoreController.PlayerScore;

        private ScoreController _scoreController;

        private const string scoreText = "Score : ";
        
        public DeathUIModel(ScoreController scoreController)
        {
            _scoreController = scoreController;
        }

        public void StartRestartGame()
        {
            RestartGame?.Invoke();
        }
    }
}