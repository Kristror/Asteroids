using Player;
using UnityEngine;

namespace Enemies.Spawners
{
    public class UFOSpawnController : AbstractEnemySpawnController
    {
        private PlayerController _playerController;

        private void Start()
        {
            _factory = new EnemyFactory();
        }

        private void Update()
        {
            SpawnUFO();
        }

        public void SetPlayer(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void SpawnUFO()
        {
            if (ShouldSpawnEnemy())
            {
                Enemy ufo = SpawnEnemy(EnemyType.UFO);

                UFOMovement ufoMovement = ufo.EnemyInstance.GetComponent<UFOMovement>();

                ufo.Killed += _scoreController.KilledEnemy;
                ufo.Destroyed += _scoreController.KilledEnemy;

                ufoMovement.SetPlayer(_playerController.PlayerInstance);
            }
        }
    }
}