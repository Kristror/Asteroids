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
        public Vector2 Position => transform.position;

        public event Action<EnemyCollision> KilledByBullet;

        private ScoreController _scoreController;

        [Inject]
        public void Construct(ScoreController scoreController)
        {
            _scoreController = scoreController;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletCollision>(out _))
            {
                KilledByBullet?.Invoke(this);
                _scoreController.EnemyKilled();
                GameObject.Destroy(gameObject);
            }
            if (collision.TryGetComponent<Lazer>(out _))
            {
                _scoreController.EnemyKilled();
                GameObject.Destroy(gameObject);
            }
        }
    }
}