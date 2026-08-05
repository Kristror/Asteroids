using System;
using Utilities;

namespace UI
{
    public class DeathUIModel
    {
        public event Action RestartGame;

        public string PlayerScore => _scoreText + _scoreController.PlayerScore;

        private ScoreController _scoreController;
        private LoadingController _loadingController;

        private const string _scoreText = "Score : ";
        
        public DeathUIModel(ScoreController scoreController, LoadingController loadingController)
        {
            _scoreController = scoreController;
            _loadingController = loadingController;

            RestartGame += loadingController.LoadGame;
        }

        public void StartRestartGame()
        {
            RestartGame?.Invoke();
        }
    }
}