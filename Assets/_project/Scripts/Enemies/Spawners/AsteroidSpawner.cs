using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Enemies.Spawners
{
    public class AsteroidSpawner : AbstractEnemySpawner
    {
        private int _amountOfPieces;

        private const float SMALL_ASTEROID_SPAWN_OFFSET = 0.2f;

        private void Start()
        {
            TimeToSpawn = _configController.GetAsteroidTimeToSpawn();
            _amountOfPieces = _configController.GetAmountOfPieces();

            UniTaskVoid spawnEnemies = SpawnAsteroid();            
        }

        private async UniTaskVoid SpawnAsteroid()
        {
            Cts = new CancellationTokenSource();

            while (!Cts.IsCancellationRequested)
            {
                await UniTask.Delay(TimeToSpawn, cancellationToken: Cts.Token);

                Enemy asteroid = SpawnEnemy(EnemyType.Asteroid);

                EnemyCollision enemyCollision = asteroid.GetEnemyCollision();

                enemyCollision.KilledByBullet += SpawnSmallAsteroids;

                RandomRotate(asteroid);
            }
        }

        private void RandomRotate(Enemy asteroid)
        {
            Vector2 screenSize = GetScreenSizeInUnits();

            float x = Random.Range(0, screenSize.x);
            float y = Random.Range(0, screenSize.y);

            Vector2 direction = new Vector3(x, y) - asteroid.Position;
            asteroid.Rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }

        private void SpawnSmallAsteroids(EnemyCollision enemyCollision)
        {
            Vector2 collisionPosition = enemyCollision.Position;

            for (int i = 0; i < _amountOfPieces; i++)
            {
                float x = collisionPosition.x + Random.Range(-SMALL_ASTEROID_SPAWN_OFFSET, SMALL_ASTEROID_SPAWN_OFFSET);
                float y = collisionPosition.y + Random.Range(-SMALL_ASTEROID_SPAWN_OFFSET, SMALL_ASTEROID_SPAWN_OFFSET);

                Enemy smallAsteroid = SpawnEnemy(EnemyType.SmallAsteroid, new Vector2(x, y));             
            }

            enemyCollision.KilledByBullet += SpawnSmallAsteroids;
        }

        private Vector2 GetScreenSizeInUnits()
        {            
            float screenHeightInUnits = MainCamera.orthographicSize * 2;

            float screenWidthInUnits = screenHeightInUnits * MainCamera.aspect;

            return new Vector2(screenWidthInUnits, screenHeightInUnits);
        }
    }
}