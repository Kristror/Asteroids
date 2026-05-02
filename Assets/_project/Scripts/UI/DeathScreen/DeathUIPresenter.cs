using Player;
using System;
using Zenject;

namespace UI
{
    public class DeathUIPresenter : IInitializable,IDisposable
    {
        private DeathUIModel _deathUIModel;
        private DeathUIView _deathUIView;

        private PlayerObject _playerController;

        public DeathUIPresenter(PlayerObject playerController, DeathUIModel model)
        {
            _playerController = playerController;            
            _deathUIModel = model;
        }

        public void Initialize()
        {
            _playerController.SubscribeToPlayerDeath(PlayerDeath);
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