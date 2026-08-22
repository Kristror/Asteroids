using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerReviveView : MonoBehaviour
    {
        public Button.ButtonClickedEvent ReviveOnClick => _reviveButton.onClick;
        public Button.ButtonClickedEvent AcceptDeathOnClick => _acceptDeathAdButton.onClick;

        [SerializeField] private Button _reviveButton;
        [SerializeField] private Button _acceptDeathAdButton;
        [SerializeField] private GameObject _playerRevive;

        public void SetActivePlayerRevive(bool active)
        {
            _playerRevive.SetActive(active);
        }
    }
}