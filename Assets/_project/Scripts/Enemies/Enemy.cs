using UnityEngine;

namespace Enemies
{
    public class Enemy
    {
        public GameObject EnemyInstance { get; private set; }

        public EnemyCollision EnemyCollision;

        public Enemy(GameObject enemyObject)
        {
            EnemyInstance = enemyObject;
            EnemyCollision = EnemyInstance.GetComponent<EnemyCollision>();
        }

    }
}