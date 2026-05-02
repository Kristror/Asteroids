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
                    enemy = _asteroidFactory.Create();
                    break;
                case EnemyType.SmallAsteroid:
                    enemy = _smallAsteroidFactory.Create();
                    break;
                case EnemyType.UFO:
                    enemy = _ufoFactory.Create();
                    break;
                default:
                    enemy = _asteroidFactory.Create();
                    break;
            }

            enemy.Positon = position;

            return enemy;
        }
    }
}