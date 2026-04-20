using Player;
using System;

namespace UI
{
    public class DeathUIPresenter : IDisposable
    {
        private DeathUIModel _deathUIModel;
        private DeathUIView _deathUIView;

        private PlayerController _playerController;

        public DeathUIPresenter(PlayerController playerController, DeathUIModel model)
        {
            _playerController = playerController;

            _playerController.SubscribeToPlayerDeath(PlayerDeath);

            _deathUIModel = model;
        }
        
        public void SetView(DeathUIView view)
        {
            _deathUIView = view; 
            _deathUIView.SetActiveDeathScreen(false);
            _deathUIView.OnClick.AddListener(StartRestartGame);
        }

        public void SubscribeToRestartGame(Action func)
        {
            _deathUIModel.RestartGame += func;
        }
        
        public void UnSubscribeToRestartGame(Action func)
        {
            _deathUIModel.RestartGame -= func;
        }

        public void Dispose()
        {
            _deathUIView.OnClick.RemoveAllListeners();
            _playerController.UnSubscribeToPlayerDeath(PlayerDeath);
        }

        private void StartRestartGame()
        {
            _deathUIModel.StartRestartGame();
        }

        private void PlayerDeath()
        {
            _deathUIView.SetActiveDeathScreen(true);
            _deathUIView.ShowScore(_deathUIModel.PlayerScore);
        }
    }
}