using Player;
using System;
using Zenject;

namespace UI
{
    public class PlayerRevivePresenter : IInitializable, IDisposable
    {
        private PlayerReviveView _playerReviveView;
        private PlayerReviveModel _playerReviveModel;

        private PlayerReviveController _playerReviveController;

        public PlayerRevivePresenter(PlayerReviveModel playerReviveModel, PlayerReviveController playerReviveController)
        {
            _playerReviveModel = playerReviveModel;
            _playerReviveController = playerReviveController;
        }

        public void SetView(PlayerReviveView playerReviveView)
        {
            _playerReviveView = playerReviveView;
            _playerReviveView.SetActivePlayerRevive(false);
        }

        public void Initialize()
        {
            _playerReviveController.PlayerFirstDeath += ShowReviveScreen;
            _playerReviveView.ReviveOnClick.AddListener(Revive);
            _playerReviveView.AcceptDeathOnClick.AddListener(AcceptDeath);
        }

        public void Dispose()
        {
            _playerReviveController.PlayerFirstDeath -= ShowReviveScreen;
            _playerReviveView.ReviveOnClick.RemoveListener(Revive);
            _playerReviveView.AcceptDeathOnClick.RemoveListener(AcceptDeath);
        }

        private void Revive()
        {
            _playerReviveModel.Revive();
            HideReviveScreen();
        }

        private void AcceptDeath()
        {
            _playerReviveModel.AcceptDeath();
            HideReviveScreen();
        }

        public void ShowReviveScreen()
        {
            _playerReviveView.SetActivePlayerRevive(true);
        }

        private void HideReviveScreen()
        {
            _playerReviveView.SetActivePlayerRevive(false);
        }
    }
}