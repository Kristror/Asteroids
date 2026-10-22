using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerProvider : IInitializable
    {
        public Vector3 PlayerPosition => _playerInstance.transform.position;
        public float PlayerRotation => _playerInstance.transform.rotation.eulerAngles.z;
        public float PlayerSpeed => _rigidbody.linearVelocity.magnitude;
        public int PlayerLaserAmmo => PlayerLaserShooting.Ammo;
        public float PlayerLaserCoolDown => PlayerLaserShooting.ShootingCooldown();
        public PlayerLaserShooting PlayerLaserShooting { get; private set; }
        public PlayerBulletShooting PlayerBulletShooting { get; private set; }

        private GameObject _playerInstance;
        private Rigidbody2D _rigidbody;
        private PlayerShipFactory _playerShipFactory; 
        private PlayerCollision _playerCollision;

        public PlayerProvider(PlayerShipFactory playerShipFactory)
        {
            _playerShipFactory = playerShipFactory;
        }

        public void Initialize()
        {
            _playerInstance = _playerShipFactory.Create().gameObject;

            _rigidbody = _playerInstance.GetComponent<Rigidbody2D>();
            _playerCollision = _playerInstance.GetComponentInChildren<PlayerCollision>();
            PlayerLaserShooting = _playerInstance.GetComponent<PlayerLaserShooting>();
            PlayerBulletShooting = _playerInstance.GetComponent<PlayerBulletShooting>();            
        }

        public void SubscribeToPlayerDeath(Action func)
        {
            _playerCollision.PlayerDeath += func;
        } 

        public void UnsubscribeFromPlayerDeath(Action func)
        {
            _playerCollision.PlayerDeath -= func;
        }
    }
}