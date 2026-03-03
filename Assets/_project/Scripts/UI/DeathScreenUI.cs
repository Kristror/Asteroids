using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilites;

namespace UI
{
    public class DeathScreenUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textScore;
        [SerializeField] private Button _restartGame;
        [SerializeField] private GameObject _deathScreen;

        private PlayerCollision _playerCollision;
        private SceneController _sceneController;
        private TimeController _timeController;
        private ScoreController _scoreController;

        private string scoreText = "Score : ";

        private void Start()
        {
            _restartGame.onClick.AddListener(RestartGame);
            _deathScreen.SetActive(false);
        }

        public void SetDependencies(GameObject playerObject, SceneController sceneController, TimeController timeController, ScoreController scoreController)
        {
            _playerCollision = playerObject.GetComponentInChildren<PlayerCollision>();
            _sceneController = sceneController;
            _timeController = timeController;
            _scoreController = scoreController;
        }

        private void Update()
        {
            if (_playerCollision.IsPlayerDead)
            {
                _deathScreen.SetActive(true);
                _textScore.text = scoreText + _scoreController.PlayerScore;
            }
        }

        private void RestartGame()
        {
            _timeController.ResumeTime();
            _sceneController.ReloadGame();
        }
    }
}