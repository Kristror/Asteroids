using Player;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIplayerStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textPosition;
        [SerializeField] private TMP_Text _textRotation;
        [SerializeField] private TMP_Text _textSpeed;
        [SerializeField] private TMP_Text _textLazerAmmo;
        [SerializeField] private TMP_Text _textLazerReloadTime;

        private Rigidbody2D _playerRigidBody;
        private PlayerLazerShooting _playerLazerShooting;

        private void Update()
        {
            ShowPlayerInfo();
            ShowLazerInfo();
        }

        [Inject]
        public void Construct(PlayerController playerController)
        {
            GameObject playerObject = playerController.PlayerInstance;

            _playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
            _playerLazerShooting = playerObject.GetComponent<PlayerLazerShooting>();
        }

        private void ShowLazerInfo()
        {
            _textLazerAmmo.text = _playerLazerShooting.Ammo.ToString();
            _textLazerReloadTime.text = Math.Round(_playerLazerShooting.TimeToReload(), 1).ToString();
        }

        private void ShowPlayerInfo()
        {
            _textPosition.text = _playerRigidBody.transform.position.ToString();
            _textRotation.text = Math.Round(_playerRigidBody.transform.rotation.eulerAngles.z, 1).ToString();
            _textSpeed.text = Math.Round(_playerRigidBody.linearVelocity.magnitude, 1).ToString();
        }
       
    }
}