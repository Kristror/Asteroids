using System;
using Utilites;

namespace UI
{
    public class DeathUIModel
    {
        public event Action RestartGame;

        public string PlayerScore => _scoreText + _scoreController.PlayerScore;

        private ScoreController _scoreController;
        private SceneLoader _sceneLoader;

        private const string _scoreText = "Score : ";
        
        public DeathUIModel(ScoreController scoreController, SceneLoader sceneLoader)
        {
            _scoreController = scoreController;
            _sceneLoader = sceneLoader;

            RestartGame += _sceneLoader.LoadGame;
        }

        public void StartRestartGame()
        {
            RestartGame?.Invoke();
        }
    }
}