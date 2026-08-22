using System.Threading;
using UnityEngine;
using Zenject;

namespace Enemies.Spawners
{
    public abstract class AbstractEnemySpawner : MonoBehaviour
    {
        [SerializeField, Min(0)] protected int TimeToSpawn;
        protected Camera MainCamera;
        protected CancellationTokenSource Cts;

        private EnemyFactory _factory;


        [Inject]
        private void Construct(EnemyFactory factory, Camera camera)
        {
            _factory = factory;
            MainCamera = camera;
        }

        private void OnDestroy()
        {
            if (Cts != null && !Cts.IsCancellationRequested)
            {
                Cts.Cancel();
                Cts?.Dispose();
            }
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

            return MainCamera.ViewportToWorldPoint(viewportPos);
        }
    }
}