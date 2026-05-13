using Player;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace Utilites
{
    public class TimeController : IInitializable,IDisposable
    {
        private PlayerProvider _playerProvider;
        private DeathUIPresenter _deathUIPresenter;

        public TimeController(PlayerProvider playerProvider, DeathUIPresenter deathUIPresenter)
        {
            _playerProvider = playerProvider;
            _deathUIPresenter = deathUIPresenter;            
        }

        public void Initialize()
        {
            _playerProvider.SubscribeToPlayerDeath(StopTime);
            _deathUIPresenter.SubscribeToRestartGame(ResumeTime);
        }

        public void Dispose()
        {
            _playerProvider.UnSubscribeToPlayerDeath(StopTime);
            _deathUIPresenter.UnSubscribeToRestartGame(ResumeTime);
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