using UnityEngine;
using Utilites;

namespace Enemies
{
    public abstract class EnemyControllerBase : MonoBehaviour
    {
        [SerializeField] protected GameObject _enemyObject;
        [SerializeField, Min(0)] private float _timeToSpawn;

        private float _timeOfLastSpawn;

        protected BaseFactory _factory;
        protected Camera _mainCamera;

        protected ScoreController _scoreController;

        private void Awake()
        {
            _timeOfLastSpawn = Time.time;
            _mainCamera = Camera.main;
        }

        public void SetScoreScontroller(ScoreController scoreController)
        {
            _scoreController = scoreController;
        }

        protected bool ShouldSpawnEnemy()
        {
            if (_timeOfLastSpawn < Time.time - _timeToSpawn)
            {
                return true;
            }
            return false;
        }

        protected GameObject SpawnEnemy()
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            _timeOfLastSpawn = Time.time;
            return _factory.CreateEnemy(spawnPosition).gameObject;

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