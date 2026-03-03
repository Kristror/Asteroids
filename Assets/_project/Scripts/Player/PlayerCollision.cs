using UnityEngine;
using Enemies;
using Utilites;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollision : MonoBehaviour
    {
        public bool IsPlayerDead { get; private set; }

        private Collider2D _colliderPlayer;
        private TimeController _timeController;

        private void Start()
        {
            _colliderPlayer = GetComponent<Collider2D>();
            IsPlayerDead = false;
        }

        public void SetDependencies(TimeController timeController)
        {
            _timeController = timeController;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BaseEnemy>(out _))
            {
                IsPlayerDead = true;
                _timeController.StopTime();
            }
        }
    }
}