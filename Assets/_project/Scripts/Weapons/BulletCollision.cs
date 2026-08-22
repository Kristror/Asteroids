using UnityEngine;
using Enemies;

namespace Weapons
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletCollision : MonoBehaviour
    {
        [SerializeField] private BulletMovement _bulletMovement;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<EnemyCollision>(out _))
            {
                _bulletMovement.StopBullet();
            }
        }
    }
}