using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeathUIView : MonoBehaviour
    {
        public Button.ButtonClickedEvent RestartOnClick => _restartGameButton.onClick;
        public Button.ButtonClickedEvent BackToMenuOnClick => _backToMenuButton.onClick;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private GameObject _deathScreen;

        public void ShowScore(string score)
        {
            _scoreText.text = score;
        }

        public void SetActiveDeathScreen(bool active)
        {
            _deathScreen.SetActive(active);
        }
    }
}