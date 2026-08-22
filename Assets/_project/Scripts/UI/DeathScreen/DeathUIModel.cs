using System;
using Zenject;
using Utilities;

namespace UI
{
    public class DeathUIModel
    {
        public string PlayerScore => SCORE_TEXT + _scoreController.PlayerScore;

        public event Action RestartGame;

        private const string SCORE_TEXT = "Score : ";

        private ScoreController _scoreController;
        private LoadingController _loadingController;
        
        public DeathUIModel(ScoreController scoreController, LoadingController loadingController)
        {
            _scoreController = scoreController;
            _loadingController = loadingController;
        }

        public void StartRestartGame()
        {
            RestartGame?.Invoke();
            _loadingController.LoadGame();
        }

        public void BackToMenu()
        {
            _loadingController.LoadMainMenu();
        }
    }
}