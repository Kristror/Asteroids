using Player;
using System;
using System.Collections;
using UnityEngine;
using Utilites;

namespace Enemies
{
    public class EnemiesController
    {
        public Action EnemyKilled;

        private AsteroidSpawnController _asteroidSpawnController;
        private UFOSpawnController _ufoSpawnController;

        public EnemiesController(PlayerController playerController)
        {
            GameObject _enemySpawnerPrefab = Resources.Load<GameObject>("EnemySpawner");
            GameObject enemySpawner = GameObject.Instantiate(_enemySpawnerPrefab);

            _asteroidSpawnController = enemySpawner.GetComponent<AsteroidSpawnController>();
            _ufoSpawnController = enemySpawner.GetComponent<UFOSpawnController>();

            SetPlayer(playerController);
        }

        private void SetDependencies(ScoreController scoreController)
        {
            /////////очки
            _asteroidSpawnController.SetScoreScontroller(scoreController);
            _ufoSpawnController.SetScoreScontroller(scoreController);
        }

        private void SetPlayer(PlayerController playerController)
        {
            _ufoSpawnController.SetPlayer(playerController.playerInstance);
        }
    }
    
}