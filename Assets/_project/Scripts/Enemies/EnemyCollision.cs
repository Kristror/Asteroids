using Enemies.Spawners;
using PlayerAnalytics;
using System;
using UnityEngine;
using Utilites;
using Weapons;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollision : MonoBehaviour
    {
        private EnemyType _type;
        public Vector2 Position => transform.position;

        public event Action<EnemyCollision> KilledByBullet;

        private ScoreController _scoreController;
        private PlayerStatisticsController _playerStatisticsController;

        [Inject]
        public void Construct(ScoreController scoreController, PlayerStatisticsController playerStatisticsController)
        {
            _scoreController = scoreController;
            _playerStatisticsController = playerStatisticsController;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletCollision>(out _))
            {
                KilledByBullet?.Invoke(this);
                _scoreController.EnemyKilled();
                UpdateStatistics();

                GameObject.Destroy(gameObject);
            }
            if (collision.TryGetComponent<Lazer>(out _))
            {
                _scoreController.EnemyKilled();
                UpdateStatistics();

                GameObject.Destroy(gameObject);
            }
        }

        public void SetType(EnemyType type)
        {
            _type = type;
        }

        private void UpdateStatistics()
        {
            if ((_type == EnemyType.Asteroid) || (_type == EnemyType.SmallAsteroid))
            {
                _playerStatisticsController.AsteroidKilled();
            }

            if (_type == EnemyType.UFO)
            {
                _playerStatisticsController.UfoKilled();
            }
        }
    }
}