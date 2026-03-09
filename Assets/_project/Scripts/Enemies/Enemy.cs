using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy
    {
        public Action Destroyed;
        public Action Killed;

        public GameObject EnemyInstance { get; private set; }

        public Enemy(GameObject enemyObject)
        {
            //подпись
            EnemyInstance = enemyObject;           
        }        
    }
}