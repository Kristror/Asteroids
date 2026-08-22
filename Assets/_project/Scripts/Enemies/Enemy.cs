using Enemies.Spawners;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyCollision))]
    public abstract class Enemy : MonoBehaviour
    {
        public Vector3 Position => transform.position;

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

        public void Initialize(EnemyType type, Vector2 position)
        {
            transform.position = position;
            _enemyCollision.SetType(type);
        }

        private void Awake()
        {
            _enemyCollision = GetComponent<EnemyCollision>();            
        }

        public EnemyCollision GetEnemyCollision()
        {
            return _enemyCollision;
        }
    }
}