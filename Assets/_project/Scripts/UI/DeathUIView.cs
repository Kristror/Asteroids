using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeathUIView : MonoBehaviour
    {
        public Button.ButtonClickedEvent OnClick => _restartGameButon.onClick;

        [SerializeField] private TMP_Text _textScore;
        [SerializeField] private Button _restartGameButon;
        [SerializeField] private GameObject _deathScreen;

        public void ShowScore(string score)
        {
            _textScore.text = score;
        }

        public void SetActiveDeathScreen(bool active)
        {
            _deathScreen.SetActive(active);
        }
    }
}