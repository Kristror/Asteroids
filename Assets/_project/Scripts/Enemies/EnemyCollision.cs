using System;
using UnityEngine;
using Weapons;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollision : MonoBehaviour
    {
        public Action Killed;
        public Action Destroyed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BulletCollision>(out _))
            {
                Killed?.Invoke();
                GameObject.Destroy(gameObject);
            }
            if (collision.TryGetComponent<Lazer>(out _))
            {
                Destroyed?.Invoke();
                GameObject.Destroy(gameObject);
            }
        }
    }
}