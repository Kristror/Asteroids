using Firebase;
using Firebase.Analytics;
using UnityEngine;

namespace PlayerAnalytics
{
    public class AnalyticsWithFirebase : IAnalytics
    {
        private PlayerStatistics _playerStatistics;

        private const string _GameStartLog = "game_started";
        private const string _PlayerStatistics = "player_statistics";
        private const string _LaserUsedLog = "laser_used";

        private bool _isConnected;

        public AnalyticsWithFirebase(PlayerStatisticsController playerStatisticsController)
        {
            _playerStatistics = playerStatisticsController.GetPlayerStatistics();
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
                    Debug.LogError(System.String.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                }
            });
        }

        public void Dispose()
        {
            FirebaseApp.DefaultInstance.Dispose();
        }

        public void GameStarted()
        {
            if (_isConnected)
            {
                FirebaseAnalytics.LogEvent(_GameStartLog);
            }
        }

        public void LazerUsed()
        {
            if (_isConnected)
            {
                FirebaseAnalytics.LogEvent(_LaserUsedLog);
            }
        }

        public void SendPlayerStatistics()
        {
            if (_isConnected)
            {
                Parameter[] playerStats = {
                    new Parameter(PlayerStatistics.ShotsFiredName, _playerStatistics.ShotsFired),
                    new Parameter(PlayerStatistics.LazerFiredName, _playerStatistics.LazerFired),
                    new Parameter(PlayerStatistics.AsteroidsKilledName, _playerStatistics.AsteroidsKilled),
                    new Parameter(PlayerStatistics.UfoKilledName, _playerStatistics.UfoKilled)
                };
                FirebaseAnalytics.LogEvent(_PlayerStatistics, playerStats);
            }
        }
    }
}