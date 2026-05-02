using Player;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace Utilites
{
    public class TimeController : IInitializable,IDisposable
    {
        private PlayerObject _playerObject;
        private DeathUIPresenter _deathUIPresenter;

        public TimeController(PlayerObject playerController, DeathUIPresenter deathUIPresenter)
        {
            _playerObject = playerController;
            _deathUIPresenter = deathUIPresenter;            
        }

        public void Initialize()
        {
            _playerObject.SubscribeToPlayerDeath(StopTime);
            _deathUIPresenter.SubscribeToRestartGame(ResumeTime);
        }

        public void Dispose()
        {
            _playerObject.UnSubscribeToPlayerDeath(StopTime);
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