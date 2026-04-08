using UnityEngine;

namespace Enemies.Spawners
{
    public class EnemyFactory
    {

        private AsteroidFactory _asteroidFactory;
        private SmallAsteroidFactory _smallAsteroidFactory;
        private UFOFactory _ufoFactory;

        public EnemyFactory(AsteroidFactory asteroidFactory, SmallAsteroidFactory smallAsteroidFactory, UFOFactory ufoFactory) 
        {
            _asteroidFactory = asteroidFactory;
            _smallAsteroidFactory = smallAsteroidFactory;
            _ufoFactory = ufoFactory;
        }

        public Enemy Create(EnemyType enemyType,Vector2 position) 
        {
            Enemy enemy;

            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    enemy = new Enemy(_asteroidFactory.Create().gameObject);
                    break;
                case EnemyType.SmallAsteroid:
                    enemy = new Enemy(_smallAsteroidFactory.Create().gameObject);
                    break;
                case EnemyType.UFO:
                    enemy = new Enemy(_ufoFactory.Create().gameObject);
                    break;
                default:
                    enemy = new Enemy(_asteroidFactory.Create().gameObject);
                    break;
            }

            enemy.EnemyInstance.transform.position = position;
            return enemy;
        }
    }
}