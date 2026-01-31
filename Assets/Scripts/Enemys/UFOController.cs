using UnityEngine;


public class UFOController : EnemyControllerBase
{
    private GameObject _playerObject;

    private void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(_playerObject.ToString());
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