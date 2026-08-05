using Player;
using System;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUIModel 
    {
        public string PlayerPosition => _playerPositionString;
        public string PlayerRotation => _playerRotationString;
        public string PlayerSpeed => _playerSpeedString;
        public string LazerAmmo => _lazerAmmoString;
        public string LazerCooldown => _lazerCooldownString;

        private string _playerPositionString;
        private string _playerRotationString;
        private string _playerSpeedString;
        private string _lazerAmmoString;
        private string _lazerCooldownString;

        private PlayerProvider _playerProvider;

        private Vector3 _oldPositon = Vector3.zero;
        private float _oldRotation = 0;
        private float _oldSpeed =0;
        private int _oldLazerAmmo = 0;
        private float _oldLazerCooldown = 0;

        public PlayerStatsUIModel(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void SetLazerShooting()
        {
            UpdateData();
        }

        public void UpdateData() 
        {
            float lazerCooldown = _playerProvider.PlayerLazerCoolDown;

            if (_playerProvider.PlayerPosition != _oldPositon) 
            {
                _oldPositon = _playerProvider.PlayerPosition;
                _playerPositionString = _playerProvider.PlayerPosition.ToString();
            }

            if (!Mathf.Approximately(_playerProvider.PlayerRotation, _oldRotation)) 
            {
                _oldRotation = _playerProvider.PlayerRotation;
                _playerRotationString = Math.Round(_playerProvider.PlayerRotation, 1).ToString();
            }

            if (!Mathf.Approximately(_playerProvider.PlayerSpeed, _oldSpeed) )
            {
                _oldSpeed = _playerProvider.PlayerSpeed;
                _playerSpeedString = Math.Round(_playerProvider.PlayerSpeed, 1).ToString();
            }

            if (_playerProvider.PlayerLazerAmmo != _oldLazerAmmo)
            {
                _oldLazerAmmo = _playerProvider.PlayerLazerAmmo;
                _lazerAmmoString = _playerProvider.PlayerLazerAmmo.ToString();
            }

            if (!Mathf.Approximately(lazerCooldown, _oldLazerCooldown))
            {
                _oldLazerCooldown = lazerCooldown;
                _lazerCooldownString = Math.Round(lazerCooldown, 1).ToString();
            }
        }
    }
}