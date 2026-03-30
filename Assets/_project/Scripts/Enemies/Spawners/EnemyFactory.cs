using UnityEngine;
using Zenject;

namespace Enemies.Spawners
{
    public class EnemyFactory
    {
        private readonly DiContainer _container;

        private GameObject _asteroidObject;
        private GameObject _smallAsteroidObject;
        private GameObject _ufoObject;

        public EnemyFactory(DiContainer container) 
        {
            _container = container;

            _asteroidObject = Resources.Load<GameObject>("Asteroid");
            _smallAsteroidObject = Resources.Load<GameObject>("SmallAsteroid");
            _ufoObject = Resources.Load<GameObject>("UFO");
        }

        public Enemy Create(EnemyType enemyType,Vector2 position) 
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

            Enemy enemy = new Enemy(_container.InstantiatePrefab(enemyObject));
            enemy.EnemyInstance.transform.position = position;
            return enemy;
        }
    }
}