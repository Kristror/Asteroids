using Player;
using System;
using UI;
using UnityEngine;

namespace Utilites
{
    public class TimeController : IDisposable
    {
        private PlayerController _playerController;
        private UIManager _uIManager;

        public TimeController(PlayerController playerController, UIManager uIManager)
        {
            _playerController = playerController;
            _uIManager = uIManager;

            _playerController.PlayerCollision.PlayerDeath += StopTime;
            _uIManager.DeathUIpresenter.DeathUIModel.RestartGame += ResumeTime;
        }
        public void Dispose()
        {
            _playerController.PlayerCollision.PlayerDeath -= StopTime;
            _uIManager.DeathUIpresenter.DeathUIModel.RestartGame -= ResumeTime;
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