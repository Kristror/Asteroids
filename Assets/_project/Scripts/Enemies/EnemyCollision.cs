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
        public event Action<Vector2> KilledByBullet;

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
                KilledByBullet?.Invoke(transform.position);
                _scoreController.EnemyKilled();
                GameObject.Destroy(gameObject);
            }
            if (collision.TryGetComponent<Lazer>(out _))
            {
                _scoreController.EnemyKilled();
                GameObject.Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (KilledByBullet != null)
            {
                Delegate[] subscribers = KilledByBullet.GetInvocationList();

                foreach (Delegate subscriber in subscribers)
                {
                    KilledByBullet -= (Action<Vector2>)subscriber;
                }
            }
        }
    }
}