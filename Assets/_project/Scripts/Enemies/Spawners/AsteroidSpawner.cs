using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Enemies.Spawners
{
    public class AsteroidSpawner : AbstractEnemySpawner
    {
        [SerializeField, Min(1)] private int _amountOfpieces;

        private const float _smallAsteroidSpawnOffSet = 0.2f;

        private void Awake()
        {            
            UniTaskVoid spawnEnemies = SpawnAsteroid();            
        }

        private async UniTaskVoid SpawnAsteroid()
        {
            _enemiesSpawnToken = new CancellationTokenSource();

            while (true)
            {
                await UniTask.Delay(_timeToSpawn, cancellationToken: _enemiesSpawnToken.Token);

                Enemy asteroid = SpawnEnemy(EnemyType.Asteroid);

                asteroid.SubscribeToCollison(SpawnSmallAsteroids);

                RandomRotate(asteroid);
            }
        }

        private void RandomRotate(Enemy asteroid)
        {
            Vector2 screenSize = GetScreenSizeInUnits();

            float x = Random.Range(0, screenSize.x);
            float y = Random.Range(0, screenSize.y);

            Vector2 direction = new Vector3(x, y) - asteroid.Positon;
            asteroid.Rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }

        public void SpawnSmallAsteroids(EnemyCollision enemyCollision)
        {
            Vector2 collisionPosition = enemyCollision.Position;

            for (int i = 0; i < _amountOfpieces; i++)
            {
                float x = collisionPosition.x + Random.Range(-_smallAsteroidSpawnOffSet, _smallAsteroidSpawnOffSet);
                float y = collisionPosition.y + Random.Range(-_smallAsteroidSpawnOffSet, _smallAsteroidSpawnOffSet);

                Enemy smallAsteroid = SpawnEnemy(EnemyType.SmallAsteroid, new Vector2(x, y));             
            }
            Unsubscribe(enemyCollision);
        }

        private void Unsubscribe(EnemyCollision enemy)
        {
            enemy.KilledByBullet -= SpawnSmallAsteroids;
        }

        private Vector2 GetScreenSizeInUnits()
        {            
            float screenHeightInUnits = _mainCamera.orthographicSize * 2;

            float screenWidthInUnits = screenHeightInUnits * _mainCamera.aspect;

            return new Vector2(screenWidthInUnits, screenHeightInUnits);
        }
    }
}