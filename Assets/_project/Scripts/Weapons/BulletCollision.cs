using UnityEngine;
using Enemies;

namespace Weapons
{
    [RequireComponent(typeof(Collider2D))]
    public class BulletCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<Enemy>(out _))
            {
                Destroy(gameObject);
            }
        }
    }
}