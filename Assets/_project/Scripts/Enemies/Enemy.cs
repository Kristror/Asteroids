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
        public Action Killed
        {
            get { return _enemyCollision.Killed; }
            set { _enemyCollision.Killed = value; }
        }

        private EnemyCollision _enemyCollision;
        public GameObject EnemyInstance { get; private set; }

        public Enemy(GameObject enemyObject)
        {
            EnemyInstance = enemyObject;
            _enemyCollision = EnemyInstance.GetComponent<EnemyCollision>();
        }

    }
}