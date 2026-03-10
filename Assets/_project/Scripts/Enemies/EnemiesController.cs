using Enemies.Spawners;
using Player;
using UnityEngine;
using Utilites;

namespace Enemies
{
    public class EnemiesController
    {
        private AsteroidSpawnController _asteroidSpawnController;
        private UFOSpawnController _ufoSpawnController;

        public EnemiesController(PlayerController playerController, ScoreController scoreController)
        {
            GameObject _enemySpawnerPrefab = Resources.Load<GameObject>("EnemySpawner");
            GameObject enemySpawner = GameObject.Instantiate(_enemySpawnerPrefab);

            _asteroidSpawnController = enemySpawner.GetComponent<AsteroidSpawnController>();
            _ufoSpawnController = enemySpawner.GetComponent<UFOSpawnController>();

            SetPlayer(playerController);
            SetScoreController(scoreController);
        }

        private void SetScoreController(ScoreController scoreController)
        {
            _asteroidSpawnController.SetScoreController(scoreController);
            _ufoSpawnController.SetScoreController(scoreController);
        }

        private void SetPlayer(PlayerController playerController)
        {
            _ufoSpawnController.SetPlayer(playerController);
        }
    }
    
}