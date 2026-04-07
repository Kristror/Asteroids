using Player;
using System;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUIModel 
    {
        public string PlayerPosition => _playerRigidBody.position.ToString();
        public string PlayerRotation => Math.Round(_playerRigidBody.transform.rotation.eulerAngles.z, 1).ToString();
        public string PlayerSpeed => Math.Round(_playerRigidBody.linearVelocity.magnitude, 1).ToString();

        public string LazerAmmo => _playerLazerShooting.Ammo.ToString();
        public string LazerReloadTime => Math.Round(_playerLazerShooting.TimeToReload(), 1).ToString();

        private Rigidbody2D _playerRigidBody;
        private PlayerLazerShooting _playerLazerShooting;

        public PlayerStatsUIModel(PlayerController playerController)
        {
            _playerRigidBody = playerController.PlayerInstance.GetComponent<Rigidbody2D>();
            _playerLazerShooting = playerController.PlayerInstance.GetComponent<PlayerLazerShooting>();
        }
    }
}