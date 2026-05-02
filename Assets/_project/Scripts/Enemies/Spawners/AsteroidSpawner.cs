using UnityEngine;

namespace Enemies.Spawners
{
    public class AsteroidSpawner : AbstractEnemySpawner
    {
        [SerializeField, Min(1)] private int _amountOfpieces;

        private const float _smallAsteroidSpawnOffSet = 0.2f;

        private void Update()
        {
            SpawnAsteroid();
        }

        private void SpawnAsteroid()
        {
            if (ShouldSpawnEnemy())
            {
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
            for (int i = 0; i < _amountOfpieces; i++)
            {
                Enemy smallAsteroid = SpawnEnemy(EnemyType.SmallAsteroid, enemyCollision.Position);

                float x = smallAsteroid.Positon.x + Random.Range(-_smallAsteroidSpawnOffSet, _smallAsteroidSpawnOffSet);
                float y = smallAsteroid.Positon.y + Random.Range(-_smallAsteroidSpawnOffSet, _smallAsteroidSpawnOffSet);
                smallAsteroid.Positon = new Vector2(x, y);                
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