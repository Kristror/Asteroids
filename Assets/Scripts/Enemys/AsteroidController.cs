using UnityEngine;


public class AsteroidController : EnemyControllerBase
{
    private void Update()
    {
        SpawnAsteroid();
    }

    private void SpawnAsteroid()
    {
        if (isTimeToSpawnEnemy())
        {
            GameObject asteroid =  SpawnEnemy();

            asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }
    
}
