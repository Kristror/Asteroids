using UnityEngine;
using Enemies;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollision : MonoBehaviour
    {
        public bool IsPlayerDead { get; private set; }

        private Collider2D _colliderPlayer;

        private void Start()
        {
            _colliderPlayer = GetComponent<Collider2D>();
            IsPlayerDead = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BaseEnemy>(out _))
            {
                IsPlayerDead = true;
                TimeController.StopTime();
            }
        }
    }
}