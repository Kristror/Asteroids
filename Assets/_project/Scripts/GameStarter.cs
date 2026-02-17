using UnityEngine;


public class GameStarter : MonoBehaviour
{
    [SerializeField] GameObject _prefabPlayer;
    [SerializeField] GameObject _enemySpawner;
    [SerializeField] GameObject _prefabUI;

    private void Awake()
    {
        GameObject player = GameObject.Instantiate(_prefabPlayer);
        GameObject enemySpawner = GameObject.Instantiate(_enemySpawner);
        GameObject ui = GameObject.Instantiate(_prefabUI);

        enemySpawner.GetComponent<UFOSpawnController>().SetPlayer(player);

        ui.GetComponentInChildren<DeathScreenUI>().SetPlayer(player);
        ui.GetComponentInChildren<UIplayerStats>().SetPlayer(player);

        ScoreController.ResetScore();
    }
}