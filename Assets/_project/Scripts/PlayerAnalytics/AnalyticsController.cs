using Player;
using System;
using Zenject;

namespace PlayerAnalytics
{
    public class AnalyticsController : IInitializable, IDisposable
    {
        private IAnalytics _analytic;
        private PlayerReviveController _playerReviveController;

        public AnalyticsController(IAnalytics analytic, PlayerReviveController playerReviveController) 
        {
            _analytic = analytic;
            _playerReviveController = playerReviveController;
        }

        public void Initialize()
        {
            _analytic.GameStarted();
            _playerReviveController.AcceptDeathAction += PlayerDeath;
        }

        public void Dispose()
        {
            _playerReviveController.AcceptDeathAction -= PlayerDeath;

        }

        private void PlayerDeath()
        {
            _analytic.SendPlayerStatistics();
        }

        public void LaserUsed()
        {
            _analytic.LaserUsed();
        }
    }
}