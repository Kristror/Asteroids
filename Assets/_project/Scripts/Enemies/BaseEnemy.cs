using UnityEngine;
using Weapons;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletCollision>(out _))
            {
                ScoreController.KilledEnemy();
                Collision();
                Destroy(gameObject);
            }
            if (collision.TryGetComponent<Lazer>(out _))
            {
                ScoreController.KilledEnemy();
                Destroy(gameObject);
            }
        }

        protected virtual void Collision() { }
    }
}