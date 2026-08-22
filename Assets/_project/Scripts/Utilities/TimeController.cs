using Ads;
using Player;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace Utilities
{
    public class TimeController : IInitializable,IDisposable
    {
        private PlayerProvider _playerProvider;
        private DeathUIPresenter _deathUIPresenter;
        private AdsController _adsController;

        public TimeController(PlayerProvider playerProvider, DeathUIPresenter deathUIPresenter, AdsController adsController)
        {
            _playerProvider = playerProvider;
            _deathUIPresenter = deathUIPresenter;
            _adsController = adsController;

            ResumeTime();
        }

        public void Initialize()
        {
            _playerProvider.SubscribeToPlayerDeath(StopTime);
            _deathUIPresenter.SubscribeToRestartGame(ResumeTime);
            _adsController.SubscirbeToReward(ResumeTime);
        }

        public void Dispose()
        {
            _playerProvider.UnsubscribeFromPlayerDeath(StopTime);
            _deathUIPresenter.UnsubscribeFromRestartGame(ResumeTime);
            _adsController.UnsubscribeFromReward(ResumeTime);
        }

        private void StopTime()
        {
            Time.timeScale = 0;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1;
        }        
    }
}