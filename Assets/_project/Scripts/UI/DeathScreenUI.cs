using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathScreenUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private Button _restartGame;
    [SerializeField] private GameObject _deathScreen;

    private PlayerCollision _playerCollision;

    private string scoreText = "ScoreController : ";


    private void Start()
    {
        _restartGame.onClick.AddListener(RestartGame);
        _deathScreen.SetActive(false);
    }

    public void SetPlayer(GameObject playerObject)
    {
        _playerCollision = playerObject.GetComponentInChildren<PlayerCollision>();
    }

    private void Update()
    {
        if (_playerCollision.IsPlayerDead) 
        {
            _deathScreen.SetActive(true);
            _textScore.text = scoreText + ScoreController.PlayerScore;
        }
    }

    private void RestartGame()
    {
        TimeController.ResumeTime();
        SceneController.ReloadGame();
    }
}