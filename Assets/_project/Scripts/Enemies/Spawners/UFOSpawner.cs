using Cysharp.Threading.Tasks;
using System.Threading;

namespace Enemies.Spawners
{
    public class UFOSpawner : AbstractEnemySpawner
    {
        private void Start()
        {
            TimeToSpawn = СonfigController.GetUfoTimeToSpawn();
            UniTaskVoid spawnEnemies = SpawnUFO();
        }

        private async UniTaskVoid SpawnUFO()
        {
            Cts = new CancellationTokenSource();

            while (!Cts.IsCancellationRequested)
            {
                await UniTask.Delay(TimeToSpawn, cancellationToken: Cts.Token);

                Enemy ufo = SpawnEnemy(EnemyType.UFO);
                EnemyCollision enemyCollision = ufo.GetEnemyCollision();

                enemyCollision.Killed += ScoreController.EnemyKilled;
                enemyCollision.Killed += PlayerStatisticsController.EnemyKilled;
            }
        }
    }
}