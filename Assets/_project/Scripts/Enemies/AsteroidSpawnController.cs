using UnityEngine;

namespace Enemies
{
    public class AsteroidSpawnController : EnemyControllerBase
    {
        private void Update()
        {
            SpawnAsteroid();
        }

        private void SpawnAsteroid()
        {
            if (ShouldSpawnEnemy())
            {
                GameObject asteroid = SpawnEnemy();

                Vector2 screenSize = ScreenSize.GetScreenSizeInUnits();

                float x = Random.Range(0, screenSize.x);
                float y = Random.Range(0, screenSize.y);

                Vector2 direction = new Vector3(x, y) - asteroid.transform.position;
                asteroid.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            }
        }

    }
}