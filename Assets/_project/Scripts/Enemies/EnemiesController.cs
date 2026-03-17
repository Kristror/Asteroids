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

        public EnemiesController(PlayerController playerController, ScoreController scoreController, BorderController borderController)
        {
            GameObject _enemySpawnerPrefab = Resources.Load<GameObject>("EnemySpawner");
            GameObject enemySpawner = GameObject.Instantiate(_enemySpawnerPrefab);

            _asteroidSpawnController = enemySpawner.GetComponent<AsteroidSpawnController>();
            _ufoSpawnController = enemySpawner.GetComponent<UFOSpawnController>();

            SetPlayer(playerController);
            SetDependencies(scoreController,borderController);
        }

        private void SetDependencies(ScoreController scoreController,BorderController borderController)
        {
            _asteroidSpawnController.SetDependencies(scoreController,borderController);
            _ufoSpawnController.SetDependencies(scoreController, borderController);
        }

        private void SetPlayer(PlayerController playerController)
        {
            _ufoSpawnController.SetPlayer(playerController);
        }
    }
    
}