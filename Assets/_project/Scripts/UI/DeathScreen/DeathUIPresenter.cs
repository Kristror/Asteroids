using Player;
using System;
using Zenject;

namespace UI
{
    public class DeathUIPresenter : IInitializable,IDisposable
    {
        private DeathUIModel _deathUIModel;
        private DeathUIView _deathUIView;

        private PlayerReviveController _playerReviveController;

        public DeathUIPresenter(DeathUIModel model, PlayerReviveController playerReviveController)
        {          
            _deathUIModel = model;
            _playerReviveController = playerReviveController;
        }

        public void Initialize()
        {
            _playerReviveController.SubscribeToAcceptDeath(ShowDeathUI);
        }

        public void SetView(DeathUIView view)
        {
            _deathUIView = view;
            _deathUIView.SetActiveDeathScreen(false);
            _deathUIView.RestartOnClick.AddListener(StartRestartGame);
            _deathUIView.BackToMenuOnClick.AddListener(BackToMenu);
        }

        public void Dispose()
        {
            _deathUIView.RestartOnClick.RemoveListener(StartRestartGame);
            _deathUIView.BackToMenuOnClick.RemoveListener(BackToMenu);
            _playerReviveController.UnsubscribeFromAcceptDeath(ShowDeathUI);
        }

        public void SubscribeToRestartGame(Action func)
        {
            _deathUIModel.RestartGame += func;
        }
        
        public void UnsubscribeFromRestartGame(Action func)
        {
            _deathUIModel.RestartGame -= func;
        }

        public void ShowDeathUI()
        {
            _deathUIView.SetActiveDeathScreen(true);
            _deathUIView.ShowScore(_deathUIModel.PlayerScore);
        }

        private void StartRestartGame()
        {
            _deathUIModel.StartRestartGame();
        }

        private void BackToMenu()
        {
            _deathUIModel.BackToMenu();
        }
    }
}