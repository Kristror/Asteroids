using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerProvider : IInitializable
    {
        public Vector3 PlayerPosition => _playerInstance.transform.position;
        public float PlayerRotation => _playerInstance.transform.rotation.eulerAngles.z;
        public float PlayerSpeed => _rigidBody.linearVelocity.magnitude;
        public int PlayerLazerAmmo => _playerLazerShooting.Ammo;
        public float PlayerLazerCoolDown => _playerLazerShooting.ShootingCooldown();

        private GameObject _playerInstance;
        private Rigidbody2D _rigidBody;
        private PlayerShipFactory _playerShipFactory; 
        private PlayerCollision _playerCollision;
        private PlayerLazerShooting _playerLazerShooting;

        public PlayerProvider(PlayerShipFactory playerShipFactory)
        {
            _playerShipFactory = playerShipFactory;
        }

        public void Initialize()
        {
            _playerInstance = _playerShipFactory.Create().gameObject;

            _rigidBody = _playerInstance.GetComponent<Rigidbody2D>();

            _playerCollision = _playerInstance.GetComponentInChildren<PlayerCollision>();

            _playerLazerShooting = _playerInstance.GetComponent<PlayerLazerShooting>();
            
        }

        public void SubscribeToPlayerDeath(Action func)
        {
            _playerCollision.PlayerDeath += func;
        } 

        public void UnSubscribeToPlayerDeath(Action func)
        {
            _playerCollision.PlayerDeath -= func;
        }
    }
}