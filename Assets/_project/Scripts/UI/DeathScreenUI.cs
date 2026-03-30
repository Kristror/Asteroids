using Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilites;
using Zenject;

namespace UI
{
    public class DeathScreenUI : MonoBehaviour
    {
        public Action RestartGame;

        [SerializeField] private TMP_Text _textScore;
        [SerializeField] private Button _restartGame;
        [SerializeField] private GameObject _deathScreen;


        private SceneController _sceneController;
        private TimeController _timeController;
        private ScoreController _scoreController;

        private const string scoreText = "Score : ";

        private void Start()
        {
            _restartGame.onClick.AddListener(StartRestartGame);
            _deathScreen.SetActive(false);
        }

        [Inject]
        public void Construct(PlayerController playerController, ScoreController scoreController)
        {
            playerController.PlayerDeath += PlayerDeath;
            _scoreController = scoreController;
        }

        private void PlayerDeath()
        {
            _deathScreen.SetActive(true);
            _textScore.text = scoreText + _scoreController.PlayerScore;
        }

        private void StartRestartGame()
        {
            RestartGame?.Invoke();
        }
    }
}