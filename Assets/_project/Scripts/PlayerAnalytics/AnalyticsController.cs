using Player;
using System;
using Zenject;

namespace PlayerAnalytics
{
    public class AnalyticsController : IInitializable, IDisposable
    {
        private IAnalytics _analytic;
        private PlayerProvider _playerProvider;

        public AnalyticsController(AnalyticsWthFirebase analytic, PlayerProvider playerProvider) 
        {
            _analytic = analytic;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            _analytic.GameStarted();
            _playerProvider.SubscribeToPlayerDeath(PlayerDeath);
        }

        public void Dispose()
        {
            _playerProvider.UnSubscribeToPlayerDeath(PlayerDeath);
        }

        private void PlayerDeath()
        {
            _analytic.SendPlayerStatistics();
        }

        public void LazerUsed()
        {
            _analytic.LazerUsed();
        }
    }
}