using UnityEngine;

namespace Enemies
{
    public class UFOSpawnController : EnemyControllerBase
    {
        private GameObject _playerObject;

        private void Start()
        {
            _factory = new UFOFactory(_enemyObject);
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
                GameObject ufoObject = SpawnEnemy();

                UFOMovement ufoMovement = ufoObject.GetComponent<UFOMovement>();
                UFO ufo = ufoObject.GetComponent<UFO>();

                ufo.Destroyed += _scoreController.KilledEnemy;

                ufoMovement.SetPlayer(_playerObject);
            }
        }
    }
}