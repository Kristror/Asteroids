using Player;
using System;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUIModel 
    {
        public string PlayerPosition;
        public string PlayerRotation;
        public string PlayerSpeed;
        public string LazerAmmo;
        public string LazerCooldown;

        private PlayerProvider _playerProvider;
        private PlayerLazerShooting _playerLazerShooting;

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
            _playerLazerShooting = _playerProvider.PlayerLazerShooting;
            UpdateData();
        }

        public void UpdateData() 
        {
            float lazerCooldown = _playerLazerShooting.ShootingCooldown();

            if (_playerProvider.PlayerPosition != _oldPositon) 
            {
                _oldPositon = _playerProvider.PlayerPosition;
                PlayerPosition = _playerProvider.PlayerPosition.ToString();
            }

            if (_playerProvider.PlayerRotation != _oldRotation) 
            {
                _oldRotation = _playerProvider.PlayerRotation;
                PlayerRotation = Math.Round(_playerProvider.PlayerRotation, 1).ToString();
            }

            if (_playerProvider.PlayerSpeed != _oldSpeed) 
            {
                _oldSpeed = _playerProvider.PlayerSpeed;
                PlayerSpeed = Math.Round(_playerProvider.PlayerSpeed, 1).ToString();
            }


            if (_playerLazerShooting.Ammo != _oldLazerAmmo)
            {
                _oldLazerAmmo = _playerLazerShooting.Ammo;
                LazerAmmo = _playerLazerShooting.Ammo.ToString();
            }

            if (lazerCooldown != _oldLazerCooldown)
            {
                _oldLazerCooldown = lazerCooldown;
                LazerCooldown = Math.Round(_playerLazerShooting.ShootingCooldown(), 1).ToString();
            }
        }
    }
}