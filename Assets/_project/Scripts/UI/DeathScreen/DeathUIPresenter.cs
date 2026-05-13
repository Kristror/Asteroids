using Player;
using System;
using Zenject;

namespace UI
{
    public class DeathUIPresenter : IInitializable,IDisposable
    {
        private DeathUIModel _deathUIModel;
        private DeathUIView _deathUIView;

        private PlayerProvider _playerProvider;

        public DeathUIPresenter(PlayerProvider playerProvider, DeathUIModel model)
        {
            _playerProvider = playerProvider;            
            _deathUIModel = model;
        }

        public void Initialize()
        {
            _playerProvider.SubscribeToPlayerDeath(PlayerDeath);
        }

        public void Dispose()
        {
            _deathUIView.OnClick.RemoveAllListeners();
            _playerProvider.UnSubscribeToPlayerDeath(PlayerDeath);
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