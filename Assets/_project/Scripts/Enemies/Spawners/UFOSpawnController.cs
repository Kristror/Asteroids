namespace Enemies.Spawners
{
    public class UFOSpawnController : AbstractEnemySpawnController
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

                ufo.EnemyCollision.Destroyed += _scoreController.KilledEnemy;
            }
        }
    }
}