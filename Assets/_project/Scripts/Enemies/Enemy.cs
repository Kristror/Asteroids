using Enemies.Spawners;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Enemies
{
    [RequireComponent(typeof(EnemyCollision))]
    public abstract class Enemy : MonoBehaviour
    {
        public Vector3 Positon => transform.position;

        public Quaternion Rotation
        {
            get
            {
                return transform.rotation;
            }
            set
            {
                transform.rotation = value;
            }
        }

        private EnemyCollision _enemyCollision;

        private void Awake()
        {
            _enemyCollision = GetComponent<EnemyCollision>();            
        }

        public void Intitialize(EnemyType type, Vector2 position)
        {
            transform.position = position;
            _enemyCollision.SetType(type);
        }

        public void SubscribeToCollison(Action<EnemyCollision> func)
        {
            _enemyCollision.KilledByBullet += func;
        }

    }
}