using Firebase;
using Firebase.Analytics;
using UnityEngine;

namespace PlayerAnalytics
{
    public class AnalyticsWthFirebase : IAnalytics
    {
        private PlayerStatistics _playerStatistics;

        private const string _GameStartLog = "game_started";
        private const string _LaserUsedLog = "laser_used";

        private bool _isConnected;

        public AnalyticsWthFirebase(PlayerStatisticsController playerStatisticsController)
        {
            _playerStatistics = playerStatisticsController.GetPlayerStatistics();
            _isConnected = false;
        }

        public void Initialize()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    _isConnected = true;
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
                FirebaseAnalytics.LogEvent(JsonUtility.ToJson(_playerStatistics));
            }
        }
    }
}