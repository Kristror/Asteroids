using UnityEngine;


public class UFOSpawnController : EnemyControllerBase
{
    private GameObject _playerObject;

    public void SetPlayer(GameObject playerObject)
    {
        _playerObject = playerObject;
    }

    private void Update()
    {
        SpawnUFO();
    }

    private void SpawnUFO()
    {
        if (isTimeToSpawnEnemy())
        {
            UFOMovement ufoMovement = SpawnEnemy().GetComponent<UFOMovement>();

            ufoMovement.SetPlayer(_playerObject);
        }
    }
}