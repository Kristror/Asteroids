using Player;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUIModel: IInitializable
    {
        public string PlayerPosition => PLAYER_POSITION_TEXT + _playerPositionString;
        public string PlayerRotation => PLAYER_ROTATION_TEXT + _playerRotationString;
        public string PlayerSpeed => PLAYER_SPEED_TEXT + _playerSpeedString;
        public string LaserAmmo => LASER_AMMO_TEXT + _laserAmmoString;
        public string LaserCooldown => LASER_COOLDOWN_TEXT + _laserCooldownString;

        private const string PLAYER_POSITION_TEXT = "Position: ";
        private const string PLAYER_ROTATION_TEXT = "Rotation: ";
        private const string PLAYER_SPEED_TEXT = "Speed: ";
        private const string LASER_AMMO_TEXT = "Laser ammo: ";
        private const string LASER_COOLDOWN_TEXT = "Laser cooldown: ";

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

        public void Initialize()
        {
            FillData();
        }

        public void SetLaserShooting()
        {
            UpdateData();
        }

        private void FillData()
        {
            float laserCooldown = _playerProvider.PlayerLaserCoolDown;
            _playerPositionString = _playerProvider.PlayerPosition.ToString();
            _playerRotationString = Math.Round(_playerProvider.PlayerRotation, 1).ToString();
            _playerSpeedString = Math.Round(_playerProvider.PlayerSpeed, 1).ToString();

            _laserAmmoString = _playerProvider.PlayerLaserAmmo.ToString();
            _laserCooldownString = Math.Round(laserCooldown, 1).ToString();
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