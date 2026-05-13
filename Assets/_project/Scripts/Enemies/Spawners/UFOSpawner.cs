using Cysharp.Threading.Tasks;
using System.Threading;

namespace Enemies.Spawners
{
    public class UFOSpawner : AbstractEnemySpawner
    {
        private void Awake()
        {
            UniTaskVoid spawnEnemies = SpawnUFO();
        }

        private async UniTaskVoid SpawnUFO()
        {
            _enemiesSpawnToken = new CancellationTokenSource();

            while (true)
            {
                await UniTask.Delay(_timeToSpawn, cancellationToken: _enemiesSpawnToken.Token);

                Enemy ufo = SpawnEnemy(EnemyType.UFO);
            }
        }
    }
}