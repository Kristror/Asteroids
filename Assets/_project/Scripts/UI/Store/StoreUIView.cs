using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StoreUIView : MonoBehaviour
    {
        public Button.ButtonClickedEvent BackToMenuOnClick => _backToMenuButton.onClick;

        public Transform ContainerForItems;
        [SerializeField] private Button _backToMenuButton;
    }
}
