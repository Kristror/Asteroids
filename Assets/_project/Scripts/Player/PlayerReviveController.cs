using System;
using Zenject;

namespace Player
{
    public class PlayerReviveController : IInitializable, IDisposable
    {

        public event Action AcceptDeathAction;
        public event Action ReviveAction;
        public event Action PlayerFirstDeath;

        private bool _isFirstRevive;

        private PlayerProvider _playerProvider;
        
        public PlayerReviveController(PlayerProvider playerProvider) 
        {
            _isFirstRevive = true;

            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            _playerProvider.SubscribeToPlayerDeath(ShowPlayerReviveUI);
        }

        public void Dispose()
        {
            _playerProvider.UnsubscribeFromPlayerDeath(ShowPlayerReviveUI);
        }

        public void Revive()
        {
            _isFirstRevive = false;
            ReviveAction?.Invoke();
        }

        public void AcceptDeath()
        {
            AcceptDeathAction?.Invoke();
        }

        private void ShowPlayerReviveUI()
        {
            if (_isFirstRevive)
            {
                PlayerFirstDeath.Invoke();
            }
            else
            {
                AcceptDeath();
            }
        }
    }
}