using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textPosition;
        [SerializeField] private TMP_Text _textRotation;
        [SerializeField] private TMP_Text _textSpeed;
        [SerializeField] private TMP_Text _textLaserAmmo;
        [SerializeField] private TMP_Text _textLaserReloadTime;

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

        public void ShowLaserAmmo(string laserAmmo)
        {
            _textLaserAmmo.text = laserAmmo;
        }
        public void ShowLaserReloadTime(string laserReloadTime)
        {
            _textLaserReloadTime.text = laserReloadTime;
        }
    }
}