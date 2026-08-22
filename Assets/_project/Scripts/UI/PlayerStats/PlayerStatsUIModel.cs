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
        public string LaserAmmo => _laserAmmoString;
        public string LaserCooldown => _laserCooldownString;

        private string _playerPositionString;
        private string _playerRotationString;
        private string _playerSpeedString;
        private string _laserAmmoString;
        private string _laserCooldownString;

        private PlayerProvider _playerProvider;

        private Vector3 _oldPosition = Vector3.zero;
        private float _oldRotation = 0;
        private float _oldSpeed =0;
        private int _oldLaserAmmo = 0;
        private float _oldLaserCooldown = 0;

        public PlayerStatsUIModel(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void SetLaserShooting()
        {
            UpdateData();
        }

        public void UpdateData() 
        {
            float laserCooldown = _playerProvider.PlayerLaserCoolDown;

            if (_playerProvider.PlayerPosition != _oldPosition) 
            {
                _oldPosition = _playerProvider.PlayerPosition;
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

            if (_playerProvider.PlayerLaserAmmo != _oldLaserAmmo)
            {
                _oldLaserAmmo = _playerProvider.PlayerLaserAmmo;
                _laserAmmoString = _playerProvider.PlayerLaserAmmo.ToString();
            }

            if (!Mathf.Approximately(laserCooldown, _oldLaserCooldown))
            {
                _oldLaserCooldown = laserCooldown;
                _laserCooldownString = Math.Round(laserCooldown, 1).ToString();
            }
        }
    }
}