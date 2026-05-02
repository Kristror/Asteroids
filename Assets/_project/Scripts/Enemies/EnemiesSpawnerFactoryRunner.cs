using Zenject;

namespace Enemies.Spawners
{
    public class EnemiesSpawnerFactoryRunner : IInitializable
    {
        private AsteroidSpawnerFactory _asteroidSpawnerFactor;
        private UFOSpawnerFactory _uFOSpawnerFactory;
        public EnemiesSpawnerFactoryRunner(AsteroidSpawnerFactory asteroidSpawnerFactory, UFOSpawnerFactory uFOSpawnerFactory)
        {
            _asteroidSpawnerFactor = asteroidSpawnerFactory;
            _uFOSpawnerFactory = uFOSpawnerFactory;
        }

        public void Initialize()
        {
            _asteroidSpawnerFactor.Create();
            _uFOSpawnerFactory.Create();
        }
    }
    
}