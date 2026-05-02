using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyCollision))]
    public abstract class Enemy : MonoBehaviour
    {
        public Vector3 Positon 
        { 
            get 
            { 
               return transform.position; 
            }
            set 
            {
                transform.position = value;
            } 
        }
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

        public void Awake()
        {
            _enemyCollision = GetComponent<EnemyCollision>();
        }

        public void SubscribeToCollison(Action<EnemyCollision> func)
        {
            _enemyCollision.KilledByBullet += func;
        }

    }
}