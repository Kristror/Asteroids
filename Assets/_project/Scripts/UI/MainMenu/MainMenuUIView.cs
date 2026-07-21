using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUIView : MonoBehaviour
    {
        public Button.ButtonClickedEvent OnClick => _startButton.onClick;

        [SerializeField] private Button _startButton;
    }
}