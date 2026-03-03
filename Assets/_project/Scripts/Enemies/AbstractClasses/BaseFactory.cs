using UnityEngine;

namespace Enemies
{
    public abstract class BaseFactory 
    {
        protected GameObject _enemyObject;

        public BaseFactory( GameObject enemyObject)
        {
            _enemyObject = enemyObject;
        }

        public BaseEnemy CreateEnemy(Vector2 position) 
        {
            GameObject enemy = GameObject.Instantiate(_enemyObject, position, Quaternion.identity);
            return enemy.GetComponent<BaseEnemy>();
        }
    }
}