using Ads;
using Player;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace Utilities
{
    public class PauseController : IInitializable,IDisposable
    {
        public bool IsPaused { get; private set; }

        private PlayerProvider _playerProvider;
        private DeathUIPresenter _deathUIPresenter;
        private AdsController _adsController;

        public PauseController(PlayerProvider playerProvider, DeathUIPresenter deathUIPresenter, AdsController adsController)
        {
            _playerProvider = playerProvider;
            _deathUIPresenter = deathUIPresenter;
            _adsController = adsController;

            ResumeGame();
        }

        public void Initialize()
        {
            _playerProvider.SubscribeToPlayerDeath(PauseGame);
            _deathUIPresenter.SubscribeToRestartGame(ResumeGame);
            _adsController.SubscribeToReward(ResumeGame);
        }

        public void Dispose()
        {
            _playerProvider.UnsubscribeFromPlayerDeath(PauseGame);
            _deathUIPresenter.UnsubscribeFromRestartGame(ResumeGame);
            _adsController.UnsubscribeFromReward(ResumeGame);
        }

        private void PauseGame()
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }

        private void ResumeGame()
        {
            IsPaused = false;
            Time.timeScale = 1f;
        }        
    }
}