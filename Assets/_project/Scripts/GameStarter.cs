using UnityEngine;
using UI;
using Enemies;
using Utilites;
using Player;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPlayer;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private GameObject _prefabUI;

    private void Awake()
    {
        SceneController sceneController = new SceneController();
        TimeController timeController = new TimeController();
        ScoreController scoreController = new ScoreController();

        GameObject player = GameObject.Instantiate(_prefabPlayer);
        GameObject enemySpawner = GameObject.Instantiate(_enemySpawner);
        GameObject ui = GameObject.Instantiate(_prefabUI);

        player.GetComponentInChildren<PlayerCollision>().SetDependencies(timeController);
        
        enemySpawner.GetComponent<AsteroidSpawnController>().SetScoreScontroller(scoreController);
        enemySpawner.GetComponent<UFOSpawnController>().SetScoreScontroller(scoreController);

        enemySpawner.GetComponent<UFOSpawnController>().SetPlayer(player);

        ui.GetComponentInChildren<DeathScreenUI>().SetDependencies(player, sceneController, timeController , scoreController);
        ui.GetComponentInChildren<UIplayerStats>().SetPlayer(player);

        scoreController.ResetScore();
    }
}