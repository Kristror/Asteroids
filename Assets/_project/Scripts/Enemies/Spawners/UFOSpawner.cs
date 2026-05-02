namespace Enemies.Spawners
{
    public class UFOSpawner : AbstractEnemySpawner
    {
        private void Update()
        {
            SpawnUFO();
        }

        private void SpawnUFO()
        {
            if (ShouldSpawnEnemy())
            {
                Enemy ufo = SpawnEnemy(EnemyType.UFO);
            }
        }
    }
}