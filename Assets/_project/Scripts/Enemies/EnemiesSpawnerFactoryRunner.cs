using Zenject;

namespace Enemies.Spawners
{
    public class EnemiesSpawnerFactoryRunner : IInitializable
    {
        private AsteroidSpawnerFactory _asteroidSpawnerFactory;
        private UFOSpawnerFactory _uFOSpawnerFactory;
        public EnemiesSpawnerFactoryRunner(AsteroidSpawnerFactory asteroidSpawnerFactory, UFOSpawnerFactory uFOSpawnerFactory)
        {
            _asteroidSpawnerFactory = asteroidSpawnerFactory;
            _uFOSpawnerFactory = uFOSpawnerFactory;
        }

        public void Initialize()
        {
            _asteroidSpawnerFactory.Create();
            _uFOSpawnerFactory.Create();
        }
    }
    
}