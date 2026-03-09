using UnityEngine;
using Enemies;
using System;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollision : MonoBehaviour
    {
        private Action PlayerDeath;

        public void SetAction(Action playerDeath)
        {
            PlayerDeath = playerDeath;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyCollision>(out _))
            {
                PlayerDeath?.Invoke();
            }
        }
    }
}