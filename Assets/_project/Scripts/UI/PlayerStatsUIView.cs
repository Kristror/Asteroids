using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textPosition;
        [SerializeField] private TMP_Text _textRotation;
        [SerializeField] private TMP_Text _textSpeed;
        [SerializeField] private TMP_Text _textLazerAmmo;
        [SerializeField] private TMP_Text _textLazerReloadTime;

        public void ShowPosition(string position)
        {
            _textPosition.text = position;
        }

        public void ShowRotation(string rotation)
        {
            _textRotation.text = rotation;
        }

        public void ShowSpeed(string speed)
        {
            _textSpeed.text = speed;
        }

        public void ShowLazerAmmo(string lazerAmmo)
        {
            _textLazerAmmo.text = lazerAmmo;
        }
        public void ShowLazerReloadTime(string lazerReloadTime)
        {
            _textLazerReloadTime.text = lazerReloadTime;
        }
    }
}