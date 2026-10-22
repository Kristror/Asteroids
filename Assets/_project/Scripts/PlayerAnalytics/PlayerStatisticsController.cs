using Enemies;
using Enemies.Spawners;
using Player;
using System;
using Zenject;

namespace PlayerAnalytics
{
    public class PlayerStatisticsController : IInitializable, IDisposable
    {
        private PlayerStatistics _playerStatistics;
        private PlayerProvider _playerProvider;
        private PlayerLaserShooting _playerLaserShooting;
        private PlayerBulletShooting _playerBulletShooting;

        public PlayerStatisticsController(IAnalytics analytics, PlayerProvider playerProvider)
        {
            _playerStatistics = new PlayerStatistics();
            _playerProvider = playerProvider;
            analytics.SetPlayerStatistics(_playerStatistics);
        }

        public void Initialize()
        {
            _playerLaserShooting = _playerProvider.PlayerLaserShooting;
            _playerBulletShooting = _playerProvider.PlayerBulletShooting;

            _playerLaserShooting.LaserFired += LaserFired;
            _playerBulletShooting.BulletFired += BulletFired;
        }

        public void Dispose()
        {
            _playerLaserShooting.LaserFired -= LaserFired;
            _playerBulletShooting.BulletFired -= BulletFired;
        }

        public PlayerStatistics GetPlayerStatistics()
        {
            return _playerStatistics;
        }

        public void BulletFired()
        {
            _playerStatistics.ShotsFired++;
        }

        public void LaserFired()
        {
            _playerStatistics.LaserFired++;
        }

        public void EnemyKilled(EnemyCollision enemyCollision)
        {
            switch (enemyCollision.EnemyType)
            {
                case (EnemyType.Asteroid):
                    _playerStatistics.AsteroidsKilled++;
                    break;
                case (EnemyType.SmallAsteroid):
                    _playerStatistics.AsteroidsKilled++;
                    break;
                case (EnemyType.UFO):
                    _playerStatistics.UfoKilled++;
                    break;
            }

            enemyCollision.Killed -= EnemyKilled;
        }
    }
}