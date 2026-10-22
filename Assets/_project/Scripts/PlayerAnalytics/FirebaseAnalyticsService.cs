using Firebase;
using Firebase.Analytics;
using System;
using Utilities;
using Zenject;

namespace PlayerAnalytics
{
    public class FirebaseAnalyticsService : IAnalytics, IInitializable, IDisposable
    {
        private const string GAME_STARTED = "game_started";
        private const string PLAYER_STATISTICS = "player_statistics";
        private const string LASER_FIRED = "laser_fired";

        private PlayerStatistics _playerStatistics;
        private FirebaseAppProvider _firebaseAppProvider;
        private bool _isConnected;

        public FirebaseAnalyticsService(FirebaseAppProvider firebaseAppProvider)
        {
            _firebaseAppProvider = firebaseAppProvider;
            _isConnected = false;
        }

        public void Initialize()
        {
            _firebaseAppProvider.FirebaseReady += StartAnalyticsCollection;
        }

        public void Dispose()
        {
            _firebaseAppProvider.FirebaseReady -= StartAnalyticsCollection;
        }

        private void StartAnalyticsCollection()
        {
            if (FirebaseApp.DefaultInstance != null)
            {
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                _isConnected = true;
            }
        }

        public void SetPlayerStatistics(PlayerStatistics playerStatistics)
        {
            _playerStatistics = playerStatistics;
        }

        public void GameStarted()
        {
            if (_isConnected)
            {
                FirebaseAnalytics.LogEvent(GAME_STARTED);
            }
        }

        public void LaserFired()
        {
            if (_isConnected)
            {
                FirebaseAnalytics.LogEvent(LASER_FIRED);
            }
        }

        public void SendPlayerStatistics()
        {
            if (_isConnected)
            {
                Parameter[] playerStats = {
                    new Parameter(PlayerStatistics.SHOTS_FIRED_NAME, _playerStatistics.ShotsFired),
                    new Parameter(PlayerStatistics.LASER_FIRED_NAME, _playerStatistics.LaserFired),
                    new Parameter(PlayerStatistics.ASTEROIDS_KILLED_NAME, _playerStatistics.AsteroidsKilled),
                    new Parameter(PlayerStatistics.UFO_KILLED_NAME, _playerStatistics.UfoKilled)
                };
                FirebaseAnalytics.LogEvent(PLAYER_STATISTICS, playerStats);
            }
        }
    }
}