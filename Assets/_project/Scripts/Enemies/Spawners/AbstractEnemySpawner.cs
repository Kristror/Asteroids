using PlayerAnalytics;
using System.Threading;
using UnityEngine;
using Utilites;
using Zenject;

namespace Enemies.Spawners
{
    public abstract class AbstractEnemySpawner : MonoBehaviour
    {
        [SerializeField, Min(0)] protected int _timeToSpawn;

        protected ScoreController _scoreController;
        protected EnemyFactory _factory;
        protected Camera _mainCamera;

        protected CancellationTokenSource _enemiesSpawnToken;

        [Inject]
        public void Construct(ScoreController scoreController, EnemyFactory factory, Camera camera)
        {
            _scoreController = scoreController;
            _factory = factory;
            _mainCamera = camera;
        }

        private void OnDestroy()
        {
            _enemiesSpawnToken?.Cancel();
            _enemiesSpawnToken?.Dispose();
        }

        protected Enemy SpawnEnemy(EnemyType enemyType)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            return _factory.Create(enemyType, spawnPosition);
        }

        protected Enemy SpawnEnemy(EnemyType enemyType, Vector2 spawnPosition)
        {
            return _factory.Create(enemyType, spawnPosition);
        }

        private Vector2 GetRandomSpawnPosition()
        {
            int side = Random.Range(0, 4);
            Vector2 viewportPos = Vector2.zero;

            switch (side)
            {
                case 0:
                    viewportPos = new Vector2(Random.value, 1.1f);
                    break;
                case 1:
                    viewportPos = new Vector2(1.1f, Random.value);
                    break;
                case 2:
                    viewportPos = new Vector2(Random.value, -0.1f);
                    break;
                case 3:
                    viewportPos = new Vector2(-0.1f, Random.value);
                    break;
            }

            return _mainCamera.ViewportToWorldPoint(viewportPos);
        }
    }
}