using Firebase;
using Firebase.Analytics;
using System;
using UnityEngine;

namespace PlayerAnalytics
{
    public class AnalyticsWithFirebase : IAnalytics, IDisposable
    {
        private const string GAME_STARTED = "game_started";
        private const string PLAYER_STATISTICS = "player_statistics";
        private const string LASER_USED = "laser_used";

        private PlayerStatistics _playerStatistics;
        private bool _isConnected;

        public AnalyticsWithFirebase()
        {
            _isConnected = false;
        }

        public void Initialize()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                    _isConnected = true;
                }
                else
                {
                    Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                }
            });
        }

        public void Dispose()
        {
            FirebaseApp.DefaultInstance.Dispose();
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

        public void LaserUsed()
        {
            if (_isConnected)
            {
                FirebaseAnalytics.LogEvent(LASER_USED);
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