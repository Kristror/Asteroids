using UnityEngine;
using Utilites;

namespace Enemies.Spawners
{
    public abstract class AbstractEnemySpawnController : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _timeToSpawn;

        protected ScoreController _scoreController;
        protected BorderController _borderController;
        protected EnemyFactory _factory;
        protected Camera _mainCamera;

        private float _timeOfLastSpawn;

        private void Awake()
        {
            _timeOfLastSpawn = Time.time;
            _mainCamera = Camera.main;
            _factory = new EnemyFactory();
        }

        public void SetDependencies(ScoreController scoreController, BorderController borderController)
        {
            _scoreController = scoreController;
            _borderController = borderController;
        }

        protected bool ShouldSpawnEnemy()
        {
            if (_timeOfLastSpawn < Time.time - _timeToSpawn)
            {
                return true;
            }
            return false;
        }

        protected Enemy SpawnEnemy(EnemyType enemyType)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            _timeOfLastSpawn = Time.time;
            return _factory.CreateEnemy(enemyType, spawnPosition);

        }

        protected Enemy SpawnEnemy(EnemyType enemyType, Vector2 spawnPosition)
        {
            _timeOfLastSpawn = Time.time;
            return _factory.CreateEnemy(enemyType, spawnPosition);
        }

        private Vector2 GetRandomSpawnPosition()
        {
            int side = Random.Range(0, 4);
            Vector2 viewportPos = Vector2.zero;

            switch (side)
            {
                case 0:
                    viewportPos = new Vector2(Random.value, 1.1f);
                    break;
                case 1:
                    viewportPos = new Vector2(1.1f, Random.value);
                    break;
                case 2:
                    viewportPos = new Vector2(Random.value, -0.1f);
                    break;
                case 3:
                    viewportPos = new Vector2(-0.1f, Random.value);
                    break;
            }

            return _mainCamera.ViewportToWorldPoint(viewportPos);
        }
    }
}