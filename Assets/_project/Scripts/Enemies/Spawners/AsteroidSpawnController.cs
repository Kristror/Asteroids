using UnityEngine;

namespace Enemies.Spawners
{
    public class AsteroidSpawnController : AbstractEnemySpawnController
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

                asteroid.EnemyCollision.Killed += SpawnSmallAsteroids;
                asteroid.EnemyCollision.Destroyed += _scoreController.KilledEnemy;

                RandomRotate(asteroid);
            }
        }

        private void RandomRotate(Enemy asteroid)
        {
            Vector2 screenSize = GetScreenSizeInUnits();

            float x = Random.Range(0, screenSize.x);
            float y = Random.Range(0, screenSize.y);

            Vector2 direction = new Vector3(x, y) - asteroid.EnemyInstance.transform.position;
            asteroid.EnemyInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }

        private void SpawnSmallAsteroids(Vector2 position)
        {
            for (int i = 0; i < _amountOfpieces; i++)
            {
                Enemy smallAsteroid = SpawnEnemy(EnemyType.SmallAsteroid, position);

                smallAsteroid.EnemyCollision.Destroyed += _scoreController.KilledEnemy;

                smallAsteroid.EnemyInstance.transform.position = new Vector2(smallAsteroid.EnemyInstance.transform.position.x + Random.Range(-_smallAsteroidSpawnOffSet, _smallAsteroidSpawnOffSet),
                    smallAsteroid.EnemyInstance.transform.position.y + Random.Range(-_smallAsteroidSpawnOffSet, _smallAsteroidSpawnOffSet));                
            }
        }

        private Vector2 GetScreenSizeInUnits()
        {            
            float screenHeightInUnits = _mainCamera.orthographicSize * 2;

            float screenWidthInUnits = screenHeightInUnits * _mainCamera.aspect;

            return new Vector2(screenWidthInUnits, screenHeightInUnits);
        }
    }
}