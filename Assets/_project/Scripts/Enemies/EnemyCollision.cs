using Enemies.Spawners;
using PlayerAnalytics;
using System;
using UnityEngine;
using Utilities;
using Weapons;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollision : MonoBehaviour
    {
        public Vector2 Position => transform.position;

        private EnemyType _enemyType;
        private ScoreController _scoreController;
        private PlayerStatisticsController _playerStatisticsController;

        public event Action<EnemyCollision> KilledByBullet;

        [Inject]
        private void Construct(ScoreController scoreController, PlayerStatisticsController playerStatisticsController)
        {
            _scoreController = scoreController;
            _playerStatisticsController = playerStatisticsController;
        }

        public void SetType(EnemyType type)
        {
            _enemyType = type;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletCollision>(out _))
            {
                KilledByBullet?.Invoke(this);
                Death();
            }
            if (collision.TryGetComponent<ISecondaryWeapon>(out _))
            {
                Death();
            }
        }

        private void Death()
        {
            _scoreController.EnemyKilled();
            UpdateStatistics();

            Destroy(gameObject);
        }

        private void UpdateStatistics()
        {
            if ((_enemyType == EnemyType.Asteroid) || (_enemyType == EnemyType.SmallAsteroid))
            {
                _playerStatisticsController.AsteroidKilled();
            }

            if (_enemyType == EnemyType.UFO)
            {
                _playerStatisticsController.UfoKilled();
            }
        }
    }
}