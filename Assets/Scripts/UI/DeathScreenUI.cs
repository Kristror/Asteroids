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
    private string scoreText = "Score : ";


    private void Start()
    {
        _restartGame.onClick.AddListener(RestartGame);

        _playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();

        _deathScreen.SetActive(false);
    }

    private void Update()
    {
        if (_playerCollision.IsPlayerDead) 
        {
            _deathScreen.SetActive(true);
            _textScore.text = scoreText + Score.PlayerScore;
        }
    }

    private void RestartGame()
    {
        TimeController.ResumeTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}