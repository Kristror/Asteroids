using Player;
using System;
using UI;
using UnityEngine;

namespace Utilites
{
    public class TimeController : IDisposable
    {
        private PlayerController _playerController;
        private DeathUIPresenter _deathUIPresenter;

        public TimeController(PlayerController playerController, DeathUIPresenter deathUIPresenter)
        {
            _playerController = playerController;
            _deathUIPresenter = deathUIPresenter;

            _playerController.SubscribeToPlayerDeath(StopTime);
            _deathUIPresenter.SubscribeToRestartGame(ResumeTime);
        }

        public void Dispose()
        {
            _playerController.UnSubscribeToPlayerDeath(StopTime);
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