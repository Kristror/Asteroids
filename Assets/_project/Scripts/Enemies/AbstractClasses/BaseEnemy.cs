using UnityEngine;
using UnityEngine.Events;
using Weapons;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        public UnityAction Destroyed;
        public UnityAction Killed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletCollision>(out _))
            {
                Killed?.Invoke();
                Destroy(gameObject);
            }
            if (collision.TryGetComponent<Lazer>(out _))
            {
                Destroyed?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}