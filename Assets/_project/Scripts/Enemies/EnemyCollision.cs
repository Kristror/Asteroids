using Enemies.Spawners;
using System;
using UnityEngine;
using Weapons;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollision : MonoBehaviour
    {
        public Vector2 Position => transform.position;
        public EnemyType EnemyType;
        public WeaponType KilledBy;

        public event Action<EnemyCollision> Killed;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IWeapon>(out IWeapon weapon))
            {
                KilledBy = weapon.Type;
                Death();
            }
        }

        private void Death()
        {
            Killed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}