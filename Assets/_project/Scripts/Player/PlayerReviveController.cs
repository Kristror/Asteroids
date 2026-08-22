using System;
using Zenject;

namespace Player
{
    public class PlayerReviveController : IInitializable, IDisposable
    {
        public bool IsFirstRevive { get; private set; }

        private PlayerProvider _playerProvider;

        private event Action _acceptDeath;
        private event Action _reviveAction;
        private event Action _playerFirstDeath;

        
        public PlayerReviveController(PlayerProvider playerProvider) 
        {
            IsFirstRevive = true;

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

        private void ShowPlayerReviveUI()
        {
            if (IsFirstRevive)
            {
                _playerFirstDeath.Invoke();
            }
            else
            {
                AcceptDeath();
            }
        }

        public void SubscribeToFirstDeath(Action func)
        {
            _playerFirstDeath += func;
        }

        public void UnsubscribeFromFirstDeath(Action func)
        {
            _playerFirstDeath -= func;
        }

        public void SubscribeToAcceptDeath(Action func)
        {
            _acceptDeath += func;
        }

        public void UnsubscribeFromAcceptDeath(Action func)
        {
            _acceptDeath -= func;
        }

        public void SubscribeToReviveAction(Action func)
        {
            _reviveAction += func;
        }

        public void UnsubscribeFromReviveAction(Action func)
        {
            _reviveAction -= func;
        }

        public void Revive()
        {
            IsFirstRevive = false;
            _reviveAction?.Invoke();
        }

        public void AcceptDeath()
        {
            _acceptDeath?.Invoke();
        }
    }
}