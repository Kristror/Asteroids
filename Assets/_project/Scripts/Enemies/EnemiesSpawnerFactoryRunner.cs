using Zenject;

namespace Enemies.Spawners
{
    public class EnemiesSpawnerFactoryRunner : IInitializable
    {
        private AsteroidSpawnerFactory _asteroidSpawnerFactory;
        private UFOSpawnerFactory _ufoSpawnerFactory;

        public EnemiesSpawnerFactoryRunner(AsteroidSpawnerFactory asteroidSpawnerFactory, UFOSpawnerFactory ufoSpawnerFactory)
        {
            _asteroidSpawnerFactory = asteroidSpawnerFactory;
            _ufoSpawnerFactory = ufoSpawnerFactory;
        }

        public void Initialize()
        {
            _asteroidSpawnerFactory.Create();
            _ufoSpawnerFactory.Create();
        }
    }
    
}