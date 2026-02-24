using UnityEngine;

namespace Enemies
{
    public class UFOSpawnController : EnemyControllerBase
    {
        private GameObject _playerObject;

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
                UFOMovement ufoMovement = SpawnEnemy().GetComponent<UFOMovement>();

                ufoMovement.SetPlayer(_playerObject);
            }
        }
    }
}