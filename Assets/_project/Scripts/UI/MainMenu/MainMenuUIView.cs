using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUIView : MonoBehaviour
    {
        public Button.ButtonClickedEvent StartButtonOnClick => _startButton.onClick;
        public Button.ButtonClickedEvent StoreButtonOnClick => _storeButton.onClick;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _storeButton;
    }
}