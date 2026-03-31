using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy
    {
        public Action Destroyed
        {
            get { return _enemyCollision.Destroyed; }
            set { _enemyCollision.Destroyed = value; }
        }
        public Action<Vector2> Killed
        {
            get { return _enemyCollision.Killed; }
            set { _enemyCollision.Killed = value; }
        }

        public GameObject EnemyInstance { get; private set; }

        private EnemyCollision _enemyCollision;

        public Enemy(GameObject enemyObject)
        {
            EnemyInstance = enemyObject;
            _enemyCollision = EnemyInstance.GetComponent<EnemyCollision>();
        }

    }
}