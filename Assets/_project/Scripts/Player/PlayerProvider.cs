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
        public int PlayerLaserAmmo => _playerLaserShooting.Ammo;
        public float PlayerLaserCoolDown => _playerLaserShooting.ShootingCooldown();

        private GameObject _playerInstance;
        private Rigidbody2D _rigidbody;
        private PlayerShipFactory _playerShipFactory; 
        private PlayerCollision _playerCollision;
        private PlayerLaserShooting _playerLaserShooting;

        public PlayerProvider(PlayerShipFactory playerShipFactory)
        {
            _playerShipFactory = playerShipFactory;
        }

        public void Initialize()
        {
            _playerInstance = _playerShipFactory.Create().gameObject;

            _rigidbody = _playerInstance.GetComponent<Rigidbody2D>();
            _playerCollision = _playerInstance.GetComponentInChildren<PlayerCollision>();
            _playerLaserShooting = _playerInstance.GetComponent<PlayerLaserShooting>();            
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