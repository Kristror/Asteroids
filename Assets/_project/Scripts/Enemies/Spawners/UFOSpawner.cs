using Cysharp.Threading.Tasks;
using System.Threading;

namespace Enemies.Spawners
{
    public class UFOSpawner : AbstractEnemySpawner
    {
        private void Start()
        {
            UniTaskVoid spawnEnemies = SpawnUFO();
        }

        private async UniTaskVoid SpawnUFO()
        {
            Cts = new CancellationTokenSource();

            while (true)
            {
                await UniTask.Delay(TimeToSpawn, cancellationToken: Cts.Token);

                Enemy ufo = SpawnEnemy(EnemyType.UFO);
            }
        }
    }
}