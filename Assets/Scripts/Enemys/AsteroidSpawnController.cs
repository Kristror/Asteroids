using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class AsteroidSpawnController : EnemyControllerBase
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


            Vector2 screenSize = ScreenSize.GetScreenSizeInUnits();

            float x = Random.Range(0, screenSize.x);
            float y = Random.Range(0, screenSize.y);

            Vector2 direction = new Vector3(x,y) - asteroid.transform.position;
            asteroid.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }
    
}