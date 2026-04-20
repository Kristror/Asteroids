using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy
    {
        public GameObject EnemyInstance { get; private set; }

        private EnemyCollision _enemyCollision;

        public Enemy(GameObject enemyObject)
        {
            EnemyInstance = enemyObject;
            _enemyCollision = EnemyInstance.GetComponent<EnemyCollision>();
        }

        public void SubscribeToCollison(Action<Vector2> func)
        {
            _enemyCollision.KilledByBullet += func;
        }

    }
}