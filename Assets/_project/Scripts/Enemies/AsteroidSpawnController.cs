using UnityEngine;
using Utilites;

namespace Enemies
{
    public class AsteroidSpawnController : EnemyControllerBase
    {

        [SerializeField, Min(1)] private int _amountOfpieces;
        [SerializeField] private GameObject _smallAsteroid;

        private SmallAsteroidFactory _smallAsteroidFactory;

        private void Start()
        {
            _factory = new AsteroidFactory(_enemyObject);
            _smallAsteroidFactory = new SmallAsteroidFactory(_smallAsteroid);
        }

        private void Update()
        {
            SpawnAsteroid();
        }        

        private void SpawnAsteroid()
        {
            if (ShouldSpawnEnemy())
            {
                GameObject asteroidObject = SpawnEnemy();

                Asteroid asteroid = asteroidObject.GetComponent<Asteroid>();

                asteroid.Killed += SpawnSmallAsteroids;
                asteroid.Destroyed += _scoreController.KilledEnemy; 

                Vector2 screenSize = GetScreenSizeInUnits();

                float x = Random.Range(0, screenSize.x);
                float y = Random.Range(0, screenSize.y);

                Vector2 direction = new Vector3(x, y) - asteroidObject.transform.position;
                asteroidObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            }
        }

        private void SpawnSmallAsteroids()
        {
            for (int i = 0; i < _amountOfpieces; i++)
            {
                GameObject smallAsteroid = SpawnEnemy();

                Asteroid asteroid = smallAsteroid.GetComponent<Asteroid>();
                asteroid.Destroyed += _scoreController.KilledEnemy;

                smallAsteroid.transform.position = new Vector2(smallAsteroid.transform.position.x + Random.Range(-0.1f, 0.1f),
                    smallAsteroid.transform.position.y + Random.Range(-0.1f, 0.1f));                
            }
        }

        private Vector2 GetScreenSizeInUnits()
        {            
            float screenHeightInUnits = _mainCamera.orthographicSize * 2;

            float screenWidthInUnits = screenHeightInUnits * _mainCamera.aspect;

            return new Vector2(screenWidthInUnits, screenHeightInUnits);
        }

    }
}