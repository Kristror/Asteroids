using UnityEngine;
using Enemies;
using System;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollision : MonoBehaviour
    {
        public event Action PlayerDeath;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyCollision>(out _))
            {
                PlayerDeath?.Invoke();
            }
        }
    }
}