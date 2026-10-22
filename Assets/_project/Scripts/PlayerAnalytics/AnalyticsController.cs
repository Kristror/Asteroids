using Player;
using System;
using Zenject;

namespace PlayerAnalytics
{
    public class AnalyticsController : IInitializable, IDisposable
    {
        private IAnalytics _analytic;

        private PlayerReviveController _playerReviveController;
        private PlayerProvider _playerProvider;
        private PlayerLaserShooting _playerLaserShooting;

        public AnalyticsController(IAnalytics analytic, PlayerReviveController playerReviveController, PlayerProvider playerProvider) 
        {
            _analytic = analytic;
            _playerReviveController = playerReviveController;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            _playerLaserShooting = _playerProvider.PlayerLaserShooting;

            _analytic.GameStarted();
            _playerReviveController.AcceptDeathAction += PlayerDeath;
            _playerLaserShooting.LaserFired += LaserFired;
        }

        public void Dispose()
        {
            _playerReviveController.AcceptDeathAction -= PlayerDeath;
            _playerLaserShooting.LaserFired -= LaserFired;
        }

        private void PlayerDeath()
        {
            _analytic.SendPlayerStatistics();
        }

        public void LaserFired()
        {
            _analytic.LaserFired();
        }
    }
}