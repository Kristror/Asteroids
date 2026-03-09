using UnityEngine;

namespace Enemies
{
    public class EnemyFactory 
    {
        private GameObject _asteroidObject;
        private GameObject _smallAsteroidObject;
        private GameObject _ufoObject;

        public EnemyFactory() 
        {
            _asteroidObject = Resources.Load<GameObject>("Asteroid");
            _smallAsteroidObject = Resources.Load<GameObject>("SmallAsteroid");
            _ufoObject = Resources.Load<GameObject>("UFO");
        }

        public Enemy CreateEnemy(EnemyType enemyType,Vector2 position) 
        {
            GameObject enemyObject;
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    enemyObject = _asteroidObject;
                    break;
                case EnemyType.SmallAsteroid:
                    enemyObject = _smallAsteroidObject;
                    break;
                case EnemyType.UFO:
                    enemyObject = _ufoObject;
                    break;
                default:
                    enemyObject = _asteroidObject;
                    break;
            }

            Enemy enemy = new Enemy(GameObject.Instantiate(enemyObject,position, Quaternion.identity));
            return enemy;
        }
    }
}