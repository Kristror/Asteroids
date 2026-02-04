using UnityEngine;


public class UFOSpawnController : EnemyControllerBase
{
    private GameObject _playerObject;

    private void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        SpawnUFO();
    }

    private void SpawnUFO()
    {
        if (isTimeToSpawnEnemy())
        {
            GameObject ufo = SpawnEnemy();

            ufo.GetComponent<UFOMovement>().SetPlayer(_playerObject);
        }
    }
}