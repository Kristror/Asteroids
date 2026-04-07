using Player;
using System;

namespace UI
{
    public class DeathUIPresenter : IDisposable
    {
        public DeathUIModel DeathUIModel;
        private DeathUIView _deathUIView;

        private PlayerController _playerController;

        public DeathUIPresenter(PlayerController playerController, DeathUIModel model, DeathUIView view)
        {
            _playerController = playerController;

            _playerController.PlayerCollision.PlayerDeath += PlayerDeath;

            DeathUIModel = model;
            _deathUIView = view;

            _deathUIView.SetActiveDeathScreen(false);
            _deathUIView.OnClick.AddListener(StartRestartGame);
        }

        public void Dispose()
        {
            _playerController.PlayerCollision.PlayerDeath -= PlayerDeath;
        }

        private void StartRestartGame()
        {
            DeathUIModel.StartRestartGame();
        }

        private void PlayerDeath()
        {
            _deathUIView.SetActiveDeathScreen(true);
            _deathUIView.ShowScore(DeathUIModel.PlayerScore);
        }
    }
}