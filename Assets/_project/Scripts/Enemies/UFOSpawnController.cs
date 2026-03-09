using UnityEngine;

namespace Enemies
{
    public class UFOSpawnController : AbstractEnemySpawnController
    {
        private GameObject _playerObject;

        private void Start()
        {
            _factory = new EnemyFactory();
        }

        private void Update()
        {
            SpawnUFO();
        }

        public void SetPlayer(GameObject playerObject)
        {
            _playerObject = playerObject;
        }

        private void SpawnUFO()
        {
            if (ShouldSpawnEnemy())
            {
                Enemy ufo = SpawnEnemy(EnemyType.UFO);

                UFOMovement ufoMovement = ufo.EnemyInstance.GetComponent<UFOMovement>();

                //ufo.Destroyed += _scoreController.KilledEnemy;

                ufoMovement.SetPlayer(_playerObject);
            }
        }
    }
}